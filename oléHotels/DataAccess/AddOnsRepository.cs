using System.Collections.Generic;

namespace OleHotels.Models
{
    public interface IAddOnsRepository
    {
        IEnumerable<AddOn> GetAll();
    }
    
    public class AddOnsRepository : IAddOnsRepository
    {
        private readonly OleHotelsDbContext _context;

        public AddOnsRepository()
        {
            _context = new OleHotelsDbContext();
        }

        public IEnumerable<AddOn> GetAll()
        {
            return _context.AddOns;
        }
    }
}