using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;
using System.Security.Claims;

namespace MovieApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            if (userId != null)
            {
                var loggedInUser = await _context.Users
                    .Include(z => z.UserOrder)
                    .Include("UserOrder.TicketInOrders")
                    .Include("UserOrder.TicketInOrders.OrderedTicket")
                    .FirstOrDefaultAsync(z => z.Id == userId);



                var allTickets = loggedInUser?.UserOrder.TicketInOrders.ToList();

                var totalPrice = 0.0;

                foreach (var item in allTickets)
                {
                    totalPrice += Double.Round((item.Quantity * item.OrderedTicket.Price), 2);
                }


                var model = new OrderDTO()
                {
                    AllTickets = allTickets,
                    TotalPrice = totalPrice
                };

                return View(model);
            }

            return View();
        }

        public async Task<IActionResult> DeleteTicketFromOrder(Guid? ticketId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            if (userId != null)
            {
                var loggedInUser = await _context.Users
                     .Include(z => z.UserOrder)
                     .Include("UserOrder.TicketInOrders")
                     .Include("UserOrder.TicketInOrders.OrderedTicket")
                     .FirstOrDefaultAsync(z => z.Id == userId);

                var ticket_to_delete = loggedInUser?.UserOrder.TicketInOrders.First(z => z.TicketId == ticketId);

                loggedInUser?.UserOrder.TicketInOrders.Remove(ticket_to_delete);

                _context.Orders.Update(loggedInUser?.UserOrder);
                _context.SaveChanges();

                return RedirectToAction("Index", "Orders");

            }
            return RedirectToAction("Index", "Orders");
        }



        public async Task<IActionResult> Order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            if (userId != null)
            {
                var loggedInUser = await _context.Users
                        .Include(z => z.UserOrder)
                        .Include("UserOrder.TicketInOrders")
                     .Include("UserOrder.TicketInOrders.OrderedTicket")
                        .FirstOrDefaultAsync(z => z.Id == userId);

                var userCart = loggedInUser?.UserOrder;

                var userOrder = new Order
                {
                    Id = Guid.NewGuid(),
                    OwnerId = userId,
                    Owner = loggedInUser
                };

                _context.Orders.Add(userOrder);
                _context.SaveChanges();

                var productInOrders = userCart?.TicketInOrders.Select(z => new TicketInOrder
                {
                    Order = userOrder,
                    OrderId = userOrder.Id,
                    TicketId = z.TicketId,
                    OrderedTicket = z.OrderedTicket,
                    Quantity = z.Quantity
                }).ToList();

                _context.TicketInOrders.AddRange(productInOrders);
                _context.SaveChanges();

                userCart?.TicketInOrders.Clear();

                _context.Orders.Update(userCart);
                _context.SaveChanges();

                return RedirectToAction("Index", "Orders");
            }
            return RedirectToAction("Index", "Orders");
        }


    }
}
