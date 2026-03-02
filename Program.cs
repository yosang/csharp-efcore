using System.Text;
using EFCoreDemo.Data;
using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
public class Program
{
    public static void Main()
    {
        using var db = new HardwareStoreContext();

        // If we got a database with no tables, we will get an exception
        // This ensures the database is updated with our entities before adding records
        db.Database.EnsureCreated();

        // Add some stuff

        // Since Tools requires a foreign keys, we need to start with these first
        Brand bosch = new Brand() { Name = "Bosch" };
        Category handTool = new Category() { Name = "Hand tool" };
        Category powerTool = new Category() { Name = "Power tool" };

        db.Brands.Add(bosch);

        db.Tools.Add(new Tool() { ID = 1, Name = "Hammer", Price = 99.99, Brand = bosch, Category = handTool });
        db.Tools.Add(new Tool() { ID = 2, Name = "Drill", Price = 99.99, Brand = bosch, Category = powerTool });

        db.SaveChanges(); // This is what actually adds the changes to the database

        // getAllBrands(db);
        getAllTools(db);

        // getTools(db);
        // getBrands(db);
    }

    public static void getAllBrands(HardwareStoreContext db)
    {
        foreach (var b in db.Brands)
        {
            Console.WriteLine($"{b.ID}: {b.Name}");
        }
    }
    public static void getAllTools(HardwareStoreContext db)
    {
        foreach (var t in db.Tools)
        {
            Console.WriteLine($"{t.ID}: {t.Name} - {t.Price} - {t.Brand} - {t.Category}");
        }
    }

    // Exactly like the other methods but done differently, using Include which includes associations with this Entity

    public static void getBrands(HardwareStoreContext db)
    {
        var brands = db.Brands.Include(t => t.Tools);

        foreach (Brand brand in brands)
        {
            StringBuilder sb = new();
            sb.AppendLine($"{brand.ID}");
            sb.AppendLine($"{brand.Name}");

            if (brand.Tools != null)
            {
                foreach (Tool tool in brand.Tools)
                {
                    sb.AppendLine($"Tools: {tool.ID}, {tool.Name}, {tool.Price}");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
    public static void getTools(HardwareStoreContext db)
    {
        var tools = db.Tools.Include(b => b.Brand);

        foreach (Tool tool in tools)
        {
            StringBuilder sb = new();
            sb.AppendLine($"{tool.ID}");
            sb.AppendLine($"{tool.Name}");
            sb.AppendLine($"{tool.Price}");
            sb.AppendLine($"{tool.Brand?.Name}");
            Console.WriteLine(sb.ToString());
        }
    }
}