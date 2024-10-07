using Microsoft.Data.Sqlite;

namespace ORMEntityFrameworkSample;

class Program
{
    static void Main()
    {
        using var context = new Context();
        List<Customer> customerList = [.. context.Customer];

        foreach (var customer in customerList)
        {
            Console.WriteLine($"Id: {customer.Id}, Nome: {customer.Name}");
        }

        var folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        string dbPath = Path.Join(path, "dbsample-systemData.db");
        var dbConnection = new SqliteConnection("Data Source=" + dbPath); // Linux and Mac OS
        // var dbConnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;"); // Windows

        if (!File.Exists(dbPath))
        {
            // SQLiteConnection.CreateFile(dbPath);  // Windows

            string sql = "Create Table Customer (Id int, Name varchar(50))";
            dbConnection.Open();
            SqliteCommand command = new(sql, dbConnection); // Linux and Mac OS
            // SQLiteCommand command = new(sql, dbConnection); // Windows
            command.ExecuteNonQuery();

            sql = "Insert into Customer (Id, Name) values (1, 'Alex Pimenta')";
            command = new(sql, dbConnection); // Linux and Mac OS
            // command = new(sql, dbConnection); // Windows
            command.ExecuteNonQuery();

            sql = "Insert into Customer (Id, Name) values (1, 'Arthur Gregorio Pimenta')";
            command = new(sql, dbConnection); // Linux and Mac OS
            // command = new(sql, dbConnection); // Windows
            dbConnection.Close();
        }

        string consultaSQL = "SELECT Id, Name FROM Customer";

        SqliteCommand comando = new(consultaSQL, dbConnection); // Linux and Mac OS
        // SQLiteCommand comando = new(consultaSQL, dbConnection); // Windows
        dbConnection.Open();

        SqliteDataReader leitor = comando.ExecuteReader(); // Linux and Mac OS
        // SQLiteDataReader leitor = comando.ExecuteReader(); // Windows

        while (leitor.Read())
        {
            Console.WriteLine($"Id: {leitor["Id"]}, Name: {leitor["Name"]}");
        }

        dbConnection.Close();
        dbConnection.Dispose();        
    }
}