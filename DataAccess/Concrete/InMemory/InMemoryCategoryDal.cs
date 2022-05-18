using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCategoryDal : ICategoryDal
    {

        List<Category> _categories;
        public InMemoryCategoryDal()
        {
            _categories = new List<Category>
            {
                new Category{CategoryId=1,CategoryName="Technology"},
                new Category{CategoryId=2,CategoryName="Household Products"},
                new Category{CategoryId=3,CategoryName="Stationary"},

            };
        }

        
       

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Delete(Category category)
        {
            var categoryToDelete=_categories.SingleOrDefault(c=>c.CategoryId==category.CategoryId);
            _categories.Remove(categoryToDelete);
        }

        

        public void Update(Category category)
        {
            var categoryToUpdate = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            categoryToUpdate.CategoryId = category.CategoryId;
            categoryToUpdate.CategoryName = category.CategoryName;


        }

        public List<Category> GetAll(Expression<Func<bool, Category>> filter = null)
        {
            return _categories;
        }

        public Category Get(Expression<Func<bool, Category>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
