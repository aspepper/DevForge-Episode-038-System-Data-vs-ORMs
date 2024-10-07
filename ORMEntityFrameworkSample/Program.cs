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
    }
}