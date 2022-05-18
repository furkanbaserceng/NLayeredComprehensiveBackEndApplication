using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        /// <summary>
        /// Burada, veri tabanında çalışmayıp bellek üzerinde veri varmış gibi
        /// fake veriler oluşturup çalışmalar yapacağım.
        /// Class içi global _products oluşturdum.
        /// InMemoryProductDal çağrıldığı anda constructorunda fake product ürünleri oluşturacak.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product
                {
                    ProductId=1,
                    CategoryId=1,
                    ProductName="Laptop",
                    UnitsInStock=500,
                    UnitPrice=17000
                },
                new Product
                {
                    ProductId=2,
                    CategoryId=1,
                    ProductName="Camera",
                    UnitsInStock=300,
                    UnitPrice=9600
                },
                new Product
                {
                    ProductId=3,
                    CategoryId=2,
                    ProductName="Chair",
                    UnitsInStock=1300,
                    UnitPrice=120
                },
                new Product
                {
                    ProductId=4,
                    CategoryId=3,
                    ProductName="Book",
                    UnitsInStock=250,
                    UnitPrice=560
                }
            };
        }
        


        public List<Product> GetAll()
        {
            return _products;
        }

        /// <summary>
        /// Where() ile dönen sonuç IEnumerable tipinde olduğundan, sonucu listeye çevirmek gerekir.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Product> GetByCategoryId(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }


        public void Add(Product product)
        {
            _products.Add(product);
        }

        /// <summary>
        /// Güncellenmek istenen referansı yakalayıp productToUpdate nesnesine aktardım.
        /// Sonrasında güncellenecek değerleri gelen product nesnesiyle eşleştirdim.
        /// </summary>
        /// <param name="product"></param>
        public void Update(Product product)
        {

            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        /// <summary>
        /// Direkt _products.Remove(product) diyemeyiz.Referans tiplerle çalıştığımız için,
        /// gelen productın ProductId si yakalanmalı ve referans üzerinden silinmeli.
        /// Bu yüzden LINQ yapısını kullanarak PrimaryKey üzerinden ProductId yakalandı.
        /// SingleOrDefault metodu ile _products listesi dönüldü ve eşleşme yakalanırsa silme işlemi gerçekleşecek.
        /// </summary>
        /// <param name="product"></param>
        public void Delete(Product product)
        {
            
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        
    }
}
