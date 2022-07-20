using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShop.Models
{
    public class ShoppingCart
    {
        private readonly GameDbContext _gameDbContext;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        private ShoppingCart(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<GameDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Game game, int amount)
        {
            var shoppingCartItem =
                    _gameDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Game.Id == game.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Game = game,
                    Amount = 1
                };

                _gameDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _gameDbContext.SaveChanges();
        }

        public int RemoveFromCart(Game game)
        {
            var shoppingCartItem =
                    _gameDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Game.Id == game.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _gameDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _gameDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _gameDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Game)
                           .ToList());
        }
 
        public void ClearCart()
        {
            var cartItems = _gameDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _gameDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _gameDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _gameDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Game.Price * c.Amount).Sum();
            return total;
        }
    }
}
