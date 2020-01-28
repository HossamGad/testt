using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    
    public class CommentaryRepository : ICommentary
    {
        
        private readonly AppDbContext database;

      
        public CommentaryRepository(AppDbContext appDbContext)
        {
            database = appDbContext;
        }

        // hämta alla kommentarer
        public IEnumerable<Pie> AllPies
        {
            get { return database.Pies.Include(a =>a.Category); }
            
        }

        // hämta alla kommentarer för angiven produkt
        public IEnumerable<Commentary> GetAllcommentary()
        {
            return database.DbCommentary;
                           
        }
        public IEnumerable<Commentary> GetCommentaryByPieId(string PieId)
        {
            return database.DbCommentary.Where(c => c.PieId == PieId);
        }

        // lägg till ny kommentar
        public void CreateCommentAndAddToDatabase(Commentary newCommentary)
        {
            database.DbCommentary.Add(newCommentary);
            database.SaveChanges();

        }
    }
}
