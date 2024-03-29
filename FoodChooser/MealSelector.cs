﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;

namespace FoodChooser
{
    class MealSelector
    {


        public List<string> buildingTypeSelections { get; set; }
        public List<string> foodTypeSelections { get; set; }

        private HashSet<string> _results { get; set; }

        public MealSelector()
        {
            buildingTypeSelections = new List<string>();
            foodTypeSelections = new List<string>();

            _results = new HashSet<string>();
        }

        public string results
        {
            get
            {
                bool isResultsEmpty = !_results.Any();
                if (isResultsEmpty == false)
                {
                    Random random = new Random();
                    int randomIndex = random.Next(_results.Count);
                    List<string> _resultsList = _results.ToList();
                    return _resultsList[randomIndex];
                }
                else
                {
                    return "You haven't selected any items";
                }
            }
        }


        public void GetResult()
        {
            _results.Clear();

            bool isBuildingListEmpty = !buildingTypeSelections.Any();
            bool isFoodTypeListEmpty = !foodTypeSelections.Any();
            bool isResultsListEmpty = false;


            if (isBuildingListEmpty == false && isFoodTypeListEmpty == false)
            {
                try
                {
                    SQLiteConnection maindatabase = new SQLiteConnection("DataSource=maindatabase.db; Version=3;");
                    maindatabase.Open();


                    foreach (string building in buildingTypeSelections)
                    {
                        foreach (string foodtype in foodTypeSelections)
                        {
                            string sqlCommandString = $"SELECT Name FROM MealSelector WHERE Building = '{building}' AND Food = '{foodtype}'";
                            SQLiteCommand command = new SQLiteCommand(sqlCommandString, maindatabase);
                            SQLiteDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                _results.Add(reader["Name"].ToString());
                            }
                        }
                    }

                    isResultsListEmpty = !_results.Any();

                    if (isResultsListEmpty == true)
                    {
                        _results.Add("No results, try another selection");
                    }
                }
                catch (Exception error)
                {
                    System.Windows.MessageBox.Show(Convert.ToString(error));
                }
            }

            else
            {
                _results.Add("You are missing a selection.");
            }
        }

    }


}


