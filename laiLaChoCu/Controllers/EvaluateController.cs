using laiLaChoCu.Authorization;
using laiLaChoCu.Models.Evaluate;
using laiLaChoCu.Services;
using Microsoft.AspNetCore.Mvc;

namespace laiLaChoCu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Controller]
    public class EvaluateController : BaseController
    {
        private readonly IEvaluateServices EvaluateServices;
        public EvaluateController(IEvaluateServices EvaluateServices)
        {
            this.EvaluateServices = EvaluateServices;
        }
        [Authorize]
        [HttpGet("{idItem}")]
        public async Task<ActionResult<List<object>>> Get(int idItem, int page = 0, int pageSize = 10)
        {
            var result = await EvaluateServices.GetByItem(idItem, page, pageSize);
            var total = await EvaluateServices.countbyItem(idItem);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<EvaluateResponse>> Add([FromBody] EvaluateRequest EvaluateRequest)
        {
            EvaluateResponse Evaluate = null;
            if (ModelState.IsValid)
            {
                Evaluate = await EvaluateServices.Add(EvaluateRequest);
            }
            return Ok(Evaluate);
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<EvaluateResponse>> Update(int id,[FromBody] EvaluateRequest EvaluateRequest)
        {
            EvaluateResponse Evaluate = null;
            if (ModelState.IsValid)
            {
                Evaluate = await EvaluateServices.Update(id, EvaluateRequest);
            }
            return Ok(Evaluate);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<EvaluateResponse>> Delete(int id)
        {
            var Evaluate = await EvaluateServices.Delete(id);
            return Ok(Evaluate);
        }
    }
}
