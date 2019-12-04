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

namespace FoodChooser
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Page
    {
        public Options()
        {
            InitializeComponent();
        }

        //Menu buttons
        private void Meal_Selector_Button_Click(object sender, RoutedEventArgs e)
        {
            MealSelectorMain mealSelectorMain = new MealSelectorMain();
            this.NavigationService.Navigate(mealSelectorMain);
        }

        //Main app buttons

        private void Edit_Database_Button_Click(object sender, RoutedEventArgs e)
        {
            if (DatabaseSelectorBox.Text == "")
            {
                System.Windows.MessageBox.Show("Please select a database", "Select database");
            }

            if (DatabaseSelectorBox.Text == "Meal Selector - Fast Food")
            {
                MealSelectorDatabaseViewer datbaseWindow = new MealSelectorDatabaseViewer();
                datbaseWindow.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            About aboutwindow = new About();
            aboutwindow.Show();
        }
    }
}
