using System.Text;
using EFCoreDemo.Data;
using EFCoreDemo.Models;
using EFCoreDemo.Repository;
using Microsoft.EntityFrameworkCore;
public class Program
{
    public static void Main()
    {
        BrandRepository brandRepo = new BrandRepository();
        CategoryRepository categoryRepo = new CategoryRepository();
        ToolRepository toolRepo = new ToolRepository();

        brandRepo.seedDefaultBrands();
        categoryRepo.seedDefaultCategories();

        toolRepo.addTools(new List<Tool>()
        {
            new Tool() { ID=Guid.NewGuid().ToString(), Name = "Hammer", Price = 99.9, BrandID = 1, CategoryID = 1},
            new Tool() { ID=Guid.NewGuid().ToString(), Name = "Drill", Price = 99.9, BrandID = 1, CategoryID = 2},
        });

    }

}