using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace shopBla.Client.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public CustomerService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Item> Items { get; set; } = new List<Item>();

        public async Task GetItems(Customer customer)
        {
            var result = await _http.GetFromJsonAsync<List<Item>>("api/customer/items");
            if (result != null)
                Items = result;
        }
        
        public async Task<Customer> GetSingleCustomer(int id)
        {
            var result = await _http.GetFromJsonAsync<Customer>($"api/customer/{id}");
            if (result != null)
                return result;
            throw new Exception("Customer not found");
        }

        public async Task GetCustomers()
        {
            var result = await _http.GetFromJsonAsync<List<Customer>>("api/customer");
            if (result != null)
                Customers = result;
        }

        public Task GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
