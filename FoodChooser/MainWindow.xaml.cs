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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Meal_Selector_Button_Click(object sender, RoutedEventArgs e)
        {
            MealSelectorMain mealSelectorMain = new MealSelectorMain();
            this.MainProgramArea.Navigate(mealSelectorMain);
        }

        private void Meal_Planner_Button_Click(object sender, RoutedEventArgs e)
        {
            MealPlannerMain mealPlannerMain = new MealPlannerMain();
            this.MainProgramArea.Navigate(mealPlannerMain);
        }

        private void Options_Button_Click(object sender, RoutedEventArgs e)
        {
            Options options = new Options();
            this.MainProgramArea.Navigate(options);
        }

    }
}
