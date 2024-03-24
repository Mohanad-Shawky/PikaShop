using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IProductServices _productServices;

        public CartItemController(ICartItemServices cartItemServices, IProductServices productServices)
        {
            _cartItemServices = cartItemServices;
            _productServices = productServices;
        }


        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                // Handle the case where userId is null or empty
                // For example, redirect to login or show an error message
                return RedirectToAction("Index", "Home");
            }
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
                   TotalPrice = (decimal)(ci.Quantity * ci.Product.Price) // Explicit cast to decimal
               })
               .ToList();

            // Calculate total price of all items in the cart
            var totalPrice = cartItems.Sum(ci => ci.TotalPrice);

            // Pass cart items and total price to the view
            ViewBag.TotalPrice = totalPrice;
            return View(cartItems);
        }

        // GET: CartItem/AddToCart/5
        [HttpPost]
        public IActionResult AddToCart(int productId,int productQuantity=1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = _cartItemServices.UnitOfWork.CartItems.GetAll()
                .FirstOrDefault(ci => ci.ProductID == productId && ci.CustomerID == int.Parse(userId));

            if (cartItem != null)
            {
                // If the product already exists in the cart, increment its quantity
                cartItem.Quantity+= productQuantity;
            }
            else
            {
                // If the product doesn't exist in the cart, create a new cart item
                var newCartItem = new CartItemEntity
                {
                    ProductID = productId,
                    CustomerID = int.Parse(userId),
                    Quantity = productQuantity
                };
                _cartItemServices.UnitOfWork.CartItems.Create(newCartItem);
            }

            _cartItemServices.UnitOfWork.Save();

            // Redirect the user to a relevant page
            return RedirectToAction("Index");
        }

        // GET: CartItem/Delete/5
        public IActionResult Delete(int id)
        {
            var cartItemEntity = _cartItemServices.UnitOfWork.CartItems.GetById(id);
            if (cartItemEntity == null)
            {
                return NotFound();
            }
            return View(cartItemEntity);
        }
        // POST: CartItem/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int productId, int customerId)
        {
            _cartItemServices.UnitOfWork.CartItems.deletebyid(productId, customerId);
            _cartItemServices.UnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        // POST: CartItem/IncrementProduct/5
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

            return NoContent();
        }

        // POST: CartItem/DecreaseProduct/5
        [HttpPost]
        public IActionResult DecreaseProduct(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = _cartItemServices.UnitOfWork.CartItems.GetAll()
                .FirstOrDefault(ci => ci.ProductID == productId && ci.CustomerID == int.Parse(userId));

            if (cartItem == null || cartItem.Quantity <= 1)
            {
                return NoContent();
            }

            cartItem.Quantity--;
            _cartItemServices.UnitOfWork.CartItems.Update(cartItem);
            _cartItemServices.UnitOfWork.Save();

            return NoContent();
        }

    }
}
