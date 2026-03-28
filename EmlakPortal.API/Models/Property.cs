using System.ComponentModel.DataAnnotations;

namespace EmlakPortal.API.Models
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Fiyat 0'dan küçük olamaz.")]
        public decimal Price { get; set; }
        public PropertyStatus Status { get; set; } = PropertyStatus.Pending;
        public int SquareMeter { get; set; }

        public string RoomCount { get; set; } 

        public int CityId { get; set; } 
        public virtual City City { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool IsCommon { get; set; }
        public string PropertyType { get; set; }
        public string FloorsCount { get; set; }
        public string FloorLocation { get; set; }
        public string Heating {  get; set; }
        public bool IsActive { get; set; }
        public string AppUserId { get; set; } 
        public virtual AppUser AppUser { get; set; }
        public enum PropertyStatus
        {
            Pending = 0,  
            Approved = 1, 
            Rejected = 2  
        }

    }
}