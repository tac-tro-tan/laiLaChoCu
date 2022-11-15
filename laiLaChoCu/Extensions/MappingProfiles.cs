using AutoMapper;
using laiLaChoCu.Entities;
using laiLaChoCu.Models.Accounts;
using laiLaChoCu.Models.Carts;
using laiLaChoCu.Models.Chats;
using laiLaChoCu.Models.Feedbacks;
using laiLaChoCu.Models.Items;

namespace laiLaChoCu.Extensions
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Item, ItemResponse>();
            CreateMap<Feedback, FeedbackResponse>();
            CreateMap<Cart, CartResponse>();
            CreateMap<Account, AuthenticateResponse>();
            CreateMap<Account, AccountResponse>();
            CreateMap<Chat, ChatResponse>();
        }
        
    }
}
