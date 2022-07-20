using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Models
{
    public interface IGameRepository
    {
        IEnumerable<Game> AllGames { get; }
        IEnumerable<Game> GameOfTheWeek { get; }

        Game GetGameById(int id);
    }
}
