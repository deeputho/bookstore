using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DeepuTestApp.Models
{
    public class BookModel
    {
        // Get and Set the BookID
        public int BookId { get; set; }

        // Get and Set the Title of the Book
        public string Title { get; set; }

        // Get and Set the Author name
        public string Author { get; set; }

        // Get and Set the Price of the book
        public decimal Price { get; set; }
    }
}