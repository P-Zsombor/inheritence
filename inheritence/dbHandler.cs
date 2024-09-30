using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace inheritence
{
    public class dbHandler
    {
        MySqlConnection connection;
        string tableName = "cars";
        public dbHandler()
        {
            string username = "root";
            string password = "";
            string host = "localhost";
            string dbName = "Trabant";
            string conString = $"username={username};password={password};host={host};database={dbName}";
            connection = new MySqlConnection(conString);
        }
        public void readAll()
        {
            try
            {
                connection.Open();
                string query = $"select * from {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    string make = read.GetString("make");
                    string model = read.GetString("model");
                    string color = read.GetString("color");
                    int year = read.GetInt32(read.GetOrdinal("year"));
                    int hp = read.GetInt32(read.GetOrdinal("power"));
                    car onecar = new car();
                    onecar.id = id;
                    onecar.make = make;
                    onecar.model = model;
                    onecar.color = color;
                    onecar.year = year;
                    onecar.hp = hp;
                    car.cars.Add(onecar);
                }
                read.Close();
                command.Dispose();
                connection.Close();
                MessageBox.Show("nagyon jóóóóó");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error:");
            }
        }
        public void addOne(car onecar)
        {
            try
            {
                connection.Open();
                string query = $"insert into {tableName} (make,model,color,year,power) values ('{onecar.make}','{onecar.model}','{onecar.color}',{onecar.year},{onecar.hp})";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("jó nagyon a cucc!!!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error:");
            }
        }
        public void delete(car onecar)
        {
            try
            {
                connection.Open();
                string query = $"delete from {tableName} where id = {onecar.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("kitörölve");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
