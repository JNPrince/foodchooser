using System;
using System.Data;
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
using System.Windows.Forms;

namespace FoodChooser
{
    /// <summary>
    /// Interaction logic for DatabaseViewer.xaml
    /// </summary>
    public partial class MealSelectorDatabaseViewer : Window
    {


        public MealSelectorDatabaseViewer()
        {
            InitializeComponent();
            MealSelectorDatabaseTools mealselectordatabase = new MealSelectorDatabaseTools();
            MealSelectorDatabaseGrid.DataContext = mealselectordatabase.databaseItems.DefaultView;

            ///Need data binding here somehow

        }


    }
}
