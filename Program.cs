using EFCoreDemo.Data;
using EFCoreDemo.Models;
public class Program
{
    public static void Main()
    {
        using var db = new HardwareStoreContext();

        // If we got a database with no tables, we will get an exception
        // This ensures the database is updated with our entities before adding records
        db.Database.EnsureCreated();

        // Add some stuff

        // Since Tools requires a Brand foreign key, we need to start with that first and create a brand
        Brand bosch = new Brand() { Name = "Bosch" };

        db.Brands.Add(bosch);

        db.Tools.Add(new Tool() { ID = 1, Name = "Hammer", Price = 99.9, Brand = bosch });

        db.SaveChanges(); // This is what actually adds the changes to the database

        getAllBrands(db);
        getAllTools(db);
    }

    public static void getAllBrands(HardwareStoreContext db)
    {
        // Go through the tools
        foreach (var b in db.Brands)
        {
            Console.WriteLine($"{b.ID}: {b.Name}");
        }
    }
    public static void getAllTools(HardwareStoreContext db)
    {
        foreach (var t in db.Tools)
        {
            Console.WriteLine($"{t.ID}: {t.Name} - {t.Price} - {t.Brand}");
        }
    }
}