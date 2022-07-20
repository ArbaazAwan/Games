using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Games.Models;
using Games.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IGameRepository gameRepository, ShoppingCart shoppingCart)
        {
            _gameRepository = gameRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int Id)
        {
            var selectedGame = _gameRepository.AllGames.FirstOrDefault(g => g.Id == Id);

            if (selectedGame != null)
            {
                _shoppingCart.AddToCart(selectedGame, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int Id)
        {
            var selectedGame = _gameRepository.AllGames.FirstOrDefault(g => g.Id == Id);

            if (selectedGame != null)
            {
                _shoppingCart.RemoveFromCart(selectedGame);
            }
            return RedirectToAction("Index");
        }
    }
}
