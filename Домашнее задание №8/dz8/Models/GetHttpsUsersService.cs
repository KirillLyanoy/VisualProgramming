using dz8.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;

namespace dz8
{
    internal class GetHttpUsersService
    {
        private readonly HttpClient client = new()
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/users"),
        };
        private readonly JsonSerializerOptions serializeOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        public async Task<List<User>> GetUsersList()
        {
            using HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<User>? users = JsonSerializer.Deserialize<List<User>>(jsonResponse, serializeOptions);
            return users;
        }
    }
}