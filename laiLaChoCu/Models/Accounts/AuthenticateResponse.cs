﻿namespace laiLaChoCu.Models.Accounts
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FisrtName { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Url_Image { get; set; }
        public string Password { get; set; }
        public string JwtToken { get; set; }
    }
}

