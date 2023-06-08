using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using Shouldly;
using HomeWork2.Interfaces;
using HomeWork2.Models;
using HomeWork2.Services;
using System.Collections.Generic;
using System.Linq;


namespace TestHomeWork2
{
    [TestClass]
    public class AnimalServiceTests
    {
        private IAnimalRepository _animalRepository;
        private AnimalService _animalService;

        [TestInitialize]
        public void TestInitialize()
        {
            _animalRepository = A.Fake<IAnimalRepository>();
            _animalService = new AnimalService(_animalRepository);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllAnimals()
        {
            //Arrange
            var expectedAnimals = new List<Animal>
            {
                new Animal() {  Name = "Dog", Sound = "Woof-woof" },
                new Animal() {  Name = "Cat", Sound = "Miaw-miaw" },
                new Animal() {   Name = "Cow", Sound = "My-y-y-y" },
                new Animal()  { Name = "Frog", Sound = "Kwa-kwa" }
            };
            A.CallTo(() => _animalRepository.GetAll()).Returns(expectedAnimals);

            //Act
            var result = _animalService.GetAll();

            //Assert
            result.ShouldNotBeNull();
            result.ShouldAllBe(a => a != null);
            result.Count.ShouldBe(expectedAnimals.Count);
            result.ShouldBeEquivalentTo(expectedAnimals);
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(3, true)]
        [DataRow(5, false)]
        public void Get_ShouldReturnAnimalById(int id, bool isExistAnimal)
        {
            //Arrange
            var expectedAnimals = new List<Animal>
            {
                new Animal() { Id = 1, Name = "Dog", Sound = "Woof-woof" },
                new Animal() { Id = 2, Name = "Cat", Sound = "Miaw-miaw" },
                new Animal() { Id = 3,  Name = "Cow", Sound = "My-y-y-y" },
                new Animal()  { Id = 4, Name = "Frog", Sound = "Kwa-kwa" }
            };
            A.CallTo(() => _animalRepository.Get(id))
                .Returns(expectedAnimals.SingleOrDefault(a => a.Id == id));

            //Act
            var result = _animalService.Get(id);

            //Assert
            if (isExistAnimal)
            {
                result.ShouldNotBeNull();
                result.Name.ShouldBe(expectedAnimals[id - 1].Name);
                result.Sound.ShouldBe(expectedAnimals[id - 1].Sound);
            }
            else
            {
                result.ShouldBeNull();
            }
        }

        [TestMethod]
        [DataRow(3, "Cow", "My-my-my", true)]
        [DataRow(1, "Dog", "Haw-haw", true)]
        [DataRow(1, "Dog", "", false)]
        [DataRow(0, "", "Kwa-kwa", false)]
        [DataRow(0, "", "", false)]
        public void Add_ShouldAddNewAnimal_ButIfExistUpdateAnimal(int id, string name, string sound, bool expectedResult)
        {
            //Arrange
            var existingAnimals = new List<Animal>
            {
                new Animal { Id = 1, Name = "Dog", Sound = "Woof-woof" },
                new Animal { Id = 2, Name = "Cat", Sound = "Meow-meow" }
            };
            A.CallTo(() => _animalRepository.GetAll()).Returns(existingAnimals);
            Animal newAnimal = new Animal { Name = name, Sound = sound };

            //Act
            _animalService.Add(newAnimal);
            var result = Fake.GetCalls(_animalRepository).Any(call => call.Method.Name == "Add");

            //Assert
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(8, false)]
        public void Delete_ShouldDeleteExistAnimal(int animalId, bool callsDeleteMethod)
        {
            //Arrange
            var animals = new List<Animal>
            {
                new Animal() { Id = 1, Name = "Dog", Sound = "Woof-woof" },
                new Animal() { Id = 2, Name = "Cat", Sound = "Miaw-miaw" },
                new Animal() { Id = 3,  Name = "Cow", Sound = "My-y-y-y" },
                new Animal()  { Id = 4, Name = "Frog", Sound = "Kwa-kwa" }
            };
            Animal animalToDelete = animals.SingleOrDefault(a => a.Id == animalId);
            A.CallTo(() => _animalRepository.GetAll()).Returns(animals);
            A.CallTo(() => _animalRepository.Get(animalId)).Returns(animalToDelete);

            //Act
            _animalService.Delete(animalId);
            var resultForCallDeleteMethod = Fake.GetCalls(_animalRepository).Any(call => call.Method.Name == "Delete");

            //Assert
            resultForCallDeleteMethod.ShouldBe(callsDeleteMethod);
        }
    }
}