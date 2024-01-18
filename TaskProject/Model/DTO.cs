using System.ComponentModel.DataAnnotations;

namespace TaskProject.Model
{
    public class NewTask
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public required string Assignee { get; set; }
     
    }
    public class Excellist {

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}
