using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GameDbContext _gameDbContext;
        public CategoryRepository(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }
        public IEnumerable<Category> AllCategories => _gameDbContext.Categories;
    }
}
