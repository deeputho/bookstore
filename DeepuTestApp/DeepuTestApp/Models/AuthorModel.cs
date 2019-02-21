using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeepuTestApp.Models
{
    public class AuthorModel
    {
        // Gets and Sets AuthorID
        public int AuthorID { get; set; }

        // Gets and Sets Name of the Author
        public string AuthorName { get; set; }

        // Gets and Sets the books of the Author
        public List<BookModel> Books { get; set; }
    }
}