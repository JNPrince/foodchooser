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
        public MealSelectorMain()
        {
            InitializeComponent();
            DisplayedResult.DataContext = new TextboxText() {textdata = "This is the result" };

            string newtext = "THE RULES HAVE CHANGED";
            DisplayedResult.DataContext = new TextboxText() { textdata = newtext };



        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            FoodChooserHome foodChooserHome = new FoodChooserHome();
            this.NavigationService.Navigate(foodChooserHome);
        }

        
        
    }




}
