using System;
using System.Data;
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
using System.Windows.Shapes;
using System.ComponentModel;

namespace FoodChooser
{
    /// <summary>
    /// Interaction logic for MealPlannerDatabaseViewer.xaml
    /// </summary>
    public partial class MealPlannerDatabaseViewer : Window
    {

        DatabaseTools mealplannerdatabase = new DatabaseTools() { whichDatabase = "HomeCookedMeals" };
        bool createdNewRow;


        public MealPlannerDatabaseViewer()
        {
            InitializeComponent();
            mealplannerdatabase.loadDatabase(mealplannerdatabase.whichDatabase);
            MealPlannerDatabaseGrid.DataContext = mealplannerdatabase.databaseItems.DefaultView;
            NameTextbox.IsEnabled = false;

        }
        private void MealPlannerDatabaseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NameTextbox.IsEnabled = true;
            createdNewRow = false;
        }

        private void Reload_Button_Click(object sender, RoutedEventArgs e)
        {
            mealplannerdatabase.loadDatabase(mealplannerdatabase.whichDatabase);
            createdNewRow = false;
            MealPlannerDatabaseGrid.SelectedItem = null;
            mealplannerdatabase.dataRemoved = false;
            mealplannerdatabase.removedRows.Clear();
            SaveDatabaseButton.IsEnabled = true;
        }

        private void Add_New_Button_Click(object sender, RoutedEventArgs e)
        {
            NameTextbox.Clear();
            createdNewRow = true;
            NameTextbox.IsEnabled = true;
            AddNewButton.IsEnabled = false;
            RequiredFieldIcon_Name.Visibility = Visibility.Visible;
            SaveDatabaseButton.IsEnabled = false;

        }
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextbox.Text != "")
            {
                try
                {
                    if (createdNewRow == true)
                    {
                        DataRow newRow = mealplannerdatabase.databaseItems.NewRow();
                        newRow["Name"] = NameTextbox.Text;
                        mealplannerdatabase.databaseItems.Rows.Add(newRow);
                        ResultTextBlock.Text = "New item added";
                        MealPlannerDatabaseGrid.SelectedItem = null;
                        NameTextbox.IsEnabled = false;
                        createdNewRow = false;
                        AddNewButton.IsEnabled = true;
                    }
                    else
                    {
                        int userSelectedRow = MealPlannerDatabaseGrid.SelectedIndex;
                        mealplannerdatabase.databaseItems.Rows[userSelectedRow]["Name"] = NameTextbox.Text;
                        ResultTextBlock.Text = "Item updated";
                        MealPlannerDatabaseGrid.SelectedItem = null;
                        NameTextbox.IsEnabled = false;
                        AddNewButton.IsEnabled = true;
                    }
                }
                catch (Exception error)
                {
                    System.Windows.MessageBox.Show(Convert.ToString(error));
                }
                NameTextbox.Clear();
                NameTextbox.IsEnabled = false;
                RequiredFieldIcon_Name.Visibility = Visibility.Hidden;
                SaveDatabaseButton.IsEnabled = true;
                mealplannerdatabase.databaseModified = true;
            }
            else
            {
                System.Windows.MessageBox.Show("Missing a required field or nothing selected", "Missing information");
            }
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            MealPlannerDatabaseGrid.SelectedItem = null;
            createdNewRow = false;
            NameTextbox.Clear();
            NameTextbox.IsEnabled = false;          
            RequiredFieldIcon_Name.Visibility = Visibility.Hidden;
            SaveDatabaseButton.IsEnabled = true;
        }

        private void Save_Database_Button_Click(object sender, RoutedEventArgs e)
        {
            mealplannerdatabase.saveDatabase(mealplannerdatabase.whichDatabase);
            if (mealplannerdatabase.successfulSave == true)
            {
                ResultTextBlock.Text = "Database write success";
                mealplannerdatabase.successfulSave = null;
                MealPlannerDatabaseGrid.SelectedItem = null;

            }
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
                mealplannerdatabase.dataRemoved = true;
                int index = MealPlannerDatabaseGrid.SelectedIndex;
                DataRow deletedRow = mealplannerdatabase.databaseItems.Rows[index];
                mealplannerdatabase.removedRows.Add("'" + Convert.ToString(deletedRow[0]) + "'");
                mealplannerdatabase.databaseItems.Rows.Remove(deletedRow);
                MealPlannerDatabaseGrid.SelectedItem = null;
                NameTextbox.Clear();
                NameTextbox.IsEnabled = false;
            }
            catch (System.IndexOutOfRangeException)
            {
                System.Windows.MessageBox.Show("You need to select a row to delete", "Error");
            }
        }


    }


}

