using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Repositories
{
    public class PassengerRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public PassengerRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public List<Passenger> GetPassengers()
        {
            return _airportSystemContext.Passengers.ToList();
        }

        public List<Passenger> GetPassengersOnFlight(int flightId)
        {
            var passengers = _airportSystemContext.Passengers.ToList();
            return passengers.FindAll(passenger => passenger.FlightId == flightId).ToList();
        }

        public List<Passenger> GetCheckedPassengersOnFlight(int flightId)
        {
            var passengers = _airportSystemContext.Passengers.ToList();
            return passengers.FindAll(passenger => passenger.FlightId == flightId && passenger.IsChecked == true).ToList();
        }
        public void InsertPassenger(Passenger passenger /*int flightId*/)
        {
            //passenger.FlightId = flightId;
            _airportSystemContext.Passengers.Add(passenger);
            _airportSystemContext.SaveChanges();
        }

        public Passenger GetPassenger(int passengerId)
        {
            return _airportSystemContext.Passengers.FirstOrDefault(passenger => passenger.Id == passengerId);
        }

        public void UpdatePassenger(Passenger passenger)
        {
            var passengerForUpdate = GetPassenger(passenger.Id);
            if(passengerForUpdate != null)
            {
                passengerForUpdate.FirstName = passenger.FirstName;
                passengerForUpdate.LastName = passenger.LastName;
                passengerForUpdate.Gender = passenger.Gender;
                passengerForUpdate.LuggageNumber = passenger.LuggageNumber;
                passengerForUpdate.LuggageWeight = passenger.LuggageWeight;
                passengerForUpdate.NameInDocument = passenger.NameInDocument;
                passengerForUpdate.TypeOfDocument = passenger.TypeOfDocument;
                passengerForUpdate.NumberOfDocument = passenger.NumberOfDocument;
                passengerForUpdate.ExpiryDate = passenger.ExpiryDate;
                passengerForUpdate.SeatPosition = passenger.SeatPosition;
                passengerForUpdate.SeatNumber = passenger.SeatNumber;
                passengerForUpdate.IsChecked = passenger.IsChecked;

                _airportSystemContext.SaveChanges();
            }
        }

        public void UpdatePassengerCheckInAndSeat(Passenger passenger)
        {
            var passengerForUpdate = GetPassenger(passenger.Id);
            if (passengerForUpdate != null)
            {
                passengerForUpdate.SeatPosition = passenger.SeatPosition;
                passengerForUpdate.SeatNumber = passenger.SeatNumber;
                passengerForUpdate.IsChecked = passenger.IsChecked;

                _airportSystemContext.SaveChanges();
            }
        }

        public void DeletePassenger(int passengerId)
        {
            var passenger = GetPassenger(passengerId);
            if (passenger != null)
            {
                _airportSystemContext.Passengers.Remove(passenger);
                _airportSystemContext.SaveChanges();
            }
        }
    }
}
