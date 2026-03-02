using EFCoreDemo.Repository;
using EFCoreDemo.Models;
using EFCoreDemo.Data;
public class CategoryRepository : ICategory
{
    public void seedDefaultCategories()
    {
        using var db = new HardwareStoreContext();
        db.Database.EnsureCreated();

        string[] defaultCategories = new[] { "Hand Tool", "Power Tools" };

        bool altered = false;

        foreach (string name in defaultCategories)
        {
            if (!db.Categories.Any(e => e.Name == name))
            {
                db.Categories.Add(new Category { Name = name });
                altered = true;
            }
        }

        if (altered) db.SaveChanges();
    }
    public void addCategory(Category newCategory)
    {
        using var db = new HardwareStoreContext();
        db.Database.EnsureCreated();
        db.Categories.Add(newCategory);
        db.SaveChanges();
    }

    public void addCategories(List<Category> newCategories)
    {
        using var db = new HardwareStoreContext();
        db.Database.EnsureCreated();
        db.Categories.AddRange(newCategories);
        db.SaveChanges();
    }

    public Category getCategoryById(int id)
    {
        using var db = new HardwareStoreContext();

        Category? category = db.Categories.Find(id);

        return category;
    }
}