using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string? SeatPosition { get; set; }
        public int? SeatNumber { get; set; }
        public bool? IsChecked { get; set; } = false;
        public int? FlightId { get; set; }
        public Flight Flight { get; set; }
        public int? LuggageNumber { get; set; }
        public int? LuggageWeight { get; set; }
        public string? NameInDocument { get; set; }
        public string? TypeOfDocument { get; set; }
        public int? NumberOfDocument { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
