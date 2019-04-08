using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D2.Web.Models
{
    public class UpdateProductModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
