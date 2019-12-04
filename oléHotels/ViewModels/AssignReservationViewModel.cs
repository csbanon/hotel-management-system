using OleHotels.Models;

namespace OleHotels.ViewModels
{
    public class AssignReservationViewModel
    {
        public string ConfirmationNumber { get; set; }
        public Reservation Reservation { get; set; }
        public int RoomId { get; set; }
        public bool IsSubmitted { get; set; }
    }
}