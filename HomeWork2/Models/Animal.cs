using System.ComponentModel.DataAnnotations;


namespace HomeWork2.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Sound { get; set; }
    }
}
