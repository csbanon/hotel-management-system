using OleHotels.Models;

namespace OleHotels.ViewModels
{
    public class AssignReservationResultViewModel
    {
        public bool IsCheckin { get; set; }
        public string Message { get; set; }

        public bool IsRoomAssigned { get; set; }
    }
}