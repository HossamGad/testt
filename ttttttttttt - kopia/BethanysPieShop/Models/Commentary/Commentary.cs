using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class Commentary
    {
        public string Id { get; set; }
        public string PieId { get; set; }

        public string CommentId { get; set; }
        public string CommentMessage { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; }
        public float Rating { get; set; }
    }
}
