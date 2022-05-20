

using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

IProductService _productService = new ProductManager(new EfProductDal());

//foreach (var product in _productService.GetAll())
//{

//    Console.WriteLine(product.ProductName);
//    Console.WriteLine(product.UnitPrice);
//    Console.WriteLine(product.UnitsInStock);
//    Console.WriteLine("----------------");

//}

//foreach (var product in _productService.GetAllByCategoryId(2))
//{
//    Console.WriteLine(product.ProductName);
//}
//Console.WriteLine("------------------------------");
//foreach (var product in _productService.GetByUnitPrice(5, 10))
//{
//    Console.WriteLine(product.ProductName);
//}

ICategoryService _categoryService=new CategoryManager(new EfCategoryDal());

//foreach (var category in _categoryService.GetAll())
//{
//    Console.WriteLine(category.CategoryName);
//}

//Console.WriteLine("------------------------");
//foreach (var productDTO in _productService.GetProductDetails())
//{

//    Console.WriteLine(productDTO.ProductName+"-->"+productDTO.CategoryName);

//}


var result = _productService.GetProductDetails();

if (result.Success)
{
    foreach (var productDto in result.Data)
    {
        Console.WriteLine(productDto.ProductName+"-->"+productDto.CategoryName);
    }

}
else
{
    Console.WriteLine(result.Message);
}