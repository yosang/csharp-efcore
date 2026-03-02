using EFCoreDemo.Models;

namespace EFCoreDemo.Repository;

public interface IBrand
{
    void addBrand(Brand newBrand);
    void addBrands(List<Brand> newBrands);
}