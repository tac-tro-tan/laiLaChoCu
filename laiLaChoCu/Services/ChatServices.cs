using AutoMapper;
using laiLaChoCu.Entities;
using laiLaChoCu.Helpers;
using laiLaChoCu.Models.Chats;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace laiLaChoCu.Services
{
    public interface IChatServices
    {
        Task<List<ChatResponse>> GetAll(int id,Guid accountId);
        Task<List<ChatResponse>> GetAll( Guid accountId);
        Task<ChatResponse> Chat(int id,MessageRequest mode);
        Task<ChatResponse> Add(ChatRequest mode);
    }
    public class ChatServices : IChatServices
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly ISupportServices supportServices;
        public ChatServices(DataContext dataContext, IMapper mapper, ISupportServices supportServices)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.supportServices = supportServices;
        }

        public async Task<ChatResponse> Add(ChatRequest mode)
        {
            Account account1 = dataContext.Accounts.Where(x => x.Id == mode.AccountId1).FirstOrDefault();
            Account account2 = dataContext.Accounts.Where(x => x.Id == mode.AccountId2).FirstOrDefault();
            Chat chat =new Chat(mode.AccountId1,mode.AccountId2);
            chat.Name1 = account1.Title;
            chat.Name2 = account2.Title;
            chat.Status = Enums.StatusEnum.DRAFT;
            this.dataContext.Add(chat);
            await dataContext.SaveChangesAsync();
            return mapper.Map<Chat,ChatResponse>(chat);
        }

        public async Task<ChatResponse> Chat(int id, MessageRequest mode)
        {
            Chat chat = dataContext.Chats.Where(x=>x.Id==id).FirstOrDefault();
            Account account = dataContext.Accounts.Find(mode.IdChat);
            if (chat != null)
            {
                var message = supportServices.Message(account.Title ,mode);
                chat.Status = Enums.StatusEnum.APPROVED;
                chat.Messages.Add(message);
                this.dataContext.Update(chat);
                await dataContext.SaveChangesAsync();
            }
            return mapper.Map<Chat, ChatResponse>(chat);
        }

        public async Task<List<ChatResponse>> GetAll(int id,Guid accountId)
        {
            var list = await dataContext.Chats.Where(x=>x.Id==id&&x.Status==Enums.StatusEnum.APPROVED && (x.AccountId1==accountId||x.AccountId2==accountId)).ToListAsync();
            return mapper.Map<List<Chat>, List<ChatResponse>>(list);
        }

        public async Task<List<ChatResponse>> GetAll(Guid accountId)
        {
            var list = await dataContext.Chats.Where(x => x.Status == Enums.StatusEnum.APPROVED && (x.AccountId1 == accountId || x.AccountId2 == accountId)).ToListAsync();
            return mapper.Map<List<Chat>, List<ChatResponse>>(list);
        }
    }
}
 