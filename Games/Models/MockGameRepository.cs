//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Games.Models
//{
//    public class MockGameRepository : IGameRepository
//    {
//        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
//        public IEnumerable<Game> AllGames => new List<Game>
//        {
//            new Game { Id = 1, Name= "GTA V", Price = 50, Category= _categoryRepository.AllCategories.ToList()[0],Description ="Grand theft auto is an open world high graphics game by Rockstars",ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg"},
//            new Game { Id = 1, Name= "COD", Price = 10, Category= _categoryRepository.AllCategories.ToList()[1],Description ="Call of duty is a shooting game",ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg"},
//            new Game { Id = 1, Name= "Tekken", Price = 150, Category= _categoryRepository.AllCategories.ToList()[2],Description ="Tekken is multiplayer fighter game",ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg"},
//            new Game { Id = 1, Name= "Snow Bros", Price = 5, Category= _categoryRepository.AllCategories.ToList()[0],Description ="Snow Bros is a arcade classic game",ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg"}
//        };

//        IEnumerable<Game> IGameRepository.GameOfTheWeek => new List<Game>
//        {
//            new Game { Id = 1, Name= "GTA V", Price = 50, Category= _categoryRepository.AllCategories.ToList()[0],Description ="Grand theft auto is an open world high graphics game by Rockstars"},
//            new Game { Id = 1, Name= "COD", Price = 10, Category= _categoryRepository.AllCategories.ToList()[1],Description ="Call of duty is a shooting game"},
           
//        };

//        public Game GetGameById(int id)
//        {
//            return AllGames.FirstOrDefault(g => g.Id == id);
//        }
//    }
//}
