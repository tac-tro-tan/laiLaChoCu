using laiLaChoCu.Helpers;
using laiLaChoCu.Models.Feedbacks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using laiLaChoCu.Entities;
using System.Runtime.InteropServices;


namespace laiLaChoCu.Services
{
    public interface IFeedbackServices
    {
        Task<List<FeedbackResponse>> Get(int page, int pageSize);
        Task<FeedbackResponse> GetByID(int id);
        Task<int> countAll();
        Task<FeedbackResponse> Add(FeedbackRequest feedbackRequest);
        Task<FeedbackResponse> Delete(int id);
    }
    public class FeedbackServices : IFeedbackServices
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public FeedbackServices(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<FeedbackResponse> Add(FeedbackRequest feedbackRequest)
        {
            Feedback feedback = new Feedback(feedbackRequest.AccountId, feedbackRequest.Title, feedbackRequest.Content);
            this._dataContext.Add(feedback);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<Feedback,FeedbackResponse>(feedback);
        }

        public async Task<int> countAll()
        {
            var total = await _dataContext.Feedbacks.CountAsync();

            return total;
        }

        public async Task<FeedbackResponse> Delete(int id)
        {
            Feedback feedback = _dataContext.Feedbacks.Where(x => x.Id == id).FirstOrDefault();
            if(feedback != null)
            {
                this._dataContext.Feedbacks.Remove(feedback);
                await _dataContext.SaveChangesAsync();
            }
            return _mapper.Map<Feedback, FeedbackResponse>(feedback);
        }

        public async Task<List<FeedbackResponse>> Get(int page, int pageSize)
        {
            var list = await _dataContext.Feedbacks
                .Skip(page * pageSize).Take(pageSize).OrderBy(x => x.Title).ToListAsync();
            return _mapper.Map<List<Feedback>, List<FeedbackResponse>>(list);
        }

        public async Task<FeedbackResponse> GetByID(int id)
        {
            var feedback = await _dataContext.Feedbacks.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<Feedback, FeedbackResponse>(feedback);
        }
    }
}
