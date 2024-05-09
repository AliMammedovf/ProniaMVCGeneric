using ProniaMVC.Core.Models;
using ProniaMVC.Core.RepsitoryAbstract;
using ProniaMVC.Data.RepositoryCancret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Business.Service.Abstract
{
    public interface IProductService
    {
        Task AddAsyncProduct(Product product);

        void DeleteProduct(int id);

        void UpdateProduct(int id, Product product);    

        Product GetProduct(Func<Product, bool>? func=null);

        List<Product> GetAllProduct(Func<Product, bool>? func=null);
    }
}
