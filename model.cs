using System.ComponentModel.DataAnnotations;

namespace ChatbotApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class ChatMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string Response { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
