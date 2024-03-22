using System;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using PikaShop.Web.ViewModels;
using PikaShop.Services.Contracts;
using System.Security.Claims;
using System.Linq;

namespace PikaShop.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICartItemServices _cartItemServices;
        private readonly IStripeService _stripeService;  

        public CheckoutController(ICartItemServices cartItemServices, IStripeService stripeService)
        {
            _cartItemServices = cartItemServices;
            _stripeService = stripeService;
        }

        // GET: /Checkout
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItems = _cartItemServices.UnitOfWork.CartItems
                .GetAll()
                .Where(ci => ci.CustomerID == int.Parse(userId))
                .Select(ci => new CartItemViewModel
                {
                    ProductId = ci.ProductID,
                    CustomerId = ci.CustomerID,
                    ProductImage = ci.Product.Img,
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity,
                    Price = (decimal)ci.Product.Price,
                    TotalPrice = (decimal)(ci.Quantity * ci.Product.Price)
                })
                .ToList();

            // Calculate total price of all items in the cart
            var totalPrice = cartItems.Sum(ci => ci.TotalPrice);

            // Pass cart items and total price to the view
            ViewBag.TotalPrice = totalPrice;
            return View(cartItems);
        }

        // POST: /Checkout/ProcessPayment
        [HttpPost]
        public IActionResult ProcessPayment(string stripeToken)
        {
            // Create a Stripe payment intent
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItems = _cartItemServices.UnitOfWork.CartItems
                .GetAll()
                .Where(ci => ci.CustomerID == int.Parse(userId))
                .ToList();
            
            decimal totalPrice = cartItems.Sum(ci => (decimal)(ci.Quantity * ci.Product.Price));

            var paymentIntent = _stripeService.CreatePaymentIntent(totalPrice, "usd", stripeToken);

            // Handle successful payment intent creation
            if (paymentIntent != null)
            {
                // Clear the user's cart
                foreach (var item in cartItems)
                {
                    _cartItemServices.UnitOfWork.CartItems.DeleteById(item.ProductID, item.CustomerID);
                }
                _cartItemServices.UnitOfWork.Save();

                return RedirectToAction("Index", "Home"); // Redirect to home page or a thank you page
            }
            else
            {
                // Handle payment intent creation failure
                ViewBag.ErrorMessage = "Payment failed. Please try again.";
                return View("Index"); // Return to checkout page with error message
            }
        }
    }
}
