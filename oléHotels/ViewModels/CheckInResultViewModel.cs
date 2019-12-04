using OleHotels.Models;

namespace OleHotels.ViewModels
{
    public class CheckInResultViewModel
    {
        public bool IsCheckin { get; set; }
        public string Message { get; set; }

        public bool IsRoomAssigned { get; set; }
    }
}