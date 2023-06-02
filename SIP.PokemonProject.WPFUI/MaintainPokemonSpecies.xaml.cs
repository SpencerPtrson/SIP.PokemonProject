using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        PokedexData species;
        bool isNewSpecies = false;

        public MaintainPokemonSpecies(PokedexData species)
        {
            InitializeComponent();
            this.species = species;

            if (species.SpeciesId.Equals(Guid.Empty)) {
                // New Species
                isNewSpecies = true;
                this.Title = "New Species";
            }
            else {
                isNewSpecies = false;
                this.Title = "Edit Species";
            }

            btnInsert.IsEnabled = isNewSpecies;
            btnUpdate.IsEnabled = !isNewSpecies;
            btnDelete.IsEnabled = isNewSpecies;

            DrawScreen();
        }

        private void DrawScreen() {
            // Populate fields
            // Needs Custom Controls for Type / SpeciesName
            try
            {
                txtBaseHp.Text = species.BaseHP.ToString();
                txtBaseAttack.Text = species.BaseAttack.ToString();
                txtBaseDefense.Text = species.BaseDefense.ToString();
                txtBaseSpecialAttack.Text = species.BaseSpecialAttack.ToString();
                txtBaseSpecialDefense.Text = species.BaseSpecialDefense.ToString();
                txtBaseSpeed.Text = species.BaseSpeed.ToString();
                txtPokedexEntry.Text = species.FlavorText.ToString();
            }
            catch { }
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
        private async void Reload() {
            try {
                var task = await new PokedexManager().Load();
                IEnumerable<PokedexData> data = task;
            }
            catch (Exception ex) { throw; }
        }

        // Limit Stats to Numeric inputs only
        private void txtStatNumeric(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);

            int.TryParse(e.Text, out int enteredNum);
            if (enteredNum <= 0) { lblStatus.Content = "Stats must be Numeric and greater than 0."; }
            else lblStatus.Content = "";
        }


        // Check textbox input against regex
        // https://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf
        private static readonly Regex _numericOnly = new Regex("[^0-9]"); // Regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_numericOnly.IsMatch(text);
        }

        private void txtConfirmStatNumeric(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text)) { e.CancelCommand(); }
            }
            else e.CancelCommand();
        }
    }
}
