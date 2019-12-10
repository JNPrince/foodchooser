using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace FoodChooser
{
    /// <summary>
    /// Interaction logic for MealPlanner.xaml
    /// </summary>
    /// 

    public partial class MealPlannerMain : Page
    {
        MealPlanner mealplanner = new MealPlanner();


        public MealPlannerMain()
        {
            InitializeComponent();
            this.ShowsNavigationUI = false;

            MealOptionsBox.ItemsSource = mealplanner.mealOptions;
            mealplanner.dayResults = new List<TextBlock> 
            { 
                SundayResultBox, MondayResultBox, TuesdayResultBox, WednesdayResultBox, ThursdayResultBox, FridayResultBox, SaturdayResultBox 
            };
            for (int day = mealplanner.dayResults.Count() - 1; day >= 0 ; day-- )
            {
                mealplanner.dayResults[day].Text = "None";
            }
        }
        private void Select_All_Button_Click(object sender, RoutedEventArgs e)
        {
            MealOptionsBox.Focus();
            MealOptionsBox.SelectAll();
        }

        private void Select_None_Button_Click(object sender, RoutedEventArgs e)
        {
            MealOptionsBox.UnselectAll();
        }
        private void Generate_Button_Click(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedOptions = new List<string>(MealOptionsBox.SelectedItems.Cast<string>().ToList());

            if (mealplanner.selectedOptions.Count < mealplanner.selectedDays.Count(b => b))
            {
                System.Windows.MessageBox.Show("Not enough meal options selected. Select more options or less days to schedule.", "Not enough selections");
            }

            else
            {
                mealplanner.generateSchedule();
            }
            
        }

        private void SundayCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[0] = true;
        }

        private void MondayCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[1] = true;
        }

        private void TuesdayCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[2] = true;
        }

        private void WednesdayCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[3] = true;
        }

        private void ThursdayCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[4] = true;
        }

        private void FridayCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[5] = true;
        }

        private void SaturdayCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[6] = true;
        }
        private void SundayCheckbox_UnChecked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[0] = false;
        }

        private void MondayCheckbox_UnChecked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[1] = false;
        }

        private void TuesdayCheckbox_UnChecked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[2] = false;
        }

        private void WednesdayCheckbox_UnChecked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[3] = false;
        }

        private void ThursdayCheckbox_UnChecked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[4] = false;
        }

        private void FridayCheckbox_UnChecked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[5] = false;
        }

        private void SaturdayCheckbox_UnChecked(object sender, RoutedEventArgs e)
        {
            mealplanner.selectedDays[6] = false;
        }

    }
}
