using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using OleHotels.Models;

namespace OleHotels.ViewModels
{
    public class ReservationViewModel
    {
        public ReservationViewModel()
        {
            ExpirationMonths = new List<SelectListItem>();
            for (var m = 1; m <= 12; m++)
            {
                ExpirationMonths.Add(new SelectListItem{Text = m.ToString(), Value = m.ToString()});;
            }

            ExpirationYears = new List<SelectListItem>();
            for(var y = DateTime.Now.Year; y <= (DateTime.Now.Year + 20); y++)
            {
                ExpirationYears.Add(new SelectListItem{Text = y.ToString(), Value = y.ToString()});
            }
        }

        public Reservation Reservation { get; set; }
        public Client Client { get; set; }
        public Card Card { get; set; }
        public IEnumerable<AddOn> AddOns { get; set; }
        public List<SelectListItem> ExpirationMonths { get; private set; }
        public List<SelectListItem> ExpirationYears { get; private set; }
    }
}