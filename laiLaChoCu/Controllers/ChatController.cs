using laiLaChoCu.Authorization;
using laiLaChoCu.Models.Carts;
using laiLaChoCu.Models.Chats;
using laiLaChoCu.Services;
using Microsoft.AspNetCore.Mvc;

namespace laiLaChoCu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Controller]
    public class ChatController : BaseController
    {
        private readonly IChatServices chatServices;
        public ChatController(IChatServices chatServices)
        {
            this.chatServices = chatServices;
        }
        [Authorize]
        [HttpGet("get")]
        public async Task<ActionResult<List<object>>> Get(int id, Guid accountId)
        {
            var chat = await chatServices.GetAll(id, accountId);
            return Ok(chat);
        }
        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<ChatResponse>> Chat([FromBody] ChatRequest chatRequest)
        {
            ChatResponse chat = null;
            if (ModelState.IsValid)
            {
                chat = await chatServices.Add(chatRequest);
            }
            return Ok(chat); ;
        }
        [Authorize]
        [HttpPost("chat")]
        public async Task<ActionResult<ChatResponse>> Message(int id,[FromBody] MessageRequest messageRequest)
        {
            var chat = await chatServices.Chat(id, messageRequest);
            return Ok(chat);
        }
        [Authorize]
        [HttpGet("get all")]
        public async Task<ActionResult<List<object>>> Get12( Guid accountId)
        {
            var chat = await chatServices.GetAll( accountId);
            return Ok(chat);
        }
    }
}
