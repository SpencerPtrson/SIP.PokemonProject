using Microsoft.IdentityModel.Tokens;
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        int speciesCount;
        bool isNewSpecies = false;
        ucMaintainSpecies[] ucTypes = new ucMaintainSpecies[2];

        public MaintainPokemonSpecies(PokedexData species, int SpeciesCount) {
            InitializeComponent();
            this.species = species;
            speciesCount = SpeciesCount;

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
            try {
                // Always create controls, but only set default value if it's not a new species
                ucMaintainSpecies ucPrimaryType;
                ucMaintainSpecies ucSecondaryType;

                if (!isNewSpecies) {
                    ucPrimaryType = new ucMaintainSpecies(ControlMode.PrimaryType, species.Type1Id);
                    ucSecondaryType = new ucMaintainSpecies(ControlMode.SecondaryType, species.Type2Id);
                    txtSpeciesName.Text = species.SpeciesName.ToString();
                    txtBaseHP.Text = species.BaseHP.ToString();
                    txtBaseAttack.Text = species.BaseAttack.ToString();
                    txtBaseDefense.Text = species.BaseDefense.ToString();
                    txtBaseSpecialAttack.Text = species.BaseSpecialAttack.ToString();
                    txtBaseSpecialDefense.Text = species.BaseSpecialDefense.ToString();
                    txtBaseSpeed.Text = species.BaseSpeed.ToString();
                    txtPokedexEntry.Text = species.FlavorText.ToString();
                }
                else {
                    ucPrimaryType = new ucMaintainSpecies(ControlMode.PrimaryType, new Guid());
                    ucSecondaryType = new ucMaintainSpecies(ControlMode.SecondaryType, new Guid());
                }

                ucPrimaryType.Margin = new Thickness(20, 60, 0, 0);
                ucSecondaryType.Margin = new Thickness(20, 90, 0, 0);
                grdSpecies.Children.Add(ucPrimaryType);
                grdSpecies.Children.Add(ucSecondaryType);
                ucTypes[0] = ucPrimaryType;
                ucTypes[1] = ucSecondaryType;
            }
            catch (Exception ex) { throw ex; }
        }

        private async void btnInsert_Click(object sender, RoutedEventArgs e) {
            if(ValidateFields())
            {
                SetValues();
                int results = 0;
                Task.Run(async () => { results = await new PokedexManager().Insert(species); });
                speciesCount++;
                lblStatus.Content = species.SpeciesName + " has been added to the database";
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {
            // Check stats to ensure they're greater than 0
            if(ValidateFields())
            {
                SetValues();
                Task.Run(async () => { await new PokedexManager().Update(species); });
                lblStatus.Content = species.SpeciesName + " has been updated.";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {

        }

        // Reset data grid data source
        private async void SetValues()
        {
            try {
                Debug.WriteLine("ControlMode Value: " + ControlMode.PrimaryType);
                Debug.WriteLine("ucPrimaryType attribute text: " + ucTypes[0].cboAttribute.Text);
                Debug.WriteLine("ucPrimaryType attribute Value: " + ucTypes[(int)ControlMode.PrimaryType].cboAttribute.SelectedValue);
                Debug.WriteLine("ucPrimaryType attribute Id: " + ucTypes[(int)ControlMode.PrimaryType].AttributeId);

                species.Type1Id = ucTypes[(int)ControlMode.PrimaryType].AttributeId;
                species.Type2Id = ucTypes[(int)ControlMode.SecondaryType].AttributeId;

                species.FlavorText = txtPokedexEntry.Text;
                species.SpeciesName = txtSpeciesName.Text;
                species.BaseHP = int.Parse(txtBaseHP.Text);
                species.BaseAttack = int.Parse(txtBaseAttack.Text);
                species.BaseDefense = int.Parse(txtBaseDefense.Text);
                species.BaseSpecialAttack = int.Parse(txtBaseSpecialAttack.Text);
                species.BaseSpecialDefense = int.Parse(txtBaseSpecialDefense.Text);
                species.BaseSpeed = int.Parse(txtBaseSpeed.Text);

                species.SpritePath = "Not Implemented";
                if (isNewSpecies) { species.PokedexNum = speciesCount + 1; }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool ValidateFields() {
            if (String.IsNullOrEmpty(txtPokedexEntry.Text) ||
                String.IsNullOrEmpty(txtSpeciesName.Text) ||
                String.IsNullOrEmpty(txtBaseHP.Text) ||
                String.IsNullOrEmpty(txtBaseAttack.Text) ||
                String.IsNullOrEmpty(txtBaseDefense.Text) ||
                String.IsNullOrEmpty(txtBaseSpecialAttack.Text) ||
                String.IsNullOrEmpty(txtBaseSpecialDefense.Text) ||
                String.IsNullOrEmpty(txtBaseSpeed.Text) ||
                ucTypes[(int)ControlMode.PrimaryType].AttributeId == new Guid() ||
                ucTypes[(int)ControlMode.SecondaryType].AttributeId == new Guid())
            {
                lblStatus.Content = "A valid entry is required for all fields";
                return false;
            }
            else return true;
        }


        // STAT ENTRY FIELD CONSTRAINTS
        // Limit Stats to Numeric inputs only
        private void txtStatNumeric(object sender, TextCompositionEventArgs e) {
            e.Handled = !IsTextAllowed(e.Text);

            int.TryParse(e.Text, out int enteredNum);
            if (enteredNum < 0) { lblStatus.Content = "Stats must be Numeric and greater than 0."; }
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
