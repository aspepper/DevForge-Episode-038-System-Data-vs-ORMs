// Optimized Library for Cross-Platform Data Access intead System.Data
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

        // Example adding a new record
        /* Customer c = new()
        {
            Id = 4,
            Name = "New User"
        };
        context.Add(c);
        context.SaveChanges();
        Console.WriteLine("Record 4 inserted by EF Core"); */

        // Example updating record Id 4
        /* var c = context.Customer.Where(d => d.Id == 4).First();
        c.Name = "New User Updated";
        context.SaveChanges();
        Console.WriteLine("Record 4 updated by EF Core"); */

        // Example deleting record Id 4
        /* var c = context.Customer.FirstOrDefault(c => c.Id == 4);
        if (c != null)
        {
            context.Customer.Attach(c);
            context.Customer.Remove(c);
            context.SaveChanges();
        }
        Console.WriteLine("Record 4 deleted by EF Core"); */

        // Another example deleting record Id 4
        /* var c = context.Customer.FirstOrDefault(c => c.Id == 4);
        if (c != null)
        {
            context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
        }
        Console.WriteLine("Record 4 deleted by EF Core"); */

        /******************************************************************** 
        Environment.SpecialFolder.LocalApplicationData = 
        Special Data Folder 
            in Windows: c:\Users\<username>\AppData\
            in MacOS: /Users/alexpimenta/Library/Application Support/
        ********************************************************************/
        var folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        string dbPath = Path.Join(path, "dbsample-systemData-ORM-EF.db");
        var dbConnection = new SqliteConnection("Data Source=" + dbPath);

        string consultaSQL = "SELECT Id, Name FROM Customer";

        SqliteCommand comando = new(consultaSQL, dbConnection);
        dbConnection.Open();

        SqliteDataReader leitor = comando.ExecuteReader();

        Console.WriteLine(" ");
        Console.WriteLine("Records read by System.Data ou Microsoft.Data");
        while (leitor.Read())
        {
            Console.WriteLine($"Id: {leitor["Id"]}, Name: {leitor["Name"]}");
        }

        dbConnection.Close();
        dbConnection.Dispose();
    }
}