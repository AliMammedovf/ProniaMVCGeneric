using ProniaMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Business.Service.Abstract
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(Category category);

        void DeleteCategory(int id);

        void UpdateCategory(int id, Category newCategory);

        Category GetCategory(Func<Category, bool>? func = null);

        List<Category> GetAllCategory(Func<Category, bool>? func = null);
        
    }
}
