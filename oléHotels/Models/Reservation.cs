using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OleHotels.Models
{
    public class Reservation
    {
        public Reservation()
        {
            ReceiptAddOns = new List<ReceiptAddOn>();
        }
        public int ReservationId { get; set; }
        public string ConfirmationNumber { get; set; }
        public int RoomId { get; set; }
        public int ClientId { get; set; }
        public int ReceiptId { get; set; }
        public DateTime DateCreated { get; set; }
        
        [Display(Name="Start Date")]
        [Required(ErrorMessage = "Start date is Required")]
        public DateTime DateCheckIn { get; set; }
        
        [Display(Name="End Date")]
        [Required(ErrorMessage = "Start date is Required")]
        public DateTime DateCheckOut { get; set; }

        public virtual Room Room { get; set; }
        public virtual Client Client { get; set; }
        public virtual Receipt Receipt { get; set; }

        public virtual ICollection<ReceiptAddOn> ReceiptAddOns{get;set;}

    }
}