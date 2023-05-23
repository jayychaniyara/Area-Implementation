using Assesment.DomainModels;
using Assesment.RepositoryContracts;
using Assesment.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.ServiceLayer
{
    public class ProductService : IProductsService
    {
        IProductsRepository prodRep;

        public ProductService(IProductsRepository repo)
        {
            this.prodRep = repo;
        }


        public void DeleteProduct(long ProductID)
        {
            prodRep.DeleteProduct(ProductID);
        }

        public Product GetProductByProductID(long ProductID)
        {
            Product p = prodRep.GetProductByProductID(ProductID);
            return p;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = prodRep.GetProducts();
            return products;
        }

        public void InsertProduct(Product p)
        {
            prodRep.InsertProduct(p);
        }

        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = prodRep.SearchProducts(ProductName);
            return products;
        }

        public void UpdateProduct(Product p)
        {
            prodRep.UpdateProduct(p);
        }
    }
}
