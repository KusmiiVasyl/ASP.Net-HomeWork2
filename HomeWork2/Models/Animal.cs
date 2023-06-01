using System.ComponentModel.DataAnnotations;


namespace HomeWork2.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "PageAddAnimal_Form_ErrorMessageName")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "PageAddAnimal_Form_ErrorMessageSound")]
        public string Sound { get; set; }
    }
}
