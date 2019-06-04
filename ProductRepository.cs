using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace InClassAspNet
{
    public class ProductRepository
    {
        string password = System.IO.File.ReadAllText("PWORD");
        private string ConnectionStr = "Server=localhost;Database=BestBuy;Uid=root;Pwd=" + password + ";";

        public List<Models.Product> GetAllProducts()
        {
            MySqlConnection Conn = new MySqlConnection(ConnectionStr);
            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText =
                "SELECT ProductId, Name, Price " +
                "FROM products";

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                MySqlDataReader datareader = cmd.ExecuteReader();
                List<Models.Product> products = new List<Models.Product>();

                while (datareader.Read())
                {
                    Models.Product product = new Models.Product()
                    {
                        ID = datareader.GetInt32("ProductId"),
                        Name = datareader.GetString("Name"),
                        Price = datareader.GetDecimal("Price")
                    };

                    products.Add(product);
                }

                return products;
            }

        }

        public void DeleteProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionStr);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText =
                "DELETE FROM products " +
                "WHERE ProductId = @id;";
            cmd.Parameters.AddWithValue("id", id);

            using (cmd.Connection)
            {

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }


        }
        public void InsertProduct(string name, decimal price)

        {
            MySqlConnection conn = new MySqlConnection(ConnectionStr);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText =
                "INSERT INTO products (Name, Price, CategoryId, OnSale, StockLevel) " +
                "VALUES (@name, @price, 1, 0, 100)";
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("price", price);


            using (cmd.Connection)
            {

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }



        }
    }


}
