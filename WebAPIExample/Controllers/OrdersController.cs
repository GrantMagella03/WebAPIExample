using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIExample.Data;
using WebAPIExample.Models;

namespace WebAPIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            return await _context.Orders.Include(i => i.customer).Include(i => i.Orderlines).ThenInclude(i => i.Item).ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            var order = await _context.Orders.Include(i=>i.customer).Include(i => i.Orderlines).ThenInclude(i => i.Item).Where(i=>i.ID==id).FirstOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.ID)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
          if (_context.Orders == null)
          {
              return Problem("Entity set 'AppDbContext.Orders'  is null.");
          }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.ID }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        [HttpPut("Confirm/{id}")]
        public async Task<IActionResult> SetOrderConfirm(int id, Order order) {
            order.Status = "Confirmed";
            return await PutOrder(id, order);
        }
        [HttpPut("BackOrder/{id}")]
        public async Task<IActionResult> SetOrderBackOrdered(int id, Order order) {
            order.Status = "BackOrdered";
            return await PutOrder(id, order);
        }
        [HttpPut("Close/{id}")]
        public async Task<IActionResult> SetOrderClosed(int id, Order order) {
            order.Status = "Closed";
            return await PutOrder(id, order);
        }

        [HttpGet("status={status}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersbyStatus(string status) {
            if (_context.Orders == null) {
                return NotFound();
            }
            var order = await _context.Orders.Include(i => i.customer).Where(i => i.Status == status).ToListAsync();

            if (order == null) {
                return NotFound();
            }

            return order;
        }


        /*
        [HttpPut("{id}/status={c}")]
        public async Task<IActionResult> OrderConfirm(int id, Order order, string c) {
            if (_context.Orders == null) {
                return NotFound();
            }
            if (c.Equals("Confirmed") || c.Equals("BackOrdered") || c.Equals("Cancelled")) {
                if (order == null) {
                  order = await _context.Orders.Include(i => i.customer).Where(i => i.CustomerID == id).FirstOrDefaultAsync();
                    if (order == null) {
                        return NotFound();
                    }
                } else {
                    await PutOrder(id, order);
                }
                //var order = await _context.Orders.Include(i => i.customer).Where(i => i.CustomerID == id).FirstOrDefaultAsync();
                order.Status = c;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
         */
    }
}
