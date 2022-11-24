using laiLaChoCu.Authorization;
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
        [Authorize("ADMIN")]
        [HttpGet("get")]
        public async Task<ActionResult<List<object>>> Get(int page=0, int pageSize=10)
        {
            var result = await statisticalServices.Get(page,pageSize);
            var total = await statisticalServices.countAll();
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
    }
}
