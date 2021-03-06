
using Core.Entities; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    /// <summary>
    /// IEntityRepository'nin çalışacağı tip olan T parametresi class constrainti ile referans tip olmak zorunda.
    /// Aynı zamanda IEntity interfacinden implemente edilmiş bir referans tip olmalı
    /// ama bu kısıtla beraber IEntity nin kendisi de verilebilir.Bunu engellemek için new() kısıtı verdim.
    /// Bu sayede sadece IEntity imzasına sahip olan ve instance ı alınabilen veritabanı nesneleri verilebilir hale geldi.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
