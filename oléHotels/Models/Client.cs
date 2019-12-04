using System.Collections.Generic;

namespace OleHotels.Models
{
    public class Client : User
    {
        public int ClientId { get; set; }
        public int CardId { get; set; }
        public bool IsCheckedIn { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual Card Card { get; set; }

    }
}