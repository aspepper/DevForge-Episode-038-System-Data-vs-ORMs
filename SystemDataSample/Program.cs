using Microsoft.Data.Sqlite; //Optimized Library for Cross-Platform Data Access intead System.Data

namespace SystemDataSample;

internal class Program
{
    private static void Main(string[] args)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        string dbPath = Path.Join(path, "dbsample-systemData.db");
        var dbConnection = new SqliteConnection("Data Source=" + dbPath);

        if (!File.Exists(dbPath))
        {
            string sql = "Create Table Customer (Id int, Name varchar(50))";
            dbConnection.Open();
            SqliteCommand command = new(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "Insert into Customer (Id, Name) values (1, 'Alex Pimenta')";
            command = new(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "Insert into Customer (Id, Name) values (2, 'Arthur Gregorio Pimenta')";
            command = new(sql, dbConnection);
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        string consultaSQL = "SELECT Id, Name FROM Customer";

        SqliteCommand comando = new(consultaSQL, dbConnection);
        dbConnection.Open();

        SqliteDataReader leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            Console.WriteLine($"Id: {leitor["Id"]}, Name: {leitor["Name"]}");
        }

        dbConnection.Close();
        dbConnection.Dispose();
    }
}