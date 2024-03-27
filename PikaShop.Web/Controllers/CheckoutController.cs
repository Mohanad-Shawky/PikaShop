using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Context.ContextEntities.Identity;
using PikaShop.Data.Entities.Enums;
using PikaShop.Services.Contracts;
using PikaShop.Web.ViewModels;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace YourNamespace.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CheckoutController : Controller
    {
        private readonly string _stripeSecretKey = "sk_test_51Ou2OOGFkpxy9DHRADa2B3NpA00Jd65SAxn3uZfOSQL0sHcGERLn0XFZKkF6wzfm80HAO2CKu7pbIdDvvqUl60sO00YGRzG5Hk";
        private readonly ICartItemServices _cartItemService;
        private readonly UserManager<ApplicationUserEntity> userManager;

        public CheckoutController(ICartItemServices cartItemService, UserManager<ApplicationUserEntity> _userManager)
        {
            _cartItemService = cartItemService;
            userManager = _userManager;
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
            var domain = "http://localhost:12879/";

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
                SuccessUrl = domain + "Checkout/Success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = domain + "Checkout/Cancel",
            };

            var service = new SessionService();
            var session = service.Create(options);

            return Redirect(session.Url);
        }

        public async Task<IActionResult> SuccessAsync(string sessionId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.GetUserAsync(this.User);

            // Determine the payment method based on sessionId
            var paymentMethod = GetPaymentMethod();

            // Get the cart items for the current user
            var cartItems = _cartItemService.UnitOfWork.CartItems
                .GetSet().Include(ci => ci.Product)
                .Where(ci => ci.CustomerID == int.Parse(userId))
                .ToList();

            // Create a new order
            var order = new OrderEntity
            {
                CustomerID = int.Parse(userId),
                OrderedAt = DateTime.Now,
                IsPaid = true, // Assuming the order is paid
                TransactionID = sessionId ?? "pm_1OyjLdGFkpxy9DHRnjU0Z2zV", //  sessionId is the Stripe transaction ID
                Status = "paid", // Assuming the status is paid
                PaymentMethod = paymentMethod, // Determine the payment method
            };

            // Create a list to store order items
            var orderItems = new List<OrderItemEntity>();

            // Loop over cart items and convert each to order item
            foreach (var cartItem in cartItems)
            {
                cartItem.Product.UnitsInStock -= cartItem.Quantity;
                var orderItem = new OrderItemEntity
                {
                    ProductID = cartItem.ProductID,
                    Quantity = cartItem.Quantity,
                    SellingPrice = cartItem.Product.Price, // Selling price of the product
                    SubTotal = cartItem.Quantity * cartItem.Product.Price, // Subtotal of the product
                };

                orderItems.Add(orderItem);
            }

            // Set the order's Items property
            order.Items = orderItems;

            // Calculate the total of the order
            order.Total = orderItems.Sum(oi => oi.SubTotal);

            // Add the order to the database
            _cartItemService.UnitOfWork.Orders.Create(order);
            _cartItemService.UnitOfWork.Save();

            // Clear the cart after the order is created
            ClearCart();

            return View();
        }
        public PaymentMethods GetPaymentMethod()
        {


            return PaymentMethods.Stripe;

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

        public IActionResult PayOnDelivery()
        {
            return RedirectToAction("Success");
        }
        [HttpPost]
        public IActionResult ProcessDeliveryInformation(DeliveryInformationViewModel deliveryInfo)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Success");
            }
            else
            {

                return View();
            }
        }
 
    }
}