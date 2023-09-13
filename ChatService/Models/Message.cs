namespace ChatService.Models
{
    public class Message
    {
        public string MessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string MessageContent { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
