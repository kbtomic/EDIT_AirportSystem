﻿using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightManagementBlazorServer.Services
{
    public class PassengerService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseApiUrl = "https://localhost:44334/api/Passenger";
        public PassengerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Passenger>> GetPassengers()
        {
            return await _httpClient.GetFromJsonAsync<List<Passenger>>(BaseApiUrl);
        }

        public async Task AddPassengerAsync(Passenger passenger, int flightId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BaseApiUrl);
            passenger.FlightId = flightId;
            request.Content = new StringContent(JsonSerializer.Serialize(passenger),
                Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task<Passenger> GetPassengerAsync(int passengerId)
        {
            return await _httpClient.GetFromJsonAsync<Passenger>($"{BaseApiUrl}/{passengerId}");
        }

        public async Task UpdatePassenger(Passenger passenger)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, BaseApiUrl);
            request.Content = new StringContent(JsonSerializer.Serialize(passenger),
                Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task UpdatePassengerCheckInAndSeat(Passenger passenger)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{BaseApiUrl}/api/Passenger/UpdatePassengerCheckInAndSeat");
            request.Content = new StringContent(JsonSerializer.Serialize(passenger),
                Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task DeletePassenger(int passengerId)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"{BaseApiUrl}/{passengerId}");
            await _httpClient.SendAsync(httpRequest);
        }
    }
}
