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
        [HttpGet("get")]
        public async Task<ActionResult<List<object>>> Get(int id)
        {
            var chat = await chatServices.GetAll(id);
            return Ok(chat);
        }
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
        [HttpPost("chat")]
        public async Task<ActionResult<ChatResponse>> Message(int id,[FromBody] MessageRequest messageRequest)
        {
            var chat = await chatServices.Chat(id, messageRequest);
            return Ok(chat);
        }
    }
}
