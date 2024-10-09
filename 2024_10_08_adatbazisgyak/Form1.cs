using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2024_10_08_adatbazisgyak
{
    public partial class Form1 : Form
    {
        databaseHandler db;
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            db = new databaseHandler();
            readInfo();

            addButton.Click += AddButtonClick;
            deleteButton.Click += DeleteButtonClick;
            deleteAllButton.Click += DeleteAllButtonClick;
        }

        public void DeleteAllButtonClick(object s, EventArgs e)
        {
            db.DeleteAll();
            readInfo();
        }

        public void DeleteButtonClick(object s, EventArgs e)
        {
            int temp = listBox1.SelectedIndex;
            if (temp < 0)
            {
                return;
            }
            db.DeleteOne(PokemonData.pokemonList[temp]);
            PokemonData.pokemonList.RemoveAt(temp);
            readInfo();
        }

        public void AddButtonClick(object s, EventArgs e)
        {
            PokemonData oneNewPokemon = new PokemonData();
            oneNewPokemon.name = guna2TextBox1.Text;
            oneNewPokemon.Tpoint = Convert.ToInt32(guna2TextBox2.Text);
            db.insertOne(oneNewPokemon);
            readInfo();
        }

        public void readInfo()
        {
            listBox1.Items.Clear();
            db.Read();

            foreach (PokemonData item in PokemonData.pokemonList)
            {
                listBox1.Items.Add($"Pokemon: {item.name}, Point: {item.Tpoint}");
            }
        }
    }
}
