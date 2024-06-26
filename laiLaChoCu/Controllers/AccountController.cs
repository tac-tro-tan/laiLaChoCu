﻿using laiLaChoCu.Authorization;
using laiLaChoCu.Models.Accounts;
using laiLaChoCu.Services;
using Microsoft.AspNetCore.Mvc;

namespace laiLaChoCu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Controller]
    public class AccountController : BaseController
    {
        private readonly IAccountServices accountServices;
        public AccountController(IAccountServices accountServices)
        {
            this.accountServices = accountServices;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest registerRequest)
        {
            accountServices.Register(registerRequest);
            return Ok(new { message = "Registration successful" });
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest)
        {
            var response = accountServices.Authenticate(authenticateRequest);
            return Ok(response);
        }
        [Authorize("ADMIN")]
        [HttpGet("get")]
        public ActionResult<List<AccountResponse>> Get()
        {
            var account = accountServices.Get();
            return Ok(account);
        }
        [AllowAnonymous]
        [HttpGet("{id:Guid}")]
        public ActionResult<AccountResponse> GetById(Guid id)
        {
            var account = accountServices.GetById(id);
            return Ok(account);
        }
        [Authorize("ADMIN")]
        [HttpPost("add")]
        public ActionResult<AccountResponse> Add([FromBody] Create create)
        {
            AccountResponse account = null;
            if (ModelState.IsValid)
            {
                account = accountServices.Create(create);
            }
            return Ok(account);
        }
        [AllowAnonymous]
        [HttpPut("{id:Guid}")]
        public ActionResult<AccountResponse> Update(Guid id, [FromBody] AccountRequest accountRequest)
        {
            AccountResponse account = null;
            if (ModelState.IsValid)
            {
                account = accountServices.Update(id, accountRequest);
            }
            return Ok(account);
        }
        [Authorize("ADMIN")]
        [HttpDelete("{id:Guid}")]
        public ActionResult<AccountResponse> Delete(Guid id)
        {
            var account = accountServices.Delete(id);
            return Ok(account);
        }
        [AllowAnonymous]
        [HttpPost("{id:Guid}")]
        public ActionResult<AccountResponse> ResetPassword(Guid id, [FromBody] ResetPasswordRequest resetPasswordRequest)
        {
            var account = accountServices.ResetPassword(id, resetPasswordRequest);
            return Ok(account);
        }
        [Authorize("ADMIN")]
        [HttpPost("lock")]
        public ActionResult<AccountResponse>Lock(Guid id)
        {
            var account = accountServices.Lock(id);
            return Ok(account);
        }
        [Authorize("ADMIN")]
        [HttpPost("open")]
        public ActionResult<AccountResponse> Open(Guid id)
        {
            var account = accountServices.Open(id);
            return Ok(account);
        }
    }
}
