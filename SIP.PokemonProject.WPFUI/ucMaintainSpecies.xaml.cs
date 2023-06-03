using Microsoft.EntityFrameworkCore.Infrastructure;
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
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;
using System.Windows.Markup;

namespace SIP.PokemonProject.WPFUI
{
    /// <summary>
    /// Interaction logic for ucMaintainAttribute.xaml
    /// </summary>
    /// 

    public enum ControlMode: int {
        PrimaryType = 0,
        SecondaryType = 1,
    }

    public partial class ucMaintainSpecies : UserControl {
        ControlMode controlMode;
        List<BL.Models.Type> primaryTypes = new List<BL.Models.Type>();
        List<BL.Models.Type> secondaryTypes = new List<BL.Models.Type>();

        public ucMaintainSpecies(ControlMode controlMode, Guid selectedId) {
            InitializeComponent();
            this.controlMode = controlMode;
            lblAttribute.Content = controlMode.ToString() + "s:";
            Reload(selectedId.ToString());
        }

        public ucMaintainSpecies(ControlMode controlMode, int selectedId)
        {
            InitializeComponent();
            this.controlMode = controlMode;
            lblAttribute.Content = controlMode.ToString() + "s:";
            Reload(selectedId.ToString());
        }

        private async void Reload(string selectedId)
        {
            cboAttribute.ItemsSource = null;
            switch (controlMode)
            {
                case ControlMode.PrimaryType:
                    primaryTypes = await new TypeManager().Load();
                    primaryTypes.RemoveAll(t => t.TypeName == "None");
                    lblAttribute.Content = "Primary Type:";
                    cboAttribute.ItemsSource = primaryTypes;
                    break;
                case ControlMode.SecondaryType:
                    secondaryTypes = await new TypeManager().Load();
                    lblAttribute.Content = "Secondary Type:";
                    cboAttribute.ItemsSource = secondaryTypes;
                    break;
                default:
                    Console.WriteLine("Failure to load Types");
                    break;
            }
            cboAttribute.DisplayMemberPath = "TypeName";
            cboAttribute.SelectedValuePath = "Id";
            cboAttribute.SelectedValue = Guid.Parse(selectedId);
        }

        public Guid AttributeId { get { return (Guid)cboAttribute.SelectedValue; } }
        public string AttributeText { get { return cboAttribute.Text; } }
    }
}
