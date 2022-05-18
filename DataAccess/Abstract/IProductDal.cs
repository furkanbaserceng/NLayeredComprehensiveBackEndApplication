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
    public interface IProductDal : IEntityRepository<Product>
    {
      
        
        List<Product> GetByCategoryId(int categoryId);

       


    }
}
