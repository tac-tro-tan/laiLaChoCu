using laiLaChoCu.Helpers;
using laiLaChoCu.Models.Evaluate;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using laiLaChoCu.Entities;
using laiLaChoCu.Models.Items;

namespace laiLaChoCu.Services
{
    public interface IEvaluateServices
    {
        Task<List<EvaluateResponse>> GetByItem(int idItem, int page, int pageSize);
        Task<int> countbyItem(int idItem);
        Task<EvaluateResponse> Add(EvaluateRequest EvaluateRequest);
        Task<EvaluateResponse> Update(int id, EvaluateRequest EvaluateRequest);
        Task<EvaluateResponse> Delete(int id);
    }
    public class EvaluateServices:IEvaluateServices
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public EvaluateServices(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<EvaluateResponse> Add(EvaluateRequest EvaluateRequest)
        {
            Evaluate newEvaluate = new Evaluate(EvaluateRequest.AccountId, EvaluateRequest.ItemId, EvaluateRequest.Comment, EvaluateRequest.Score);
            newEvaluate.Create = DateTime.Now;
            this.dataContext.Evaluates.Add(newEvaluate);
            await dataContext.SaveChangesAsync();
            return mapper.Map<Evaluate, EvaluateResponse>(newEvaluate);
        }
        public async Task<int> countbyItem(int idItem)
        {
            var total = await dataContext.Evaluates.Where(x => x.ItemId == idItem).CountAsync();
            return total;
        }
        public async Task<EvaluateResponse> Delete(int id)
        {
            Evaluate evaluate = dataContext.Evaluates.Where(x => x.Id == id).FirstOrDefault();
            if (evaluate != null)
            {
                this.dataContext.Remove(evaluate);
                await dataContext.SaveChangesAsync();
            }
            return mapper.Map<Evaluate, EvaluateResponse>(evaluate);
        }
        public async Task<List<EvaluateResponse>> GetByItem(int idItem, int page, int pageSize)
        {
            var list = await dataContext.Evaluates.Where(x => x.ItemId == idItem)
               .Skip(page * pageSize).Take(pageSize).ToListAsync();
            return mapper.Map<List<Evaluate>, List<EvaluateResponse>>(list);
        }

        public async Task<EvaluateResponse> Update(int id, EvaluateRequest EvaluateRequest)
        {
            Evaluate evaluate = dataContext.Evaluates.Where(x => x.Id == id).FirstOrDefault();
            if (evaluate != null)
            {
                evaluate.Comment = EvaluateRequest.Comment;
                evaluate.Score = EvaluateRequest.Score;
                evaluate.Create = DateTime.Now;
                this.dataContext.Update(evaluate);
                await dataContext.SaveChangesAsync();
            }
            return mapper.Map<Evaluate, EvaluateResponse>(evaluate);
        }
    }
}
