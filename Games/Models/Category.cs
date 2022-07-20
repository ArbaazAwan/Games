using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Game> Games { get; set; }
    }
}
