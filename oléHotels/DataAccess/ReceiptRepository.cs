using System.Collections.Generic;
using System.Linq;

namespace OleHotels.Models
{
    public interface IReceiptRepository
    {
        Receipt GetById(int receiptId);
    }

    public class ReceiptRepository : IReceiptRepository
    {
        private OleHotelsDbContext _context = null;

        public ReceiptRepository()
        {
            _context = new OleHotelsDbContext();

        }

        public Receipt GetById(int receiptId)
        {
            var receipt = _context.Receipts.FirstOrDefault(r => r.ReceiptId == receiptId);
            if(receipt != null)
            {
                receipt.ReceiptAddOns = _context.ReceiptAddOns.Where(ra=>ra.ReceiptId == receipt.ReceiptId).ToList();
            }
            return receipt;
            
        }
    }
}