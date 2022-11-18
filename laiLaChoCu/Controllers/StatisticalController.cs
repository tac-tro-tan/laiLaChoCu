using laiLaChoCu.Models.Statisticals;
using laiLaChoCu.Services;
using Microsoft.AspNetCore.Mvc;

namespace laiLaChoCu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Controller]
    public class StatisticalController : BaseController
    {
        private readonly IStatisticalServices statisticalServices;
        public StatisticalController(IStatisticalServices statisticalServices)
        {
            this.statisticalServices = statisticalServices;
        }
        [HttpGet("get")]
        public async Task<ActionResult<List<object>>> Get()
        {
            var list = statisticalServices.Get();
            return Ok(new
            {
                Results = list
            });
        }
        [HttpPost("account")]
        public async Task<ActionResult<StatisticalResponse>> Account()
        {
            var statistical = statisticalServices.Account();
            return Ok(statistical);
        }
        [HttpPost("item")]
        public async Task<ActionResult<StatisticalResponse>> Item()
        {
            var statistical = statisticalServices.Item();
            return Ok(statistical);
        }
        [HttpPost("upaccount")]
        public async Task<ActionResult<StatisticalResponse>> UpdateAccount(int id)
        {
            var statistical = statisticalServices.UpdateAccount(id);
            return Ok(statistical);
        }
        [HttpPost("upitem")]
        public async Task<ActionResult<StatisticalResponse>> UpdateItem(int id)
        {
            var statistical = statisticalServices.UpdateItem(id);
            return Ok(statistical);
        }
    }
}
