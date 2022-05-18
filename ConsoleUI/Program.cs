

using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

IProductService _productService = new ProductManager(new InMemoryProductDal());

foreach (var product in _productService.GetAll())
{

    Console.WriteLine(product.ProductName);
    Console.WriteLine(product.UnitPrice);
    Console.WriteLine(product.UnitsInStock);
    Console.WriteLine("----------------");

}

ICategoryService _categoryService=new CategoryManager(new InMemoryCategoryDal());

foreach (var category in _categoryService.GetAll())
{
    Console.WriteLine(category.CategoryName);
}



