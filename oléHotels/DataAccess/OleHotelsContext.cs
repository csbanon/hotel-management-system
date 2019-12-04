using System;
using System.IO;
using FileContextCore;
using Microsoft.EntityFrameworkCore;

namespace OleHotels.Models
{
    public class OleHotelsDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReceiptAddOn> ReceiptAddOns { get; set; }
        public DbSet<Service> Services { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var fileLocation = Path.Combine(AppContext.BaseDirectory, "JsonFiles");
            
            //Default: JSON-Serialize
            optionsBuilder.UseFileContextDatabase("json", location: fileLocation);
        }
    }
}