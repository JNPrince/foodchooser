using System;
using System.Data;
using System.Collections;
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
using System.Windows.Forms;

namespace FoodChooser
{
    /// <summary>
    /// Interaction logic for DatabaseViewer.xaml
    /// </summary>
    /// 
        
    public partial class MealSelectorDatabaseViewer : Window
    {
        //bindingDatabase database = new bindingDatabase();
        MealSelectorDatabaseTools mealselectordatabase = new MealSelectorDatabaseTools();
        


        public MealSelectorDatabaseViewer()
        {
            InitializeComponent();
            MealSelectorDatabaseGrid.DataContext = mealselectordatabase.databaseItems.DefaultView;
        }

        private void Reload_Button_Click(object sender, RoutedEventArgs e)
        {
            mealselectordatabase.loadDatabase();
        }

        private void Add_New_Button_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = mealselectordatabase.databaseItems.NewRow();
            newRow["Name"] = "NEW_NAME";
            newRow["Building"] = "NEW_BUILDING";
            newRow["Food"] = "NEW_FOOD";
            mealselectordatabase.databaseItems.Rows.Add(newRow);
        }

        private void Save_Database_Button_Click(object sender, RoutedEventArgs e)
        {
            mealselectordatabase.saveDatabase();
        }

        private void Exit_NoSave_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_Row_Button_Click(object sender, RoutedEventArgs e)
        {
            //Fix this, doesn't remove rows when saving back to database for some reason
            int index = MealSelectorDatabaseGrid.SelectedIndex;
            DataRow deletedRow = mealselectordatabase.databaseItems.Rows[index];
            mealselectordatabase.databaseItems.Rows.Remove(deletedRow);
        }
    }
}
