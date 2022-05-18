using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    /// <summary>
    /// Product nesnesi ile yapılacak CRUD işlemlerinin yapılacağı şablon interface.
    /// </summary>
    public interface IProductDal
    {
        /// <summary>
        /// Tüm ürünleri listeleyecek metod şablonu.
        /// Product classı, Entities katmanından geleceği için Entities'e referans verdim.
        /// </summary>
        /// <returns>Generic List tipinde tüm Product nesnelerini döndürecek.</returns>
        List<Product> GetAll();

        /// <summary>
        /// Ürünleri, kategorilerine göre listeleyecek metod şablonu.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        List<Product> GetByCategoryId(int categoryId);

        /// <summary>
        /// Parametre olarak gelen product nesnesini veritabanına ekleyecek metod şablonu.
        /// </summary>
        /// <param name="product"></param>
        void Add(Product product);

        /// <summary>
        /// Parametre olarak gelen product nesnesini güncelleyip, veritabanına kaydedecek metod şablonu.
        /// </summary>
        /// <param name="product"></param>
        void Update(Product product);

        /// <summary>
        /// Parametre olarak gelen product nesnesini silecek metod şablonu.
        /// </summary>
        /// <param name="product"></param>
        void Delete(Product product);


    }
}
