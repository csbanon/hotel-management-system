using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace OleHotels.Models
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAll();
        Service GetById(int serviceId);
        IEnumerable<Service> GetAllByEmployeeId(int employeeId);
        Service Create(Service newService);
        bool Update(Service service);

    }

    public class ServiceRepository : IServiceRepository
    {
        private OleHotelsDbContext _context = null;

        public ServiceRepository()
        {
            _context = new OleHotelsDbContext();
        }

        public Service Create(Service newService)
        {
            _context.Services.Add(newService);
            _context.SaveChanges();
            return newService;
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services.Select(s => new Service
            {
                Comments = s.Comments,
                DateCreate = s.DateCreate,
                Employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == s.EmployeeId),
                EmployeeId = s.EmployeeId,
                IsCompleted = s.IsCompleted,
                Room = _context.Rooms.FirstOrDefault(r => r.RoomId == s.RoomId),
                RoomId = s.RoomId,
                ServiceId = s.ServiceId,
                ServiceType = s.ServiceType
            });
        }

        public IEnumerable<Service> GetAllByEmployeeId(int employeeId)
        {
            return _context.Services.Where(s => s.EmployeeId == employeeId).Select(s => new Service
            {
                Comments = s.Comments,
                DateCreate = s.DateCreate,
                Employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == s.EmployeeId),
                EmployeeId = s.EmployeeId,
                IsCompleted = s.IsCompleted,
                Room = _context.Rooms.FirstOrDefault(r => r.RoomId == s.RoomId),
                RoomId = s.RoomId,
                ServiceId = s.ServiceId,
                ServiceType = s.ServiceType
            }); ;
        }

        public Service GetById(int serviceId)
        {
            return _context.Services.FirstOrDefault(s => s.ServiceId == serviceId);
        }

        public bool Update(Service service)
        {
            var curService = _context.Services.FirstOrDefault(s => s.ServiceId == service.ServiceId);
            if (curService != null)
            {
                curService.Comments = service.Comments;
                curService.DateCreate = service.DateCreate;
                curService.EmployeeId = service.EmployeeId;
                curService.IsCompleted = service.IsCompleted;
                curService.RoomId = service.RoomId;
                curService.ServiceType = service.ServiceType;
                _context.Services.Update(curService);
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}