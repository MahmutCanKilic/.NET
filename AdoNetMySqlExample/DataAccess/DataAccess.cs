using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class PhoneRepository
    {
        private MySqlConnection connection;
        public PhoneRepository()
        {
            connection = new MySqlConnection("Server=localhost;Port=3306;Database=FirstDatabase;Uid=root;Pwd='1234';");

        }
        public void DBInsert(string insertDescription,string insertName)
        {
            string cmdString = $"INSERT INTO Masa(Description, names) values(@insertDescription, @insertName)";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(cmdString, connection);
                cmd.Parameters.AddWithValue("@insertDescription", insertDescription);
                cmd.Parameters.AddWithValue("@insertName", insertName);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex);

                connection.Close();
            }
        }

        public void DBRead(string table)
        {
            string read = $"SELECT * FROM {table}";
            connection.Open();

            MySqlCommand cmd = new MySqlCommand(read, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            
                while (reader.Read())
                {
                    Console.WriteLine(reader["names"].ToString());
                    Console.WriteLine(reader["description"].ToString());
                }

            cmd.Dispose();
            connection.Close();
        }
        public void DBDelete(int deleteId)
        {
            connection.Open();
            string del = $"DELETE FROM Masa WHERE id = @deleteId";
            MySqlCommand cmd = new MySqlCommand(del, connection);
            cmd.Parameters.AddWithValue("@deleteId", deleteId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void DBUpdate(int id, string description, string name)
        {
            connection.Open();
            string update = $"UPDATE Masa " +
                             $"SET description = @description, names = @name where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(update,connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery ();
            }
            connection.Close();
        }

    }





}