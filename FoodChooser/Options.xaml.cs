using System.Windows;
using System.Windows.Controls;


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

            if (DatabaseSelectorBox.Text == "Meal Selector")
            {
                MealSelectorDatabaseViewer databaseWindow = new MealSelectorDatabaseViewer();
                databaseWindow.Show();
            }
            if (DatabaseSelectorBox.Text == "Meal Planner - Home Cooked")
            {
                MealPlannerDatabaseViewer databaseWindow = new MealPlannerDatabaseViewer();
                databaseWindow.Show();
            }

        }

        private void About_Button_Click(object sender, RoutedEventArgs e)
        {
            About aboutwindow = new About();
            aboutwindow.Show();
        }


    }
}
