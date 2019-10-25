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

    public class TextboxText
    {
        public string textdata { get; set; }
    }

    /// <summary>
    /// Interaction logic for MealSelectorMain.xaml
    /// </summary>
    public partial class MealSelectorMain : Page
    {

        MealSelector mealselector = new MealSelector();

        public MealSelectorMain()
        {
            InitializeComponent();

            

            //HOW TO MAKE THE TEXT BOX DO THE TEXT

            // DisplayedResult.DataContext = new TextboxText() {textdata = "This is the result" };
            // string newtext = "THE RULES HAVE CHANGED";
            // DisplayedResult.DataContext = new TextboxText() { textdata = newtext };

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            FoodChooserHome foodChooserHome = new FoodChooserHome();
            this.NavigationService.Navigate(foodChooserHome);
        }

        private void FastFoodCheckBox_Checked (object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("Fast Food");
        }

        private void FastFoodCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("Fast Food");
        }

        private void CoffeeShop_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("Coffee Shop");
        }

        private void CoffeeShop_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("Coffee Shop");
        }

        private void SitDownRestaurant_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("Sit Down Restaurant");
        }

        private void SitDownRestaurant_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("Sit Down Restaurant");
        }

        private void Burgers_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("Burgers");
        }

        private void Burgers_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("Burgers");
        }

        private void Chicken_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("Chicken");
        }

        private void Chicken_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("Chicken");
        }

        private void Asian_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("Asian");
        }

        private void Asian_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("Asian");
        }

        private void Subs_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("Subs");
        }
        private void Subs_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("Subs");
        }

        private void Coffee_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("Coffee");
        }

        private void Coffee_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("Coffee");
        }

        private void Mexican_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("Mexican");
        }

        private void Mexican_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("Mexican");
        }

        private void Dollar_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("$");
        }
        private void Dollar_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("$");
        }

        private void DollarDollar_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("$$");
        }

        private void DollarDollar_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("$$");
        }

        private void DollarDollarDollar_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Add("$$$");
        }
        private void DollarDollarDollar_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.selections.Remove("$$$");
        }


               
        private void Choose_Button_Click(object sender, RoutedEventArgs e)
        {
            string resulttext = string.Join(", ", mealselector.selections );
            DisplayedResult.DataContext = new TextboxText() { textdata = resulttext };
        }


    }




}
