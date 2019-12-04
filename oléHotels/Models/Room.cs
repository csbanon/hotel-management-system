using System.ComponentModel.DataAnnotations.Schema;

namespace OleHotels.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public bool IsClean { get; set; }
        public bool IsVacant { get; set; }
        
        [NotMapped]
        public bool IsAvailable
        {
            get { return this.IsClean && this.IsVacant; }
        }
    }
}