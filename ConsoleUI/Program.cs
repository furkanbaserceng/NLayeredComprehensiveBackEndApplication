﻿

using Business.Concrete;
using DataAccess.Concrete.InMemory;

ProductManager productManager = new ProductManager(new InMemoryProductDal());

foreach (var item in productManager.GetAll())
{

    Console.WriteLine(item.ProductName);
    Console.WriteLine(item.UnitPrice);
    Console.WriteLine(item.UnitsInStock);
    Console.WriteLine("----------------");

}



