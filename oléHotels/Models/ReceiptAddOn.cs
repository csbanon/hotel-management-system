namespace OleHotels.Models
{
    public class ReceiptAddOn
    {
        public int ReceiptAddOnId { get; set; }
        public int ReceiptId { get; set; }
        public int AddOnId { get; set; }

        public virtual Receipt Receipt { get; set; }
        public virtual AddOn AddOn { get; set; }

    }
}