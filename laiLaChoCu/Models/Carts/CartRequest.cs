﻿using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Carts
{
    public class CartRequest
    {
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        public int ItemId { get; set; }
    }
}
