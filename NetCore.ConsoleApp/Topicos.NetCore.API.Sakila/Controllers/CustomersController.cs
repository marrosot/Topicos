using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Topicos.NetCore.Sakila.Model.MyModels;
//using Topicos.NetCore.Sakila.BL.Logica.Servicio;
using AutoMapper;

namespace Topicos.NetCore.API.Sakila.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly sakilaContext _context;
        private readonly IMapper _mapper;

        public CustomersController(IMapper mapper)
        {
            _context = new sakilaContext();
            _mapper = mapper;
        }

        // GET: api/Customers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MyDtoModels.DtoCustomer>>> GetCustomers(int pageSize = 10, int pageNumber = 1)
       // {
         //   var elServicio = new Topicos.NetCore.Sakila.BL.Logica.Servicio.Customer();

         //   var x = elServicio.xyz();

          //  return await _context.Customers.ToListAsync();

        //}

        // GET: api/Customers
        //Metodo que me trae todos los Customers.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyDtoModels.DtoCustomer>>> GetCustomers(int pageSize = 10, int pageNumber = 1)
        {
            var customerBD = (await _context.Customers.Include(c => c.Address).ThenInclude(a => a.City).
                ThenInclude(c => c.Country).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync());
            var customerResultante = _mapper.Map<List<MyDtoModels.DtoCustomer>>(customerBD);

            return customerResultante;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<API.Sakila.MyDtoModels.DtoCustomer>> GetCustomer(int id)
        {
            var customerBD = (await _context.Customers.Include(c => c.Address).ThenInclude(a => a.City).
                ThenInclude(c => c.Country).Where(c => c.CustomerId == id).ToListAsync()).FirstOrDefault();

            if (customerBD == null)
            {
                return NotFound();
            }
            var customerResultante = _mapper.Map<MyDtoModels.DtoCustomer>(customerBD);
            return customerResultante;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
