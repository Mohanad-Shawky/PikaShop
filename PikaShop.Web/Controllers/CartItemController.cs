using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Services.Contracts;
using PikaShop.Web.ViewModels;
using System.Linq;
using System.Security.Claims;

namespace PikaShop.Web.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartItemController : Controller
    {
        private readonly ICartItemServices _cartItemServices;

        public CartItemController(ICartItemServices cartItemServices)
        {
            _cartItemServices = cartItemServices;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Home");
            }

            var cartItems = _cartItemServices.UnitOfWork.CartItems
               .GetAll()
               .Where(ci => ci.CustomerID == int.Parse(userId))
               .Select(ci => new CartItemViewModel
               {
                   ProductId = ci.ProductID,
                   ProductImage = ci.Product.Img,
                   ProductName = ci.Product.Name,
                   Quantity = ci.Quantity,
                   Price = (decimal)ci.Product.Price,
                   TotalPrice = (decimal)(ci.Quantity * ci.Product.Price)
               })
               .ToList();

            ViewBag.TotalPrice = cartItems.Sum(ci => ci.TotalPrice);

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int productQuantity = 1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = _cartItemServices.UnitOfWork.CartItems.GetAll()
                .FirstOrDefault(ci => ci.ProductID == productId && ci.CustomerID == int.Parse(userId));

            if (cartItem != null)
            {
                cartItem.Quantity += productQuantity;
            }
            else
            {
                var newCartItem = new CartItemEntity
                {
                    ProductID = productId,
                    CustomerID = int.Parse(userId),
                    Quantity = productQuantity
                };
                _cartItemServices.UnitOfWork.CartItems.Create(newCartItem);
            }

            _cartItemServices.UnitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult IncrementProduct(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = _cartItemServices.UnitOfWork.CartItems.GetAll()
                .FirstOrDefault(ci => ci.ProductID == productId && ci.CustomerID == int.Parse(userId));

            if (cartItem == null)
            {
                return NotFound();
            }

            cartItem.Quantity++;
            _cartItemServices.UnitOfWork.CartItems.Update(cartItem);
            _cartItemServices.UnitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DecrementProduct(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = _cartItemServices.UnitOfWork.CartItems.GetAll()
                .FirstOrDefault(ci => ci.ProductID == productId && ci.CustomerID == int.Parse(userId));

            if (cartItem == null || cartItem.Quantity <= 1)
            {
                return RedirectToAction("Index");
            }

            cartItem.Quantity--;
            _cartItemServices.UnitOfWork.CartItems.Update(cartItem);
            _cartItemServices.UnitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int productId, int customerId)
        {
            _cartItemServices.UnitOfWork.CartItems.deletebyid(productId, customerId);
            _cartItemServices.UnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
