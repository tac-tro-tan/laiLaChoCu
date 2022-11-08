using laiLaChoCu.Entities;
using Microsoft.AspNetCore.Mvc;

namespace laiLaChoCu.Controllers
{
    public class BaseController : ControllerBase
    {
        public Account Account => (Account)HttpContext.Items["Account"];
    }
}
