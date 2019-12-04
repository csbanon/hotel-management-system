using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace OleHotels.Models
{
    public class Service
    {
        [HiddenInput]
        public int ServiceId { get; set; }
        public string ServiceType { get; set; }
        public int RoomId { get; set; }
        public DateTime DateCreate { get; set; }
        public int EmployeeId { get; set; }
        [Display(Name="Completed?")]
        public bool IsCompleted { get; set; }
        [Display(Name="Comments")]
        public string Comments { get; set; }

        public virtual Room Room { get; set; }
        public virtual Employee Employee { get; set; }
    }
}