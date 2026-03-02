using EFCoreDemo.Data;
using EFCoreDemo.Models;
public class Program
{
    public static void Main()
    {
        using var db = new HardwareStoreContext(); // Once we create a new instance of DbContext, everything should be configured

        db.Database.EnsureCreated(); // EFCore ensures tables are created if the database is empty of tables

        foreach (Brand b in db.Brands)
        {
            Console.WriteLine(b.ID);
            Console.WriteLine(b.Name);
        }
    }

}