using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _2024_10_08_adatbazisgyak
{
    public class databaseHandler
    {
        MySqlConnection connection;
        string tableName = "pokemons";
        public databaseHandler()
        {
            string host = "localhost";
            string username = "root";
            string password = "";
            string database = "pokemon";

            string connectionString = $"server={host};database={database};user={username};password={password}";
            connection = new MySqlConnection(connectionString);

            
        }
        public void Read()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                PokemonData.pokemonList.Clear();
                while (read.Read())
                {
                    PokemonData data = new PokemonData();
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    string name = read.GetString(read.GetOrdinal("name"));
                    int Tpoint = read.GetInt32(read.GetOrdinal("Tpoint"));

                    data.name = name;
                    data.Tpoint = Tpoint;

                    PokemonData.pokemonList.Add(data);
                }
                read.Close();
                command.Dispose();
                connection.Close();
                //MessageBox.Show("hehehe");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public void DeleteOne(PokemonData onePokemon)
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tableName} WHERE ID = {onePokemon.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                //MessageBox.Show("you got deleted");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public void DeleteAll()
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                //MessageBox.Show("Thanos snapped");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public void insertOne(PokemonData onePokemon)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO {tableName} (name,Tpoint)" + $"VALUES ('{onePokemon.name}','{onePokemon.Tpoint}')";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                //MessageBox.Show("eggyel tobb cigo");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}
