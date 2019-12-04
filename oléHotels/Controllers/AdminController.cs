using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OleHotels.Models;
using OleHotels.ViewModels;

namespace OleHotels.Controllers
{
    public class AdminController : Controller
    {
        private const string sessionKey = "logged_user_firstname";
        private const string sessionKeyEmpId = "logged_employeeid";
        private const double RoomPrice = 50.00;
        private const double Tax = 0.07;
        private readonly IRoomRepository _roomRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IServiceRepository _serviceRepository;

        public AdminController(IRoomRepository roomRepository, IEmployeeRepository employeeRepository, IReservationRepository reservationRepository, IClientRepository clientRepository, IServiceRepository serviceRepository)
        {
            _roomRepository = roomRepository;
            _employeeRepository = employeeRepository;
            _reservationRepository = reservationRepository;
            _clientRepository = clientRepository;
            _serviceRepository = serviceRepository;
        }

        private Employee GetLoggedEmployee()
        {
            var sessionClientId = HttpContext.Session.GetString(sessionKeyEmpId);
            if (string.IsNullOrWhiteSpace(sessionClientId) == false && int.TryParse(sessionClientId, out int employeeId))
            {
                return _employeeRepository.GetById(employeeId);
            }
            return null;

        }
        public IActionResult Rooms()
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType != "Admin")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var rooms = _roomRepository.GetAll().OrderBy(r => r.RoomNumber);
            return View(rooms);
        }

        public IActionResult Employees()
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType != "Admin")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var employees = _employeeRepository.GetAll().OrderBy(u => u.LastName).OrderBy(u => u.FirstName);
            return View(employees);
        }

        public IActionResult CheckIn()
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType == "BOH")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var model = new CheckInViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckIn(CheckInViewModel model)
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType == "BOH")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var reservation = _reservationRepository.GetBYConfirmationNumber(model.ConfirmationNumber);
            if (reservation.Client.IsCheckedIn == false && reservation.RoomId <= 0)
            {
                model.Reservation = reservation;
            }
            model.IsSubmitted = true;
            return View(model);
        }

        public IActionResult PerformCheckIn(int id)
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType == "BOH")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var model = new CheckInResultViewModel();
            var reservation = _reservationRepository.GetById(id);
            if (reservation != null)
            {
                model.IsCheckin = _clientRepository.CheckIn(reservation.ClientId);
                model.IsRoomAssigned = _reservationRepository.AssignRoom(id) != null;
            }
            model.Message = (model.IsCheckin && model.IsRoomAssigned) ? "Check-In Succesful." : "Invalid Check-In. Please try again.";

            return View(model);
        }

        public IActionResult CheckOut()
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType == "BOH")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var model = new CheckOutViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckOut(CheckOutViewModel model)
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType == "BOH")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var reservation = _reservationRepository.GetBYConfirmationNumber(model.ConfirmationNumber);
            if (reservation.Client.IsCheckedIn == true && reservation.RoomId > 0 && reservation.Room.IsVacant == false)
            {
                model.Reservation = reservation;
            }
            model.IsSubmitted = true;
            return View(model);
        }

        public IActionResult PerformCheckOut(int id)
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType == "BOH")
            {
                return RedirectToAction("Login", "Home");
            }

            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var model = new CheckOutResultViewModel();
            var reservation = _reservationRepository.GetById(id);
            if (reservation != null)
            {
                var roomId = reservation.RoomId;
                model.IsCheckOut = _clientRepository.CheckOut(reservation.ClientId);
                model.IsRoomUnassigned = _reservationRepository.UnassignRoom(id);

                CreateServiceRequest(reservation, roomId);

                model.CheckInDate = reservation.DateCheckIn;
                model.CheckOutDate = reservation.DateCheckOut;

                var stayingDays = (reservation.DateCheckOut - reservation.DateCheckIn).TotalDays;
                model.RoomTotal = RoomPrice * stayingDays;

                var addOnsPrice = reservation.Receipt.ReceiptAddOns.Sum(a => a.AddOn.Price);
                model.AddOnTotal = addOnsPrice * stayingDays;

                model.SubTotal = model.RoomTotal + model.AddOnTotal;
                model.Tax = model.SubTotal * Tax;
                model.GrandTotal = model.SubTotal + model.Tax;
            }
            model.Message = (model.IsCheckOut && model.IsRoomUnassigned) ? "Check-Out Succesful." : "Invalid Check-Out. Please try again.";

            return View(model);
        }

        private void CreateServiceRequest(Reservation reservation, int roomId)
        {
            var randomEmployee = _employeeRepository.RandomEmployee();

            var newService = new Service
            {
                ServiceType = "Cleaning",
                RoomId = roomId,
                DateCreate = DateTime.Now,
                IsCompleted = false,
                Comments = "Service Created By System",
                EmployeeId = randomEmployee != null ? randomEmployee.EmployeeId : 0
            };

            _serviceRepository.Create(newService);
        }

        public IActionResult Index()
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null)
            {
                return RedirectToAction("Login", "Home");
            }

            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;
            return View(loggedEmployee);
        }

        public IActionResult ServiceOrders()
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType == "FOH")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var services = new List<Service>();
            if (loggedEmployee.EmployeeType == "BOH")
            {
                services = _serviceRepository.GetAllByEmployeeId(loggedEmployee.EmployeeId).OrderBy(s => s.DateCreate).ToList();
            }
            else if (loggedEmployee.EmployeeType == "Admin")
            {
                services = _serviceRepository.GetAll().OrderBy(s => s.DateCreate).ToList();
            }

            return View(services);
        }

        public IActionResult ServiceOrder(int id)
        {
                        var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType == "FOH")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var service = _serviceRepository.GetById(id);

            return View(service);
        }

        [HttpPost]
        public IActionResult ServiceOrder(Service service)
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType == "FOH")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var curService = _serviceRepository.GetById(service.ServiceId);
            if(curService != null)
            {
                curService.Comments = service.Comments;
                curService.IsCompleted = service.IsCompleted;
                _serviceRepository.Update(curService);
                return RedirectToAction("ServiceOrders", "Admin");
            }
            else
            {
                ModelState.AddModelError("Comments", "Unable to save service order");
            }

            return View(service);
        }

        public IActionResult AssignReservation(int id)
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType != "Admin")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var model = new AssignReservationViewModel
            {
                RoomId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AssignReservation(AssignReservationViewModel model)
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType != "Admin")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var reservation = _reservationRepository.GetBYConfirmationNumber(model.ConfirmationNumber);
            if (reservation.Client.IsCheckedIn == false && reservation.RoomId <= 0)
            {
                model.Reservation = reservation;
            }
            model.IsSubmitted = true;
            return View(model);
        }

        public IActionResult PerformAssign(int id, int roomId)
        {
            var loggedEmployee = GetLoggedEmployee();
            if (loggedEmployee == null || loggedEmployee.EmployeeType != "Admin")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            var model = new AssignReservationResultViewModel();
            var reservation = _reservationRepository.GetById(id);
            if (reservation != null)
            {
                model.IsCheckin = _clientRepository.CheckIn(reservation.ClientId);
                model.IsRoomAssigned = _reservationRepository.AssignRoom(id) != null;
            }
            model.Message = (model.IsCheckin && model.IsRoomAssigned) ? "Succesfully Assigned a new Room" : "Invalid Assignment. Please try again";

            return View(model);
        }
    }
}
