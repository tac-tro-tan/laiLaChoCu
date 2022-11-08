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
        private readonly CartServices cartServices;
        public CartController(CartServices cartServices)
        {
            this.cartServices = cartServices;
        }
        [HttpGet("get")]
        public async Task<ActionResult<List<object>>> Get(int page=0,int pageSize = 10)
        {
            var result = await cartServices.Get(page, pageSize);
            var total = await cartServices.countAll();
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CartResponse>> GetById(int id)
        {
            var cart = await cartServices.GetByID(id);
            return  Ok(cart);
        }
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartResponse>> Delete(int id)
        {
            var cart = await cartServices.Delete(id);
            return Ok(cart);
        }
    }
}
