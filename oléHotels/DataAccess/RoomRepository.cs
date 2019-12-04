using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace OleHotels.Models
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Room GetById(int roomId);
    }

    public class RoomRepository : IRoomRepository
    {
        private OleHotelsDbContext _context = null;

        public RoomRepository()
        {
            _context = new OleHotelsDbContext();
            
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms;
        }

        public Room GetById(int roomId)
        {
            return _context.Rooms.FirstOrDefault(r=>r.RoomId == roomId);
        }
    }
}