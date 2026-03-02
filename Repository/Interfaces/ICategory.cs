using EFCoreDemo.Models;

namespace EFCoreDemo.Repository;

public interface ICategory
{
    void addCategory(Category newCategory);
    void addCategories(List<Category> newCategories);
}