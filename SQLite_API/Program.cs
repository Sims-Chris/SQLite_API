using System;
using System.Data;
using System.Data.SQLite;

namespace SQLite_API_NS
{
    public class SQLite_API{

        private static SQLiteConnection sqlite = main();

        public static SQLiteConnection main(){ 
            
            //----- Get the realtive path of DB -----\\

            string connectionString = Directory.GetCurrentDirectory();

            char targetChar = '\\';

            int count = connectionString.Count(c => c == targetChar);

            int nthOccurrence = count - 3;
            char splitChar = '\\';

            int index = -1;
            for (int i = 0; i < nthOccurrence; i++)
            {
                index = connectionString.IndexOf(splitChar, index + 1);
            }

            string FinalString = connectionString.Substring(0, index);
            
            FinalString += @"\SQLiteDB\Swipe4Work Database.db";

            Console.WriteLine(FinalString);

            return new SQLiteConnection($"Data Source={FinalString}");
        }

        /// <summary>
        /// Executes a SQLite select query and fills a DataTable with the results.
        /// </summary>
        /// <param name="selectQuery">The SQL query to execute.</param>
        /// <returns>A DataTable containing the query result.</returns>
        public static DataTable SelectData(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection(sqlite.ConnectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = query;

                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt); // Fill the DataTable
                        }
                    }
                }
            }
            
            catch (SQLiteException ex)
            {
                Console.WriteLine($"SQLite Error: {ex.Message}");
            }

            return dt;
        }

        /// <summary>
        /// Executes a SQLite update query and modifies the specified table in the database.
        /// </summary>
        /// <param name="query">The SQL update query to execute.</param>
        /// <returns>
        /// A boolean value indicating whether the update operation was successful.
        /// Returns true if rows were updated; otherwise, false.
        /// </returns>
        public static bool updateTable(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(sqlite.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true only if rows were updated
                    }
                }

                catch (SQLiteException ex)
                {
                    Console.WriteLine("SQLite Error: " + ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General Error: " + ex.Message);
                    return false;
                }
            }
        }
    
        
    }
}
