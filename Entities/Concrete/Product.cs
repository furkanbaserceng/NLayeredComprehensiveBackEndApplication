using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    /// <summary>
    /// Diğer tüm katmanların Product'a erişebilir olması için access modifiers'ını public yaptım.
    /// Çünkü; DataAccess eklemek için,Business kontrol için, UI ise ürünü göstermek için ihtiyaç duyacak.
    /// </summary>
    public class Product : IEntity
    {
        /// <summary>
        /// İlk aşamada salt kodlar yazacağım için Northwind veritabanındaki 
        /// orijinal kolon adlarını yazdım.
        /// </summary>
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        /// <summary>
        /// Northwind veritabanında UnitsInStock alanı smallint olarak tanımlı olduğu için
        /// C# karşılığı olarak short tipi verdim.
        /// </summary>
        public short UnitsInStock { get; set; }

        /// <summary>
        /// Northwind veritabanında UnitsInStock alanı money olarak tanımlı olduğu için
        /// C# karşılığı olarak decimal tipi verdim.
        /// </summary>
        public decimal UnitPrice { get; set; }

    }
}
