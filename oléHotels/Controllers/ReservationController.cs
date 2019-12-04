using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OleHotels.Models;
using OleHotels.ViewModels;
using Microsoft.AspNetCore.Http;

namespace OleHotels.Controllers
{
    public class ReservationController : Controller
    {
        private const string sessionKey = "client_login";
        private const double RoomPrice = 50.00;
        private const double Tax = 1.07;

        private readonly IReservationRepository _reservationRepository;
        private readonly IAddOnsRepository _addOnsRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ICardRepository _cardRepository;

        private readonly IRoomRepository _roomRepository;

        private readonly IReceiptRepository _receiptRepository;

        public ReservationController(IReservationRepository reservationRepository, IAddOnsRepository addOnsRepository, IClientRepository clientRepository, ICardRepository cardRepository, IRoomRepository roomRepository, IReceiptRepository receiptRepository)
        {
            _reservationRepository = reservationRepository;
            _addOnsRepository = addOnsRepository;
            _clientRepository = clientRepository;
            _cardRepository = cardRepository;
            _roomRepository = roomRepository;
            _receiptRepository = receiptRepository;
        }

        private Client GetLoggedClient()
        {
            var sessionClientId = HttpContext.Session.GetString(sessionKey);
            if (string.IsNullOrWhiteSpace(sessionClientId) == false && int.TryParse(sessionClientId, out int clientId))
            {
                return _clientRepository.GetById(clientId);
            }
            return null;

        }

        public IActionResult BookReservation()
        {
            var loggedClient = GetLoggedClient();
            if (loggedClient == null)
            {
                return RedirectToAction("Login", "Client");
            }

            var model = new ReservationViewModel();
            model.Client = loggedClient;

            model.AddOns = _addOnsRepository.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult BookReservation(ReservationViewModel viewModel)
        {
            var loggedClient = GetLoggedClient();
            if (loggedClient == null)
            {
                return RedirectToAction("Login", "Client");
            }

            viewModel.AddOns = _addOnsRepository.GetAll();
            var addOnsItemsFromForm = HttpContext.Request.Form.Where(i => i.Key.StartsWith("addOn_"));
            foreach (var item in addOnsItemsFromForm)
            {
                var addOnId = int.Parse(item.Key.Replace("addOn_", ""));
                var addOn = viewModel.AddOns.FirstOrDefault(i => i.AddOnId == addOnId);
                {
                    addOn.IsSelected = true;
                }
            }

            viewModel.Reservation.ClientId = loggedClient.ClientId;

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            viewModel.Reservation.Receipt = new Receipt();
            var selectedAddOns = viewModel.AddOns.Where(a => a.IsSelected);
            viewModel.Reservation.Receipt.ReceiptAddOns = selectedAddOns.Select(a => new ReceiptAddOn
            {
                AddOnId = a.AddOnId,
                Receipt = viewModel.Reservation.Receipt
            }).ToList();

            // Calculate Total
            var stayingDays = (viewModel.Reservation.DateCheckOut - viewModel.Reservation.DateCheckIn).TotalDays;
            var addOnsPrice = selectedAddOns.Sum(a => a.Price);

            var flatPricePerDay = RoomPrice + addOnsPrice;
            var subTotal = flatPricePerDay * stayingDays;
            viewModel.Reservation.Receipt.TotalPrice = subTotal * Tax;

            var currentClient = viewModel.Client;
            currentClient.ClientId = loggedClient.ClientId;

            var newCard = _cardRepository.Create(viewModel.Card);
            currentClient.CardId = newCard.CardId;

            _clientRepository.Update(currentClient);

            viewModel.Reservation.DateCreated = DateTime.Now;

            var reservation = _reservationRepository.CreateReservation(viewModel.Reservation);
            return RedirectToAction("PostBooking", "Reservation", new { id = reservation.ReservationId });
        }

        public IActionResult PostBooking(int id)
        {
            var loggedClient = GetLoggedClient();
            if (loggedClient == null)
            {
                return RedirectToAction("Login", "Client");
            }

            var reservation = _reservationRepository.GetById(id);
            return View(reservation);
        }

        public IActionResult MyReservations()
        {
            var loggedClient = GetLoggedClient();
            if (loggedClient == null)
            {
                return RedirectToAction("Login", "Client");
            }

            var reservations = _reservationRepository.GetByClient(loggedClient.ClientId).OrderByDescending(r => r.DateCreated);
            return View(reservations);
        }

        public IActionResult Details(int id)
        {
            var loggedClient = GetLoggedClient();
            if (loggedClient == null)
            {
                return RedirectToAction("Login", "Client");
            }

            var reservation = _reservationRepository.GetById(id);
            if (reservation == null)
            {
                return RedirectToAction("NotFound", "Reservation");
            }

            return View(reservation);

        }
    }
}