using Games.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.ViewModels
{
    public class GameViewModel
    {
        public IEnumerable<Game> Games { get; set; }
        public string Availability { get; set; }
    }
}
