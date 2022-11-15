using laiLaChoCu.Entities;
using laiLaChoCu.Helpers;
using laiLaChoCu.Models.Chats;

namespace laiLaChoCu.Services
{
    public interface ISupportServices
    {
        public Message Message(string name,MessageRequest message);
    }
    public class SupportServices : ISupportServices
    {
        private readonly DataContext dataContext;
        public Message Message(string name,MessageRequest messageRequest)
        {
            
            var message = new Message { 
                Id = messageRequest.IdChat,
                Name = name,
                Content = messageRequest.Message,
                Created = DateTime.Now
            };
            return message;
        }
    }
}
