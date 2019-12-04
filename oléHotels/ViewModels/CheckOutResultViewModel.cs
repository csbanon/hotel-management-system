using System;
using OleHotels.Models;

namespace OleHotels.ViewModels
{
    public class CheckOutResultViewModel
    {
        public bool IsCheckOut { get; set; }
        public string Message { get; set; }
        public bool IsRoomUnassigned { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double RoomTotal {get; set;}
        public double AddOnTotal { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double GrandTotal { get; set; }
    }
}