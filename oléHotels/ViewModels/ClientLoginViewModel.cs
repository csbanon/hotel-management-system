using System.ComponentModel.DataAnnotations;

namespace OleHotels.Models
{
    public class ClientLoginViewModel
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
    }
}