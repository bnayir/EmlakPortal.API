using System.ComponentModel.DataAnnotations;

namespace EmlakPortal.Api.Models
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int SquareMeter { get; set; }

        public string RoomCount { get; set; } 

        public string City { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsCommon { get; set; }
        public string PropertyType { get; set; }
        public string FloorsCount { get; set; }
        public string FloorLocation { get; set; }
        public string Heating {  get; set; }
        public bool IsActive { get; set; }
    }
}