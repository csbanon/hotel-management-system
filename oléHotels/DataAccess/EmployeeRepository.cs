using System;
using System.Collections.Generic;
using System.Linq;

namespace OleHotels.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Login(string username, string password);

        Employee RandomEmployee();

        Employee GetById(int employeeId);

    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private OleHotelsDbContext _context = null;
        public EmployeeRepository()
        {
            _context = new OleHotelsDbContext();
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        public Employee Login(string username, string password)
        {
            return _context.Employees.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public Employee RandomEmployee()
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeType == "BOH");
            return employee;
        }


    }
}