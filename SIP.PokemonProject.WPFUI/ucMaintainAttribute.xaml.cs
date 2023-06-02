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
    /// Interaction logic for ucMaintainAttribute.xaml
    /// </summary>
    /// 

    public enum ControlMode: int
    {
        Type1 = 0,
        Type2 = 1,
    }

    public partial class ucMaintainAttribute : UserControl
    {
        ControlMode controlMode;

        public ucMaintainAttribute()
        {
            InitializeComponent();
        }
    }
}
