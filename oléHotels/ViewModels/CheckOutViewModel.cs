using OleHotels.Models;

namespace OleHotels.ViewModels
{
    public class CheckOutViewModel
    {
        public string ConfirmationNumber { get; set; }
        public Reservation Reservation { get; set; }
        public bool IsSubmitted { get; set; }
    }
}