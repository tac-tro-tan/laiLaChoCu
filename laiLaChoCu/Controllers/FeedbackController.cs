using laiLaChoCu.Authorization;
using laiLaChoCu.Models.Feedbacks;
using laiLaChoCu.Services;
using Microsoft.AspNetCore.Mvc;

namespace laiLaChoCu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Controller]
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackServices feedbackServices;
        public FeedbackController(IFeedbackServices feedbackServices)
        {
            this.feedbackServices = feedbackServices;
        }
        [Authorize("ADMIN")]
        [HttpGet("get")]
        public async Task<ActionResult<List<object>>> Get(int page=0,int pageSize = 10)
        {
            var result = await feedbackServices.Get(page, pageSize);
            var total = await feedbackServices.countAll();
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [Authorize("ADMIN")]
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackResponse>> GetByid(int id)
        {
            var feedback = await feedbackServices.GetByID(id);
            return Ok(feedback);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<FeedbackResponse>> Add([FromBody] FeedbackRequest feedbackRequest)
        {
            FeedbackResponse feedback = null;
            if (ModelState.IsValid)
            {
                feedback = await feedbackServices.Add(feedbackRequest);
            }
            return Ok(feedback);
        }
        [Authorize("ADMIN")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<FeedbackResponse>> Delete(int id)
        {
            var feedback = await feedbackServices.Delete(id);
            return Ok(feedback);
        }
        [Authorize("ADMIN")]
        [HttpPost("{id}")]
        public async Task<ActionResult<FeedbackResponse>> Click(int id)
        {
            var feedback = await feedbackServices.Click(id);
            return Ok(feedback);
        }
    }
}
