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
    /// Interaction logic for FoodChooser.xaml
    /// </summary>
    public partial class FoodChooserHome : Page
    {
        public FoodChooserHome()
        {
            InitializeComponent();
        }

        private void Meal_Selector_Button_Click(object sender, RoutedEventArgs e)
        {
            //Open Meal Selector on click
            MealSelectorMain mealSelectorMain = new MealSelectorMain();
            this.NavigationService.Navigate(mealSelectorMain);

        }
    }
    }

