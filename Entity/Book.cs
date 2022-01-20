using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Book
    {
        [Key]
        public int CodBook { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genere { get; set; }
        public int Price { get; set; }
    }
}
