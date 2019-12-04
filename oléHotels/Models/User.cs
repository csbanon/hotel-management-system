using System.ComponentModel.DataAnnotations;

namespace OleHotels.Models
{
    public class User
    {
        [Display(Name = "First Name")]
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Display(Name = "Email (in the format: example@example.com)")]
        public string Email { get; set; }
        [Display(Name = "Phone number (numbers only, no spaces or \"-\")")]
        [StringLength(10, MinimumLength = 1)]
        public string Phone { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}