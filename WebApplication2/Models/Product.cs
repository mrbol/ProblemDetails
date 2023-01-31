using System.ComponentModel.DataAnnotations;

namespace WebProblemDetails.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {PropertyName} precisa ser fornecido")]
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Category { get; set; }    

    }
}
