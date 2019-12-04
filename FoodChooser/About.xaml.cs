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
using System.Windows.Shapes;

namespace FoodChooser
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {

        public About()
        {
            InitializeComponent();
            versionNumberBox.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //versionNumberBox.Text = "v" + Convert.ToString(version.versionNumber);
        }


    }
}
