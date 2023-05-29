using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for Pokedex.xaml
    /// </summary>
    public partial class Pokedex : Window
    {
        List<Pokedex> pokedexData = new List<Pokedex>();

        public Pokedex()
        {
            InitializeComponent();
            pokedexData = new List<Pokedex>();
        }

        private void btnLoadPokedex_Click(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private async void Reload()
        {
            var task = await new PokedexManager().Load();
            IEnumerable<PokedexData> data = task;
            // data = data.OrderBy(dgPokedex => dgPokedex.PokedexNum);

            dgPokedex.ItemsSource = null;
            dgPokedex.ItemsSource = data;
        }
    }
}
