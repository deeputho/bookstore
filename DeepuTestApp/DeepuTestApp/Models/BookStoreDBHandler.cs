using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;

namespace DeepuTestApp.Models
{
    public class BookStoreDBHandler
    {
        private SqlConnection con;

        private void connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["BookStoreCon"].ToString();
            con = new SqlConnection(conString);
        }

        // Add new book
        public bool InsertItem(BookModel bList)
        {
            connection();
            string query = "INSERT INTO BOOK VALUES('" + bList.Title + "','" + bList.Author + "'," + bList.Price + ")";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // View All
        public List<BookModel> GetBookList()
        {
            connection();
            List<BookModel> bList = new List<BookModel>();
            string query = "Select * from Book";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                bList.Add(new BookModel
                {
                    BookId = Convert.ToInt32(dr["BookID"]),
                    Title = Convert.ToString(dr["Title"]),
                    Author = Convert.ToString(dr["Author"]),
                    Price = Convert.ToDecimal(dr["Price"])
                });
            }

            return bList;
        }

        // 3. ********** Update Item Details **********
        public bool UpdateBook(BookModel bList)
        {
            connection();
            string query = "UPDATE BOOK SET Title = '" + bList.Title + "', Author = '" + bList.Author + "', Price = " + bList.Price + " WHERE BOOKID = " + bList.BookId;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // 4. ********** Delete Item **********
        public bool DeleteBook(int id)
        {
            connection();
            string query = "DELETE FROM BOOK WHERE BOOKID = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}