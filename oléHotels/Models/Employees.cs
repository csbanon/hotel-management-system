namespace OleHotels.Models
{
    public class Employee : User
    {
        public int EmployeeId { get; set; }

        public string PhotoUrl { get; set; }

        public string EmployeeType { get; set; }
    }
}