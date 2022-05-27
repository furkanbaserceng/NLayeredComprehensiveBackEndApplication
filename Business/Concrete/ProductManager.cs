using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        private ICategoryService _categoryService;
        

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
                
        }

        

        public IDataResult<List<Product>> GetAll()
        {
            
            if (DateTime.Now.Hour == 19)
            {
                //Bu kullanımda data göndermedik.Null gideceğinden front-end kısmında ona göre işlem yaptırılacak.Burdan bir liste geldiğini anlayıp ona göre ayarlayacak ama data olmayacak.
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==categoryId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            

            var result=BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                              CheckIfProductCountOfCategory(product.CategoryId), 
                              CheckIfCategoryLimitedExceded());

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
             return new SuccessResult(Messages.ProductSuccessfullyAdded);
  
        }

        [ValidationAspect(typeof(Product))]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductSuccessfullyUpdated);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductSuccessfullyDeleted);
        }



        private IResult CheckIfProductCountOfCategory(int categoryId)
        {

            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {

            //var result = _productDal.Get(p => p.ProductName == productName);

            //if (result.ProductName==productName) yada yine getall deyip counta bakılır, result!=null ise de denilebilir.
            //{
            //    return new ErrorResult(Messages.ProductNameSameError);
            //}

            var result = _productDal.GetAll(p => p.ProductName == productName).Any();//any bool döndürür.

            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitedExceded()
        {

            var result = _categoryService.GetAll();

            if (result.Data.Count >= 15)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

    }
}
