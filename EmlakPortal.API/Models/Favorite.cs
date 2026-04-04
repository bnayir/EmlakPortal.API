namespace EmlakPortal.API.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public string AppUserId { get; set; }
        public int PropertyId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Property Property { get; set; }
    }
}
