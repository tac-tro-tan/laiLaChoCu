using AutoMapper;
using laiLaChoCu.Authorization;
using laiLaChoCu.Entities;
using laiLaChoCu.Helpers;
using laiLaChoCu.Models.Accounts;
using Microsoft.EntityFrameworkCore;using Microsoft.EntityFrameworkCore.Storage;

namespace laiLaChoCu.Services
{
    using BCrypt.Net;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.VisualBasic;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Security.Principal;
    using System.Text;
    public interface IAccountServices
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        AccountResponse Register(RegisterRequest registerRequest);
        List<AccountResponse> Get();
        AccountResponse GetById(Guid id);
        AccountResponse Create(Create model);
        AccountResponse ResetPassword(Guid id, ResetPasswordRequest resetPasswordRequest);
        AccountResponse Update(Guid id, AccountRequest model);
        AccountResponse Delete(Guid id);
    }
    public class AccountServices : IAccountServices
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IJwtUtils jwtUtils;
        public AccountServices(DataContext dataContext, IMapper mapper, IJwtUtils jwtUtils)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.jwtUtils = jwtUtils;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest)
        {
            var account = dataContext.Accounts.Include(x => x.Roles).SingleOrDefault(x => x.Email == authenticateRequest.Email);
            if (account == null || !BCrypt.Verify(authenticateRequest.Password, account.Password))
            {
                throw new AppException("Email or password is incorrect");
            }
            var jwtToken = jwtUtils.GenerateJwtToken(account);
            var response = mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            return response;
        }

        public AccountResponse Create(Create model)
        {

            Account account = new Account(model.Title,model.FisrtName,model.Lastname,model.Address,model.Phone,model.Email,model.Password);
            if (dataContext.Accounts.Any(x => x.Email == model.Email))
            {
                account = null;
            }
            else
            {

                account.Password = BCrypt.HashPassword(model.Password);
                dataContext.Accounts.Add(account);
                dataContext.SaveChanges();
            }
            return mapper.Map<Account, AccountResponse>(account);
        }

        public AccountResponse Delete(Guid id)
        {
            Account exist = dataContext.Accounts.Find(id);
            if (exist != null)
            {
                this.dataContext.Accounts.Remove(exist);
                dataContext.SaveChanges();
            }
            return mapper.Map<Account, AccountResponse>(exist);
        }

        public List<AccountResponse> Get()
        {
            var accounts = dataContext.Accounts.ToList();
            return mapper.Map<List<AccountResponse>>(accounts);
        }

        public AccountResponse GetById(Guid id)
        {
            Account exist = dataContext.Accounts.Find(id);
            if (exist == null) throw new KeyNotFoundException("Account not found");
            return mapper.Map<AccountResponse>(exist);
        }

        public AccountResponse Register(RegisterRequest registerRequest)
        {

            Account account = new Account(registerRequest.Title,registerRequest.FisrtName,registerRequest.Lastname,registerRequest.Address,registerRequest.Phone,registerRequest.Email,registerRequest.Password);
            if (dataContext.Accounts.Any(x => x.Email == registerRequest.Email))
            {
                account = null;
            }
            else
            {

                account.Password = BCrypt.HashPassword(registerRequest.Password);
                dataContext.Accounts.Add(account);
                dataContext.SaveChanges();
            }
            return mapper.Map<Account, AccountResponse>(account);
        }

        public AccountResponse ResetPassword(Guid id, ResetPasswordRequest resetPasswordRequest)
        {
            Account exist = dataContext.Accounts.Find(id);
            if (BCrypt.Verify(resetPasswordRequest.OldPassword, exist.Password))
            {
                exist.Password = BCrypt.HashPassword(resetPasswordRequest.Password);
                dataContext.Accounts.Update(exist);
                dataContext.SaveChanges();
            }
            return mapper.Map<Account, AccountResponse>(exist);
        }

        public AccountResponse Update(Guid id, AccountRequest model)
        {

            Account exist = dataContext.Accounts.Find(id);
            
            exist.Title = model.Title;
            exist.FisrtName = model.FisrtName;
            exist.Lastname = model.Lastname;
            exist.Address = model.Address;
            exist.Phone = model.Phone;
            dataContext.Accounts.Update(exist);
            dataContext.SaveChanges();

            return mapper.Map<Account, AccountResponse>(exist);
        }
    }
}
