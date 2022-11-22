using laiLaChoCu.Entities;
using laiLaChoCu.Helpers;
using laiLaChoCu.Models.Statisticals;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace laiLaChoCu.Services
{
    public interface IStatisticalServices
    {
        Task<List<StatisticalResponse>> Get(int page, int pageSize);
        Task<int> countAll();
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

        public async Task<int> countAll()
        {
                var total = await dataContext.Statisticals.CountAsync();

                return total;
        }

        public async Task<List<StatisticalResponse>> Get(int page, int pageSize)
        {
            var list = await dataContext.Statisticals.Skip(page * pageSize).Take(pageSize).ToListAsync();
            return mapper.Map<List<Statistical>,List<StatisticalResponse>>(list);
        }
    }
}
