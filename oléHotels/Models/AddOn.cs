using System.ComponentModel.DataAnnotations.Schema;

namespace OleHotels.Models
{
    public class AddOn
    {
        public int AddOnId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        [NotMapped]
        public bool IsSelected { get; set; }
    }
}