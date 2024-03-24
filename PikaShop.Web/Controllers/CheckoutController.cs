using Microsoft.AspNetCore.Mvc;
using PikaShop.Services.Contracts;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using PikaShop.Web.ViewModels;

namespace YourNamespace.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly string _stripeSecretKey = "sk_test_51Ou2OOGFkpxy9DHRADa2B3NpA00Jd65SAxn3uZfOSQL0sHcGERLn0XFZKkF6wzfm80HAO2CKu7pbIdDvvqUl60sO00YGRzG5Hk";
        private readonly ICartItemServices _cartItemService;

        public CheckoutController(ICartItemServices cartItemService)
        {
            _cartItemService = cartItemService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Home");
            }

            var cartItems = _cartItemService.UnitOfWork.CartItems
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

            var totalPrice = cartItems.Sum(ci => ci.TotalPrice);
            ViewBag.TotalPrice = totalPrice;

            return View(cartItems);
        }

        public IActionResult CreateCheckoutSession()
        {
            StripeConfiguration.ApiKey = _stripeSecretKey;
            var domain = "http://localhost:5015/";

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItems = _cartItemService.UnitOfWork.CartItems
                .GetAll()
                .Where(ci => ci.CustomerID == int.Parse(userId))
                .ToList();

            var lineItems = cartItems.Select(ci => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "usd",
                    UnitAmount = (long)(ci.Product.Price * 100),
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = ci.Product.Name,
                    },
                },
                Quantity = ci.Quantity,
            }).ToList();

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = domain + $"Checkout/Success",
                CancelUrl = domain + "Checkout/Cancel",
            };

            var service = new SessionService();
            var session = service.Create(options);

            return Redirect(session.Url);
        }

        public IActionResult Success(string sessionId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ClearCart();

            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }

        public IActionResult ClearCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartItems = _cartItemService.UnitOfWork.CartItems
                .GetAll()
                .Where(ci => ci.CustomerID == int.Parse(userId))
                .ToList();

            _cartItemService.UnitOfWork.CartItems.DeleteRange(cartItems);
            _cartItemService.UnitOfWork.Save();

            return RedirectToAction("Index", "Home");
        }
    }
}
