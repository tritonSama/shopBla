using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace shopBla.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomer()
        {
            var customer = await _context.Customer.Include(sh => sh.Item).ToListAsync();
            return Ok(customer);
        }

        [HttpGet("items")]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id")]
        public async Task<ActionResult<Customer>> GetSingleCustomer(int id)
        {
            var customer = await _context.Customers
                .Include(h => h.Item)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (customer == null)
            {
                return NotFound("Customer not found. :/");
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> CreateCustomer(Customer customer)
        {
            customer.Item = null;
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCustomers());
        }

        [HttpPut("{id")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer custom, int id)
        {
            var dbCustomer = await _context.Customers
                .Include(sh => sh.Item)
                .FirstOrDefeaultAsync(sh => sh.Id == id);
            if (dbCustomer == null)
                return NotFound("No Customer");

            dbCustomer.firstName = customer.firstName;
            dbCustomer.lastName = customer.lastName;
            dbCustomer.fullName = customer.fullName;
            dbCustomer.ItemId = customer.ComicId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbCustomer());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var dbCustomer = await _context.Customers
                .Include(sh => sh.Item)
                .FistOrDefaultAsync(sh => sh.Id == id);
            if (dbCustomer == null)
                return NotFound("Customer not found");

            _context.Customers.Remove(dbCustomer);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCustomers());

        }

        private async Task<List<Customer>> GetDbCustomers()
        {
            return await _context.Customers.Include(sh => sh.Item).ToListAsync();
        }
    }
}





