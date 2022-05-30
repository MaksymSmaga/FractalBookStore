using FractalBookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FractalBookStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;
        public OrderController(IBookRepository bookRepository,
                              IOrderRepository orderRepository)
        {
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = _orderRepository.GetById(cart.OrderId);

                OrderModel model = await Map(order);
                return View(model);

            }
            return View("Empty");
        }

        private async Task<OrderModel> Map(Order order)
        {
            var bookIds = order.Items.Select(item => item.BookId);
            var books = await _bookRepository.GetAllByIdsAsync(bookIds);
            var itemModels = from item in order.Items
                             join book in books on item.BookId equals book.Id
                             select new OrderItemModel
                             {
                                 BookId = book.Id,
                                 Title = book.Title,
                                 Author = book.Author,
                                 Price = item.Price,
                                 Count = item.Count,
                             };
            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };

        }


        public async Task<IActionResult> AddItem(int bookId, int count = 1)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            var book = await _bookRepository.GetByIdAsync(bookId);

            order.AddOrUpdateItem(book, count);

            SaveOrderToAction(order, cart);

            return RedirectToAction("Index", "Book", new { id = bookId });

        }
        public async Task<IActionResult> RemoveItem(int bookId)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            var book = await _bookRepository.GetByIdAsync(bookId);

            order.RemoveItem(book);

            SaveOrderToAction(order, cart);

            return RedirectToAction("Index", "Order");
        }

        [HttpPost]
        public IActionResult UpdateItem(int bookId, int count)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            order.GetItem(bookId).Count = count;

            SaveOrderToAction(order, cart);

            return RedirectToAction("Index", "Order");
        }


        public IActionResult SendMail()
        {
            using (var client = new SmtpClient())
            {
                (Order order, Cart cart) = GetOrCreateOrderAndCart();

                var message = new MailMessage("from@protonmail.com", "msmaga@protonmail.com");
                message.Subject = "Order #" + order.Id;

                var builder = new StringBuilder();

                var str = "";
                foreach (var item in order.Items)
                {
                    builder.Append("{0}, {1}", item.BookId, item.Count);
                    str +=string.Format("{0}, {1}", item.BookId, item.Count);
                    str += $"{item.BookId}, {item.Count}";

                    builder.AppendLine();
                    str += Environment.NewLine;
                }
                message.Body = builder.ToString();
                client.Send(message);   
            }
            return RedirectToAction("Index", "Order");
        }

         
        private (Order order, Cart cart) GetOrCreateOrderAndCart()
        {
            Order order;
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                order = _orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = _orderRepository.Create();
                cart = new Cart(order.Id);
            }
            return (order, cart);
        }
        private void SaveOrderToAction(Order order, Cart cart)
        {
            _orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);
        }
    }
}
