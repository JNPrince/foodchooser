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

            DisplayedResult.DataContext = new TextboxText() { textdata = "Make your selections" };
         

        }
                     

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            FoodChooserHome foodChooserHome = new FoodChooserHome();
            this.NavigationService.Navigate(foodChooserHome);
        }



        //Building type selection checkboxes

        private void FastFoodCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.buildingTypeSelections.Add("Fast Food");
        }

        private void FastFoodCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.buildingTypeSelections.Remove("Fast Food");
        }

        private void CoffeeShop_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.buildingTypeSelections.Add("Coffee Shop");
        }

        private void CoffeeShop_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.buildingTypeSelections.Remove("Coffee Shop");
        }

        private void SitDownRestaurant_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.buildingTypeSelections.Add("Sit Down Restaurant");
        }

        private void SitDownRestaurant_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.buildingTypeSelections.Remove("Sit Down Restaurant");
        }

        //Food type selection checkboxes
        private void Burgers_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Add("Burgers");
        }

        private void Burgers_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Remove("Burgers");
        }

        private void Chicken_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Add("Chicken");
        }

        private void Chicken_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Remove("Chicken");
        }

        private void Asian_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Add("Asian");
        }

        private void Asian_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Remove("Asian");
        }

        private void Subs_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Add("Subs");
        }
        private void Subs_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Remove("Subs");
        }

        private void Coffee_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Add("Coffee");
        }

        private void Coffee_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Remove("Coffee");
        }

        private void Mexican_Checked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Add("Mexican");
        }

        private void Mexican_Unchecked(object sender, RoutedEventArgs e)
        {
            mealselector.foodTypeSelections.Remove("Mexican");
        }

        //Bottom buttons
               
        private void Choose_Button_Click(object sender, RoutedEventArgs e)
        {
            mealselector.GetResult();
            string resulttext = mealselector.results;
            DisplayedResult.DataContext = new TextboxText() { textdata = resulttext };
        }

        private void Select_All_Click(object sender, RoutedEventArgs e)
        {
            CoffeeShopCheckbox.IsChecked = true;
            FastFoodCheckbox.IsChecked = true;
            SitDownRestaurantCheckbox.IsChecked = true;
            CoffeeCheckbox.IsChecked = true;
            ChickenCheckbox.IsChecked = true;
            AsianCheckbox.IsChecked = true;
            SubsCheckbox.IsChecked = true;
            BurgersCheckbox.IsChecked = true;
            MexicanCheckbox.IsChecked = true;        

        }

        private void Clear_All_Click(object sender, RoutedEventArgs e)
        {
            CoffeeShopCheckbox.IsChecked = false;
            FastFoodCheckbox.IsChecked = false;
            SitDownRestaurantCheckbox.IsChecked = false;
            CoffeeCheckbox.IsChecked = false;
            ChickenCheckbox.IsChecked = false;
            AsianCheckbox.IsChecked = false;
            SubsCheckbox.IsChecked = false;
            BurgersCheckbox.IsChecked = false;
            MexicanCheckbox.IsChecked = false;
        }

        private void View_Database_Click(object sender, RoutedEventArgs e)
        {
            MealSelectorDatabaseViewer datbaseWindow = new MealSelectorDatabaseViewer();
            datbaseWindow.Show();
        }


        private void Meal_Planner_Button_Click(object sender, RoutedEventArgs e)
        {
            MealPlannerMain mealPlannerMain = new MealPlannerMain();
            this.NavigationService.Navigate(mealPlannerMain);
        }
        
    }




}
