using System;
using System.ComponentModel.DataAnnotations;

namespace OleHotels.Models
{
    public class Card
    {
        public int CardId { get; set; }

[       Required]
        [StringLength(30, MinimumLength = 1)]
        [Display(Name = "Name on Card")]
        public string NameOnCard { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 1)]
        [Display(Name = "Credit Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1)]
        [Display(Name = "CVV")]
        public string SecurityCode { get; set; }

        [Required]
        [Display(Name = "Expiration Date Month")]
        [Range(1, 12)]
        public int ExpirationMonth { get; set; }
        [Required]
        [Display(Name = "Expiration Date Year")]
        [Range(2019, 2039)]
        public int ExpirationYear { get; set; }
    }
}