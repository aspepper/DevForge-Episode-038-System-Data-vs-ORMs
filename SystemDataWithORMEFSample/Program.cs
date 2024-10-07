using Microsoft.Data.Sqlite;

namespace SystemDataWithORMEFSample;

internal class Program
{
    private static void Main(string[] args)
    {
        using var context = new Context();
        List<Customer> customerList = [.. context.Customer];

        Console.WriteLine("Records read by ORM EF Core");
        foreach (var customer in customerList)
        {
            Console.WriteLine($"Id: {customer.Id}, Nome: {customer.Name}");
        }

        var folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        string dbPath = Path.Join(path, "dbsample-systemData-ORM-EF.db");
        var dbConnection = new SqliteConnection("Data Source=" + dbPath); // Linux and Mac OS
        // var dbConnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;"); // Windows

        string consultaSQL = "SELECT Id, Name FROM Customer";

        SqliteCommand comando = new(consultaSQL, dbConnection); // Linux and Mac OS
        // SQLiteCommand comando = new(consultaSQL, dbConnection); // Windows
        dbConnection.Open();

        SqliteDataReader leitor = comando.ExecuteReader(); // Linux and Mac OS
        // SQLiteDataReader leitor = comando.ExecuteReader(); // Windows

        Console.WriteLine("Records read by System.Data ou Microsoft.Data");
        while (leitor.Read())
        {
            Console.WriteLine($"Id: {leitor["Id"]}, Name: {leitor["Name"]}");
        }

        dbConnection.Close();
        dbConnection.Dispose();
    }
}