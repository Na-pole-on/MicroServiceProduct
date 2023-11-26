using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
