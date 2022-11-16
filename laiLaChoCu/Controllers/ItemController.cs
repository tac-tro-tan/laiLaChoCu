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
        [HttpGet("get")]
        public async Task<ActionResult<List<object>>> Get(int page = 0, int pageSize = 10)
        {
            var result = await itemServices.Get(page, pageSize);
            var total = await itemServices.countAll();
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<object>>> Get(string keyWord, int page = 0, int pageSize = 10)
        {
            var result = await itemServices.GetAll(keyWord, page, pageSize);
            var total = await itemServices.countAll(keyWord);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [HttpGet("searcharea")]
        public async Task<ActionResult<List<object>>> GetArea(string keyWord, int page = 0, int pageSize = 10)
        {
            var result = await itemServices.GetArea(keyWord, page, pageSize);
            var total = await itemServices.countArea(keyWord);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [HttpGet("searchtopic")]
        public async Task<ActionResult<List<object>>> GetTopic(string keyWord, int page = 0, int pageSize = 10)
        {
            var result = await itemServices.GetTopic(keyWord, page, pageSize);
            var total = await itemServices.countTopic(keyWord);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [HttpGet("searchprice")]
        public async Task<ActionResult<List<object>>> GetPrice(int price1,int price2, int page = 0, int pageSize = 10)
        {
            var result = await itemServices.GetPrice(price1,price2,page,pageSize);
            var total = await itemServices.countPrice(price1,price2);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [HttpGet("searchaccount")]
        public async Task<ActionResult<List<object>>> GetAccount(Guid id, int page = 0, int pageSize = 10)
        {
            var result = await itemServices.GetAll(id, page, pageSize);
            var total = await itemServices.countAll(id);
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [HttpGet("getpay")]
        public async Task<ActionResult<List<object>>> GetPay(int page = 0, int pageSize = 10)
        {
            var result = await itemServices.GetPay(page, pageSize);
            var total = await itemServices.countPay();
            return Ok(new
            {
                Results = result,
                Total = total
            });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemResponse>> GetById(int id)
        {
            var item = await itemServices.GetByID(id);
            return Ok(item);
        }
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemResponse>> Delete(int id)
        {
            var item = await itemServices.Delete(id);
            return Ok(item);
        }
        [HttpPost("pay")]
        public async Task<ActionResult<ItemResponse>> Pay(int id)
        {
            var item = await itemServices.Pay(id);
            return Ok(item);
        }
        [HttpPost("cancel")]
        public async Task<ActionResult<ItemResponse>> Cancel(int id)
        {
            var item = await itemServices.Cancel(id);
            return Ok(item);
        }
    } 
}
