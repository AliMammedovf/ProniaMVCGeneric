using ProniaMVC.Business.Service.Abstract;
using ProniaMVC.Business.Service.Exceptions;
using ProniaMVC.Core.Models;
using ProniaMVC.Core.RepsitoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Business.Service.Concret
{
    public class ProductService:IProductService
    {
        public IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsyncProduct(Product product)
        {
            if( product == null) throw new NullReferenceException();

            if(! _productRepository.GetAll().Any(x=> x.Name== product.Name) )
              await _productRepository.AddAsync(product);
            else
            {
                throw new AvailableObjectException("Ferqli ad daxil edin!");
            }
            _productRepository.CommitAsync();
        }

        public void DeleteProduct(int id)
        {

            Product exsistProduct = _productRepository.Get(x => x.Id == id);

            if( exsistProduct == null ) throw new NullReferenceException();

            _productRepository.Delete(exsistProduct);
            _productRepository.Commit();


        }

        public List<Product> GetAllProduct(Func<Product, bool>? func = null)
        {
           return _productRepository.GetAll(func);
           
        }

        public Product GetProduct(Func<Product, bool>? func = null)
        {
            return _productRepository.Get(func);
           
        }

        public void UpdateProduct(int id, Product newProduct)
        {
            Product oldProduct= _productRepository.Get(x=> x.Id == id);

            if( oldProduct == null ) throw new NullReferenceException();

            if (!_productRepository.GetAll().Any(x => x.Name == newProduct.Name))
            {
                oldProduct.Name = newProduct.Name;
                oldProduct.Description = newProduct.Description;
                oldProduct.Price = newProduct.Price;
                oldProduct.ImageURL = newProduct.ImageURL;
                oldProduct.CategoryId = newProduct.CategoryId;
                
            }

            _productRepository.Commit();


        }
    }
}
