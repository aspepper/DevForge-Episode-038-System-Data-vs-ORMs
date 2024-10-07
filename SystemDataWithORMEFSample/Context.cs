using Microsoft.EntityFrameworkCore;

namespace SystemDataWithORMEFSample;

public class Context: DbContext
{
    public DbSet<Customer> Customer { get; set; }

    public string DbPath { get; }

    public Context()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "dbsample-systemData-ORM-EF.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}