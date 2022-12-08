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
        public Message Message(string name, MessageRequest messagerequest)
        {

            var message = new Message
            {
                AccountId = messagerequest.IdChat,
                Name = name,
                Content = messagerequest.Message,
                Created = DateTime.Now
            };
            return message;
        }
    }
}
