namespace EmlakPortal.API.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public int PropertyId { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public virtual Property Property { get; set; }
    }
}
