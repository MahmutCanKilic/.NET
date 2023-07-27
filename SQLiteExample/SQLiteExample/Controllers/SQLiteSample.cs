using Microsoft.Data.Sqlite;
using System.Security.Cryptography.X509Certificates;

namespace SQLiteExample.Controllers
{
    public class SQLiteSample
    {
        string sqlDBPath = "C:\\Users\\P2635\\Desktop\\Ilk_Database.db";
        public string cmdString;
        SqliteConnection connection;
        #region Properties
        public string Product { get; set; }
        public int Price { get; set; }
        public string Test { get; set; }
        public int Id { get; set; }
        #endregion
        public SQLiteSample()
        {
            connection = new SqliteConnection($"Data Source={sqlDBPath}");
        }
        public void ReadTable(string tableName)
        {
            cmdString = "SELECT * FROM " + tableName;
            connection.Open();
            using (SqliteCommand cmd = new SqliteCommand(cmdString, connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["product"]);
                    Console.WriteLine(reader["price"]);
                }
                connection.Close();
            }
            
        }
        public void InsertTable(string product, int price, string test)
        {
            Product = product;Price = price;Test = test;

            cmdString = "INSERT INTO Products(Product, Price, Test) " +
                                    "VALUES (@Product, @Price, @Test)";

            connection.Open();
            using (SqliteCommand cmd = new SqliteCommand(cmdString, connection))
            {
                cmd.Parameters.AddWithValue("@Product",Product);
                cmd.Parameters.AddWithValue("@Price",Price);
                cmd.Parameters.AddWithValue("@Test",Test);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void UpdateData(int price, int id)
        {
            Id = id; Price = price;
            cmdString = "UPDATE Products SET test = 'updated', price = @price WHERE id = @id";
            connection.Open();
            using (SqliteCommand cmd = new SqliteCommand(cmdString, connection))
            {
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@price", Price);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void DeleteData(int id)
        {
            cmdString = "DELETE FROM Products Where id = @id";
            Id = id;

            connection.Open();
            using (SqliteCommand cmd = new SqliteCommand(cmdString,connection))
            {
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
   
    

    

}

