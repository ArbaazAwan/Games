using Games.Models;
using Games.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gamesRepository;

        public GamesController(ICategoryRepository categoryRepository,IGameRepository gameRepository)
        {
            _categoryRepository = categoryRepository;
            _gamesRepository = gameRepository;
        }

        
        public ViewResult List()
        {
            GameViewModel gameViewMode = new();
            gameViewMode.Games = _gamesRepository.AllGames;
            gameViewMode.Availability = "Available";

            return View(gameViewMode);
        }
       
        public IActionResult Details(int id)
        {
            var Game = _gamesRepository.GetGameById(id);
            if (Game == null)
                return NotFound();

            return View(Game);
        }

    }
}
