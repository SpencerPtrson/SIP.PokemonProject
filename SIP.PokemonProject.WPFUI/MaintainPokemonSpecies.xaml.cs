using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIP.PokemonProject.WPFUI
{
    /// <summary>
    /// Interaction logic for MaintainPokemonSpecies.xaml
    /// </summary>
    public partial class MaintainPokemonSpecies : Window
    {
        List<Pokedex> pokedexData = new List<Pokedex>();

        public MaintainPokemonSpecies()
        {
            InitializeComponent();
            pokedexData = new List<Pokedex>();
        }

        private void btnLoadPokedex_Click(object sender, RoutedEventArgs e)
        {
            Reload();
        }


        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        // Reset data grid data source
        private async void Reload()
        {
            try
            {
                var task = await new PokedexManager().Load();
                IEnumerable<PokedexData> data = task;
            }
            catch (Exception ex) { throw; }
        }
    }
}
