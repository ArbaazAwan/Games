using Games.Models;
using Games.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepository _gameRepository;
        public HomeController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                GamesOftheWeek = _gameRepository.GameOfTheWeek
            };
            
            return View(homeViewModel);
        }
    }
}
