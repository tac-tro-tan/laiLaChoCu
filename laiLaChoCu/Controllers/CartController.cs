using laiLaChoCu.Authorization;
using laiLaChoCu.Models.Carts;
using laiLaChoCu.Services;
using Microsoft.AspNetCore.Mvc;

namespace laiLaChoCu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Controller]
    public class CartController : BaseController
    {
        private readonly ICartServices cartServices;
        public CartController(ICartServices cartServices)
        {
            this.cartServices = cartServices;
        }
        [Authorize]
        [HttpGet("get")]
        public async Task<ActionResult<List<object>>> Get(Guid id, int page=0,int pageSize = 10)
        {
            var result = await cartServices.Get(id,page, pageSize);
            var total = await cartServices.countAll(id);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CartResponse>> GetById(int id)
        {
            var cart = await cartServices.GetByID(id);
            return  Ok(cart);
        }
        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<CartResponse>> Add([FromBody] CartRequest cartRequest)
        {
            CartResponse cart = null;
            if (ModelState.IsValid)
            {
                cart = await cartServices.Add(cartRequest);
            }
            return Ok(cart);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartResponse>> Delete(int id)
        {
            var cart = await cartServices.Delete(id);
            return Ok(cart);
        }
    }
}
