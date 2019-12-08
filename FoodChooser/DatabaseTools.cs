using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FoodChooser
{

    class DatabaseTools
    {

        public string whichDatabase;
        public DataTable databaseItems = new DataTable();
        public bool dataRemoved;
        public List<string> removedRows;
        public bool? successfulSave;
        public bool? databaseModified;

        public DatabaseTools()
        {
            removedRows = new List<string>();
            successfulSave = null;            
        }

        public void loadDatabase(string whichDatabase)
        {
            try
            {
                databaseItems.Clear();
                SQLiteConnection maindatabase = new SQLiteConnection("DataSource=maindatabase.db; Version=3;");
                maindatabase.Open();
                string sqlCommandString = $"SELECT * FROM {whichDatabase}";
                SQLiteCommand command = new SQLiteCommand(sqlCommandString, maindatabase);
                SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                databaseItems.Load(reader);
            }
            catch (Exception error)
            {
                System.Windows.MessageBox.Show(Convert.ToString(error));
            }

            dataRemoved = false;
            removedRows.Clear();

        }


        public void saveDatabase(string whichDatabase)
        {

            try
            {
                SQLiteConnection maindatabase = new SQLiteConnection("DataSource=maindatabase.db; Version=3;");
                maindatabase.Open();
                SQLiteCommand sqlCommand = maindatabase.CreateCommand();

                //Add new entries

                sqlCommand.CommandText = $"SELECT * from {databaseItems}";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlCommand);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
                adapter.Update(databaseItems);

                if (dataRemoved == true)
                {

                    string removedRowsString = string.Join(", ", removedRows);

                    //Remove deleted entries
                    sqlCommand.CommandText = $"DELETE FROM {whichDatabase} WHERE Name IN ({removedRowsString})";
                    sqlCommand.ExecuteNonQuery();


                }
                maindatabase.Close();
                successfulSave = true;

            }
            catch (Exception error)
            {
                System.Windows.MessageBox.Show(Convert.ToString(error));
            }


        }


    }
}
