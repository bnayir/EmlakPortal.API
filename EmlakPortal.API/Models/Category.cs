using System.ComponentModel.DataAnnotations;

namespace EmlakPortal.API.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public bool Status { get; set; }

        public List<Property> Properties { get; set; }
    }
}