using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace FoodChooser
{
    /// <summary>
    /// Interaction logic for DatabaseViewer.xaml
    /// </summary>
    /// 
        
    public partial class MealSelectorDatabaseViewer : Window
    {

        DatabaseTools mealselectordatabase = new DatabaseTools() { whichDatabase = "MealSelector" };
        bool createdNewRow;

        public void deSelect()
        {
            MealSelectorDatabaseGrid.SelectedItem = null;
            MealSelectorDatabaseGrid.IsEnabled = true;
            NameTextbox.IsEnabled = false;
            FoodTypeTextbox.IsEnabled = false;
            BuildingTypeTextbox.IsEnabled = false;
            NameTextbox.Clear();
            BuildingTypeTextbox.SelectedIndex = -1;
            FoodTypeTextbox.SelectedIndex = -1;
            RequiredFieldIcon_Name.Visibility = Visibility.Hidden;
            RequiredFieldIcon_BuildingType.Visibility = Visibility.Hidden;
            RequiredFieldIcon_FoodType.Visibility = Visibility.Hidden;
            SaveDatabaseButton.IsEnabled = true;
            AddNewButton.IsEnabled = true;
            DeleteRowButton.IsEnabled = true;
        }


        public MealSelectorDatabaseViewer()
        {
            InitializeComponent();
            mealselectordatabase.loadDatabase(mealselectordatabase.whichDatabase);
            MealSelectorDatabaseGrid.DataContext = mealselectordatabase.databaseItems.DefaultView;
            NameTextbox.IsEnabled = false;
            FoodTypeTextbox.IsEnabled = false;
            BuildingTypeTextbox.IsEnabled = false;
        }
        private void MealSelectorDatabaseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NameTextbox.IsEnabled = true;
            FoodTypeTextbox.IsEnabled = true;
            BuildingTypeTextbox.IsEnabled = true;
        }

        private void Reload_Button_Click(object sender, RoutedEventArgs e)
        {
            MealSelectorDatabaseGrid.IsEnabled = true;
            mealselectordatabase.loadDatabase(mealselectordatabase.whichDatabase);
            createdNewRow = false;
            MealSelectorDatabaseGrid.SelectedItem = null;
            mealselectordatabase.dataRemoved = false;
            mealselectordatabase.removedRows.Clear();
            deSelect();
        }

        private void Add_New_Button_Click(object sender, RoutedEventArgs e)
        {
            deSelect();
            MealSelectorDatabaseGrid.IsEnabled = false;
            createdNewRow = true;
            NameTextbox.IsEnabled = true;
            FoodTypeTextbox.IsEnabled = true;
            BuildingTypeTextbox.IsEnabled = true;
            AddNewButton.IsEnabled = false;
            RequiredFieldIcon_Name.Visibility = Visibility.Visible;
            RequiredFieldIcon_BuildingType.Visibility = Visibility.Visible;
            RequiredFieldIcon_FoodType.Visibility = Visibility.Visible;
            SaveDatabaseButton.IsEnabled = false;
            DeleteRowButton.IsEnabled = false;
        }
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextbox.Text != "" && BuildingTypeTextbox.Text != "" && FoodTypeTextbox.Text != "")
            {
                bool containsLettersorNumbersCheck = Regex.IsMatch(NameTextbox.Text, @"[^a - zA - Z0 - 9\s']");
                if (containsLettersorNumbersCheck == true)
                {
                    try
                    {
                        if (createdNewRow == true)
                        {
                            DataRow newRow = mealselectordatabase.databaseItems.NewRow();
                            newRow["Name"] = NameTextbox.Text;
                            newRow["Building"] = BuildingTypeTextbox.Text;
                            newRow["Food"] = FoodTypeTextbox.Text;
                            mealselectordatabase.databaseItems.Rows.Add(newRow);
                            ResultTextBlock.Text = "New item added";
                            createdNewRow = false;
                        }
                        else
                        {
                            int userSelectedRow = MealSelectorDatabaseGrid.SelectedIndex;
                            mealselectordatabase.databaseItems.Rows[userSelectedRow]["Name"] = NameTextbox.Text;
                            mealselectordatabase.databaseItems.Rows[userSelectedRow]["Building"] = BuildingTypeTextbox.Text;
                            mealselectordatabase.databaseItems.Rows[userSelectedRow]["Food"] = FoodTypeTextbox.Text;
                            ResultTextBlock.Text = "Item updated";
                        }
                        deSelect();

                    }
                    catch (Exception error)
                    {
                        System.Windows.MessageBox.Show(Convert.ToString(error));
                    }
                    
                    mealselectordatabase.databaseModified = true;
                }
                else
                {
                    System.Windows.MessageBox.Show("Invalid Name field, name must contain only letter or numbers or apostophe, and not be blank.", "Invalid name");
                }

            }       

            else
            {
                System.Windows.MessageBox.Show("Missing a required field or nothing selected", "Missing information");
            }
            
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            deSelect();
        }

        private void Save_Database_Button_Click(object sender, RoutedEventArgs e)
        {
            mealselectordatabase.saveDatabase(mealselectordatabase.whichDatabase);
            if (mealselectordatabase.successfulSave == true)
            {
                ResultTextBlock.Text = "Database write success";
                mealselectordatabase.successfulSave = null;
                MealSelectorDatabaseGrid.SelectedItem = null;
            }
            deSelect();
        }

        private void Exit_NoSave_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult exitnosaveprompt = MessageBox.Show("Are you sure you want to exit? The database will not be saved.", "Confirmation", MessageBoxButton.YesNo);
            switch (exitnosaveprompt)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Delete_Row_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mealselectordatabase.dataRemoved = true;
                int index = MealSelectorDatabaseGrid.SelectedIndex;
                DataRow deletedRow = mealselectordatabase.databaseItems.Rows[index];
                mealselectordatabase.removedRows.Add("'" + Convert.ToString(deletedRow[0]) + "'");
                mealselectordatabase.databaseItems.Rows.Remove(deletedRow);
                deSelect();
            }
            catch (System.IndexOutOfRangeException)
            {
                System.Windows.MessageBox.Show("You need to select a row to delete", "Error");
            }
        }


    }
}
