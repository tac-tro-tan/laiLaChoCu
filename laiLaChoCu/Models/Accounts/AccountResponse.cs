﻿namespace laiLaChoCu.Models.Accounts
{
    public class AccountResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FisrtName { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}