using SQLite_API_NS;
using System;
using System.Data;
using System.Data.SQLite;

//----- SELECT -----\\
/*
DataTable table = SQLite_API.SelectData("SELECT * FROM USERS WHERE USERID = 1");

// Iterate through rows
foreach (DataRow row in table.Rows)
{
    Console.WriteLine($"userID: {row["userID"]}, Forename: {row["Forename"]}");
}*/

//----- DELETE -----\\
/*
SQLite_API.updateTable(@"DELETE FROM USERS WHERE UserID = 25");
*/

//----- UPDATE -----\\
/*
SQLite_API.updateTable("UPDATE USERS SET Forename = Greg WHERE USERID = 2 ");
*/