using laiLaChoCu.Authorization;
using laiLaChoCu.Models.Items;
using laiLaChoCu.Services;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Mozilla;

namespace laiLaChoCu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Controller]
    public class ItemController : BaseController
    {
        private readonly IItemServices itemServices;
        public ItemController(IItemServices itemServices)
        {
            this.itemServices = itemServices;
        }
        [AllowAnonymous]
        [HttpPost("get")]
        public async Task<ActionResult<List<object>>> Get([FromBody] Request request)
        {
            var result = await itemServices.Get(request);
            var total = await itemServices.countAll();
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [AllowAnonymous]
        [HttpPost("search")]
        public async Task<ActionResult<List<object>>> Get([FromBody] SearchRequest searchRequest)
        {
            var result = await itemServices.GetAll(searchRequest);
            var total = await itemServices.countAll(searchRequest.keyWord);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [AllowAnonymous]
        [HttpPost("searcharea")]
        public async Task<ActionResult<List<object>>> GetArea([FromBody] SearchRequest searchRequest)
        {
            var result = await itemServices.GetArea(searchRequest);
            var total = await itemServices.countArea(searchRequest.keyWord);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [AllowAnonymous]
        [HttpPost("searchtopic")]
        public async Task<ActionResult<List<object>>> GetTopic([FromBody] SearchRequest searchRequest)
        {
            var result = await itemServices.GetTopic(searchRequest);
            var total = await itemServices.countTopic(searchRequest.keyWord);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [AllowAnonymous]
        [HttpPost("searchprice")]
        public async Task<ActionResult<List<object>>> GetPrice([FromBody] PriceRequest priceRequest)
        {
            var result = await itemServices.GetPrice(priceRequest);
            var total = await itemServices.countPrice(priceRequest.Price1, priceRequest.Price2);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        
        [HttpPost("searchaccount")]
        public async Task<ActionResult<List<object>>> GetAccount([FromBody] CartRequet cartRequet)
        {
            var result = await itemServices.GetAll(cartRequet);
            var total = await itemServices.countAll(cartRequet.Id);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [Authorize("ADMIN")]
        [HttpPost("getpay")]
        public async Task<ActionResult<List<object>>> GetPay([FromBody] Request request)
        {
            var result = await itemServices.GetPay(request);
            var total = await itemServices.countPay();
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemResponse>> GetById(int id)
        {
            var item = await itemServices.GetByID(id);
            return Ok(item);
        }
        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<ItemResponse>> Add([FromBody] ItemRequest itemRequest)
        {
            ItemResponse item = null;
            if (ModelState.IsValid)
            {
                item = await itemServices.Add(itemRequest);
            }
            return Ok(item);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<ItemResponse>> Update(int id, [FromBody] ItemRequest itemRequest)
        {
            ItemResponse item = null;
            if (ModelState.IsValid)
            {
                item = await itemServices.Update(id, itemRequest);
            }
            return Ok(item);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemResponse>> Delete(int id)
        {
            var item = await itemServices.Delete(id);
            return Ok(item);
        }
        [Authorize("ADMIN")]
        [HttpPost("pay")]
        public async Task<ActionResult<ItemResponse>> Pay(int id)
        {
            var item = await itemServices.Pay(id);
            return Ok(item);
        }
        [Authorize("ADMIN")]
        [HttpPost("cancel")]
        public async Task<ActionResult<ItemResponse>> Cancel(int id)
        {
            var item = await itemServices.Cancel(id);
            return Ok(item);
        }
    } 
}
