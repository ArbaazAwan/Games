using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Models
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _gameDbContext;
        public GameRepository(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }
        public IEnumerable<Game> AllGames
        {
            get
            {
                return _gameDbContext.Games;
            }
        }

        public IEnumerable<Game> GameOfTheWeek => AllGames.Where(g=>g.Id<3);

        public Game GetGameById(int id)
        {
            return _gameDbContext.Games.FirstOrDefault(g => g.Id == id);
        }
    }
}
