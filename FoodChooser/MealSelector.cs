using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FoodChooser
{
    class MealSelector
    {

        public List<string> selections { get; set; }
        public MealSelector()
        {
            selections = new List<string>();
        }

        public void GetResult()
        {
            SQLiteConnection maindatabase = new SQLiteConnection("DataSource=maindatabase.db; Version=3;");
            maindatabase.Open();
            //string sql = "SELECT  FROM MealSelector";
            //Code to get the results below
        }



    }
}
