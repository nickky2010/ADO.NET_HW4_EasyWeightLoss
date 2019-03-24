using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Services
{
    class ProductManager:IDisposable
    {
        IRepository<Product> productRepository;

        public ProductManager(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Create(Product product)
        {
            if (product != null)
            {
                if(productRepository.Get(p=>p.Name==product.Name).Count()!=0)
                    throw new Exception("This product already exists");
                if (product.Name.Length == 0)
                    throw new Exception("No name");
                if (product.EnergyValue <=0)
                    throw new Exception("Nonpositive energy capacity");
                productRepository.Create(product);
            }
        }
        public IEnumerable<Product> GetAll()
        {
            return productRepository.Get();
        }
        public void Delete(Product product)
        {
            productRepository.Remove(product);
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    productRepository.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
