using ProniaMVC.Business.Service.Abstract;
using ProniaMVC.Core.Models;
using ProniaMVC.Core.RepsitoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Business.Service.Concret
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task AddCategoryAsync(Category category)
        {
            if (category == null) throw new NullReferenceException();

            if(! _categoryRepository.GetAll().Any(x=>x.Name == category.Name))
              await  _categoryRepository.AddAsync(category);
            _categoryRepository.CommitAsync();
        }

        public void DeleteCategory(int id)
        {
            Category exsist=_categoryRepository.Get(x=>x.Id == id);
            if (exsist == null) throw new NullReferenceException();

            _categoryRepository.Delete(exsist);
            _categoryRepository.Commit();   

        }

        public List<Category> GetAllCategory(Func<Category, bool>? func = null)
        {
           return _categoryRepository.GetAll(func);
        }

        public Category GetCategory(Func<Category, bool>? func = null)
        {
            return _categoryRepository.Get(func);

        }

        public void UpdateCategory(int id, Category newCategory)
        {
            Category oldProduct = _categoryRepository.Get(x=> x.Id == id);  

            if(oldProduct == null) throw new NullReferenceException();

            if(!_categoryRepository.GetAll().Any(x => x.Name == newCategory.Name))
            {
                oldProduct.Name= newCategory.Name;
            }

            _categoryRepository.Commit();
        }
    }
}
