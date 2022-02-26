using DomainModel.Models;
using FlightManagementWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerRepository _passengerRepository;
        public PassengerController(PassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }
        [HttpGet]
        public IActionResult GetPassengers()
        {
            try
            {
                var passengers = _passengerRepository.GetPassengers();
                return Ok(passengers);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult AddPassenger([FromBody] Passenger passenger/*int flightId*/)
        {
            if (passenger == null)
                return BadRequest();

            try
            {
                _passengerRepository.InsertPassenger(passenger/*flightId*/);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult UpdatePassenger([FromBody] Passenger passenger)
        {
            if (passenger == null)
                return BadRequest();
            try
            {
                _passengerRepository.UpdatePassenger(passenger);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("api/[controller]/UpdatePassengerCheckInAndSeat")]
        public IActionResult UpdatePassengerCheckInAndSeat([FromBody] Passenger passenger)
        {
            if (passenger == null)
                return BadRequest();
            try
            {
                _passengerRepository.UpdatePassengerCheckInAndSeat(passenger);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{passengerId:int}")]
        public IActionResult GetPassenger(int passengerId)
        {
            try
            {
                var passenger = _passengerRepository.GetPassenger(passengerId);
                return Ok(passenger);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpDelete("{passengerId:int}")]
        public IActionResult DeletePassenger(int passengerId)
        {
            try
            {
                _passengerRepository.DeletePassenger(passengerId);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
