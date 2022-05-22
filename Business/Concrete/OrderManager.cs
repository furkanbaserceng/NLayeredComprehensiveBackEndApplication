using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {

        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IDataResult<List<Order>> GetAll()
        {

            

            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());

        }

        public IDataResult<Order> GetByOrderId(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o=>o.OrderId==orderId));
        }

        public IResult Add(Order order)
        {

            _orderDal.Add(order);
            return new SuccessResult();


        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult();
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult();
        }

        
    }
}
