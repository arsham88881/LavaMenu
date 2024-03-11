using System.ComponentModel.DataAnnotations;

namespace LavaMenu.WebEndpoint.Models
{
    public record addCateguryModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageAlt { get; set; }
    }
}
