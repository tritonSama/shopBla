namespace shopBla.Client.Services.CustomerService
{
    public interface ICustomerService
    {
        List<Customer> Customers { get; set; }
        List<Item> Items { get; set; }
        Task GetItems();
        Task GetCustomers();
        Task<Customer> GetSingleCustomer(int id);
    }
}
