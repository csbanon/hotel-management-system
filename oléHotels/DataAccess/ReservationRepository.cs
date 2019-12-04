using System;
using System.Collections.Generic;
using System.Linq;

namespace OleHotels.Models
{
    public interface IReservationRepository
    {
        Reservation CreateReservation(Reservation newReservation);
        Reservation GetById(int id);

        IEnumerable<Reservation> GetByClient(int clientId);

        Reservation GetBYConfirmationNumber(string confirmationNumber);

        Reservation AssignRoom(int reservationId);

        Reservation AssignRoom(int reservationId, int roomId);

        bool UnassignRoom(int reservationId);
    }

    public class ReservationRepository : IReservationRepository
    {
        private readonly OleHotelsDbContext _context;

        public ReservationRepository()
        {
            _context = new OleHotelsDbContext();
        }

        public Reservation CreateReservation(Reservation newReservation)
        {

            newReservation.ConfirmationNumber = GenerateConfirmationNumber();
            _context.Reservations.Add(newReservation);

            return (_context.SaveChanges() > 0) ? newReservation : null;

        }

        private string GenerateConfirmationNumber()
        {
            var randomNumber = new Random().NextDouble();
            var newReservationNumber = Math.Floor(randomNumber * 9999999999).ToString();

            var reservation = _context.Reservations.FirstOrDefault(r => r.ConfirmationNumber == newReservationNumber);
            while (reservation != null)
            {
                randomNumber = new Random().NextDouble();
                newReservationNumber = Math.Floor(randomNumber * 9999999999).ToString();
                reservation = _context.Reservations.FirstOrDefault(r => r.ConfirmationNumber == newReservationNumber);
            }
            return newReservationNumber;
        }

        public Reservation GetById(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.ReservationId == id);

            if (reservation != null)
            {
                reservation.Client = _context.Clients.FirstOrDefault(c => c.ClientId == reservation.ClientId);
                reservation.Receipt = _context.Receipts.FirstOrDefault(r => r.ReceiptId == reservation.ReceiptId);
                reservation.Room = _context.Rooms.FirstOrDefault(r => r.RoomId == reservation.RoomId);
                if (reservation.Receipt != null)
                {
                    reservation.Receipt.ReceiptAddOns = _context.ReceiptAddOns.Where(ra => ra.ReceiptId == reservation.Receipt.ReceiptId).ToList();
                    if(reservation.Receipt.ReceiptAddOns.Any())
                    {
                        foreach (var receiptAddOn in reservation.Receipt.ReceiptAddOns)
                        {
                            receiptAddOn.AddOn = _context.AddOns.FirstOrDefault(ao=>ao.AddOnId == receiptAddOn.AddOnId);
                        }
                    }
                }
            }

            return reservation;
        }

        public IEnumerable<Reservation> GetByClient(int clientId)
        {
            return _context.Reservations.Where(r => r.ClientId == clientId);
        }

        public Reservation GetBYConfirmationNumber(string confirmationNumber)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.ConfirmationNumber == confirmationNumber);
            if(reservation != null)
            {
                return GetById(reservation.ReservationId);
            }
            return reservation;
        }

        public bool UnassignRoom(int reservationId)
        {
            var reservation = GetById(reservationId);
            if (reservation == null)
            {
                return false;
            }

            if (reservation.Room == null)
            {
                return true;
            }
            else
            {
                var room = reservation.Room;
                room.IsVacant = true;
                room.IsClean = false;

                reservation.RoomId = 0;
                reservation.Room = null;
                
                _context.Rooms.Update(room);
                _context.Reservations.Update(reservation);

                return _context.SaveChanges() > 0;
            }
        }

        public Reservation AssignRoom(int reservationId)
        {
            var reservation = GetById(reservationId);
            if (reservation == null)
            {
                return null;
            }

            if (reservation.Room != null)
            {
                return reservation;
            }
            else
            {
                reservation.Room = AssignRoomRandomly();
                reservation.RoomId = reservation.Room.RoomId;
                reservation.Room.IsVacant = false;
                
                _context.Rooms.Update(reservation.Room);
                _context.Reservations.Update(reservation);
                _context.SaveChanges();
                return reservation;
            }
        }

        private Room AssignRoomRandomly()
        {
            return _context.Rooms.FirstOrDefault(r => r.IsClean && r.IsVacant);
        }

        public Reservation AssignRoom(int reservationId, int roomId)
        {
             var reservation = GetById(reservationId);
            if (reservation == null)
            {
                return null;
            }

            if (reservation.Room != null)
            {
                return reservation;
            }
            else
            {
                reservation.Room = _context.Rooms.FirstOrDefault(r=>r.RoomId == roomId);
                reservation.RoomId = reservation.Room.RoomId;
                reservation.Room.IsVacant = false;
                
                _context.Rooms.Update(reservation.Room);
                _context.Reservations.Update(reservation);
                _context.SaveChanges();
                return reservation;
            }
        }
    }
}