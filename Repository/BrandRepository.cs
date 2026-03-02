using EFCoreDemo.Repository;
using EFCoreDemo.Models;
using EFCoreDemo.Data;
public class BrandRepository : IBrand
{
    public void seedDefaultBrands()
    {
        using var db = new HardwareStoreContext();
        db.Database.EnsureCreated();

        string[] defaultBrands = new[] { "Bosch", "Samsung" };

        bool altered = false;

        foreach (string name in defaultBrands)
        {
            if (!db.Brands.Any(e => e.Name == name))
            {
                db.Brands.Add(new Brand { Name = name });
                altered = true;
            }
        }

        if (altered) db.SaveChanges();
    }
    public void addBrand(Brand newBrand)
    {
        using var db = new HardwareStoreContext();
        db.Database.EnsureCreated();

        db.Brands.Add(newBrand);
        db.SaveChanges();
    }

    public void addBrands(List<Brand> newBrands)
    {
        using var db = new HardwareStoreContext();
        db.Database.EnsureCreated();
        db.Brands.AddRange(newBrands);
        db.SaveChanges();
    }

    public Brand getBrandById(int id)
    {
        using var db = new HardwareStoreContext();

        Brand? brand = db.Brands.Find(id);

        return brand;
    }
}