using System.Collections.Generic;

namespace OleHotels.Models
{
    public class Receipt
    {
        public Receipt()
        {
            ReceiptAddOns = new List<ReceiptAddOn>();
        }
        
        public int ReceiptId { get; set; }
        
        public double TotalPrice { get; set; }

        public virtual ICollection<ReceiptAddOn> ReceiptAddOns{get;set;}
    }
}