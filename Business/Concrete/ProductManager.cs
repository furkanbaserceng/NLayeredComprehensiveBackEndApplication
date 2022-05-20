using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    /// <summary>
    /// Business katmanında bir sınıfın instance ı oluşturulduğu anda oluşturulan sınıfa tightly-coupked(sıkı bağımlılık) oluşur.
    /// Yazılımın sürdürülebilirliği için alternatif sistemlere geçildiğinde sıkıntı yaşanmaması adına 
    /// veri erişim katmanının soyut nesnelerini construstora enjekte ederek weakly coupled bir ortam oluşturdum.
    /// </summary>
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _productDal.GetAll(p=>p.CategoryId==categoryId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
