﻿using SIP.PokemonProject.BL;
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


        // Reset data grid data source
        private async void Reload()
        {
            try
            {
                var task = await new PokedexManager().Load();
                IEnumerable<PokedexData> data = task;

                dgPokedex.ItemsSource = null;
                dgPokedex.ItemsSource = data;

                // Hide Guid columns
                dgPokedex.Columns[0].Visibility = Visibility.Hidden;
                dgPokedex.Columns[10].Visibility = Visibility.Hidden;
                dgPokedex.Columns[11].Visibility = Visibility.Hidden;

                // Change column headings
                dgPokedex.Columns[2].Header = "Species";
                dgPokedex.Columns[12].Header = "Type 1";
                dgPokedex.Columns[13].Header = "Type 2";


                // Change the font property of the column headers
                Style headerStyle = new Style();
                DataGridColumnHeader header = new DataGridColumnHeader();
                headerStyle.TargetType = header.GetType();

                Setter setter = new Setter();
                setter.Property = FontSizeProperty;
                setter.Value = 14.0;

                headerStyle.Setters.Add(setter);
                headerStyle.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = Brushes.LightYellow });
                headerStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
                headerStyle.Setters.Add(new Setter { Property = Control.FontWeightProperty, Value = FontWeights.Bold });
                headerStyle.Setters.Add(new Setter { Property = Control.FontStyleProperty, Value = FontStyles.Italic });
                headerStyle.Setters.Add(new Setter { Property = Control.BorderThicknessProperty, Value = new Thickness(1) });
                headerStyle.Setters.Add(new Setter { Property = Control.BorderBrushProperty, Value = Brushes.Black });
                headerStyle.Setters.Add(new Setter { Property = Control.HorizontalContentAlignmentProperty, Value = HorizontalAlignment.Center });

            }
            catch (Exception ex) { throw; }
        }
    }
}
