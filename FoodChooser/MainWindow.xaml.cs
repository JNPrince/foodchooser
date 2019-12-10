using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace FoodChooser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class MenuButtonLogic
    {
        public List<Button> menuButtons;

        public MenuButtonLogic()
        {
            menuButtons = new List<Button>();
        }
        public void EnableOtherButtons(string clickedButton)
        {
            foreach (Button button in menuButtons)
            {
                if (button.Name != clickedButton)
                {
                    button.IsEnabled = true;
                }
            }
        }



    }

    public partial class MainWindow : Window
    {

        MenuButtonLogic menuButtonLogic = new MenuButtonLogic();

        public MainWindow()
        {
            InitializeComponent();
            menuButtonLogic.menuButtons.Add(MealSelectorButton);
            menuButtonLogic.menuButtons.Add(MealPlannerButton);
            menuButtonLogic.menuButtons.Add(OptionsButton);

        }

        private void Meal_Selector_Button_Click(object sender, RoutedEventArgs e)
        {
            MealSelectorMain mealSelectorMain = new MealSelectorMain();
            this.MainProgramArea.Navigate(mealSelectorMain);
            MealSelectorButton.IsEnabled = false;
            menuButtonLogic.EnableOtherButtons("MealSelectorButton");

        }

        private void Meal_Planner_Button_Click(object sender, RoutedEventArgs e)
        {
            MealPlannerMain mealPlannerMain = new MealPlannerMain();
            this.MainProgramArea.Navigate(mealPlannerMain);
            MealPlannerButton.IsEnabled = false;
            menuButtonLogic.EnableOtherButtons("MealPlannerButton");
        }

        private void Options_Button_Click(object sender, RoutedEventArgs e)
        {
            Options options = new Options();
            this.MainProgramArea.Navigate(options);
            OptionsButton.IsEnabled = false;
            menuButtonLogic.EnableOtherButtons("OptionsButton");
        }

    }
}
