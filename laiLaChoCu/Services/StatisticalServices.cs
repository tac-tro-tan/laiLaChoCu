using laiLaChoCu.Entities;
using laiLaChoCu.Helpers;
using laiLaChoCu.Models.Statisticals;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using laiLaChoCu.Models.Items;

namespace laiLaChoCu.Services
{
    public interface IStatisticalServices
    {
        Task<List<StatisticalResponse>> Get();
        Task<StatisticalResponse> Account();
        Task<StatisticalResponse> Item();
        Task<StatisticalResponse> UpdateAccount(int id);
        Task<StatisticalResponse> UpdateItem(int id);
    }
    public class StatisticalServices : IStatisticalServices
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public StatisticalServices(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;  
        }

        public async Task<StatisticalResponse> Account()
        {
            Statistical statistical = new Statistical();
            statistical.Amount = countAccount();
            statistical.Name = "Người dùng";
            this.dataContext.Statisticals.Add(statistical);
            await dataContext.SaveChangesAsync();
            return mapper.Map<Statistical,StatisticalResponse>(statistical);
        }

        public async Task<List<StatisticalResponse>> Get()
        {
            var list = await dataContext.Statisticals.ToListAsync();
            return mapper.Map<List<Statistical>, List<StatisticalResponse>>(list);
        }

        public async Task<StatisticalResponse> Item()
        {   
            Statistical statistical = new Statistical();
            statistical.Amount = countItem();
            statistical.Name = "sản phẩm";
            this.dataContext.Statisticals.Add(statistical);
            await dataContext.SaveChangesAsync();
            return mapper.Map<Statistical, StatisticalResponse>(statistical);
        }

        public async Task<StatisticalResponse> UpdateAccount(int id)
        {
            Statistical statistical = dataContext.Statisticals.Where(x => x.Id == id).FirstOrDefault();
            if(statistical != null)
            {
                statistical.Amount = countAccount();
                this.dataContext.Statisticals.Update(statistical);
                await dataContext.SaveChangesAsync();
            }
            return mapper.Map<Statistical, StatisticalResponse>(statistical);
        }

        public async Task<StatisticalResponse> UpdateItem(int id)
        {
            Statistical statistical = dataContext.Statisticals.Where(x => x.Id == id).FirstOrDefault();
            if (statistical != null)
            {
                statistical.Amount = countItem();
                this.dataContext.Statisticals.Update(statistical);
                await dataContext.SaveChangesAsync();
            }
            return mapper.Map<Statistical, StatisticalResponse>(statistical);
        }
        private int countAccount()
        {
            var total = dataContext.Accounts.Count();
            return total;
        }
        private int countItem()
        {
            var total = dataContext.Items.Count();
            return total;
        }
    }
}
