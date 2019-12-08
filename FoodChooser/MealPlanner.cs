using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Controls;

namespace FoodChooser
{
    class MealPlanner
    {
        public List<string> mealOptions { get; }
        public List<bool> selectedDays;
        public List<TextBlock> dayResults;
        public List<string> selectedOptions;

        public MealPlanner()
        {
            mealOptions = new List<string>();
            selectedDays = new List<bool>() { true, true, true, true, true, true, true };
            loadMealList();
        }

        public void loadMealList()
        {
            SQLiteConnection maindatabase = new SQLiteConnection("DataSource=maindatabase.db; Version=3;");
            maindatabase.Open();
            string sqlCommandString = "SELECT Name from HomeCookedMeals";
            SQLiteCommand command = new SQLiteCommand(sqlCommandString, maindatabase);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                mealOptions.Add(reader["Name"].ToString());
            }
        }

        public void generateSchedule()
        {
            int currentIteration = 0;
            foreach (bool selectedDay in selectedDays)
            {

                if (selectedDay == true)
                {
                    Random random = new Random();
                    int randomIndex = random.Next(selectedOptions.Count);
                    string currentMeal = selectedOptions[randomIndex];
                    dayResults[currentIteration].Text = currentMeal;
                    selectedOptions.Remove(currentMeal);
                }
                else if (selectedDay == false)
                {
                    dayResults[currentIteration].Text = "None";
                }
                currentIteration++;
            }
        }
    }
}
