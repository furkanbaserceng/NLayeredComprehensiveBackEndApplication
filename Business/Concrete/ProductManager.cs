using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
    }
}
