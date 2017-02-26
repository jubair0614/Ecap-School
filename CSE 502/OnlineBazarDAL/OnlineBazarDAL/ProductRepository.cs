using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBazarDAL
{
    public class ProductRepository
    {
        OnlineBazarEntities onlineBazarEntities = null;

        public ProductRepository()
        {
            onlineBazarEntities = new OnlineBazarEntities();
        }

        public bool AddProduct(Product product)
        {
            onlineBazarEntities.Products.Add(product);
            return onlineBazarEntities.SaveChanges() > 0;
        }

        public bool EditProduct(Product product)
        {
            onlineBazarEntities.Products.Attach(product);
            onlineBazarEntities.Entry(product).State = System.Data.Entity.EntityState.Modified;
            return onlineBazarEntities.SaveChanges() > 0;
        }

        public bool DeleteProduct(Product product)
        {
            onlineBazarEntities.Products.Attach(product);
            onlineBazarEntities.Entry(product).State = System.Data.Entity.EntityState.Deleted;
            return onlineBazarEntities.SaveChanges() > 0;
        }

        public List<Product> GetProductList()
        {
            return onlineBazarEntities.Products.ToList();
        }

        public Product GetProduct(int productId)
        {
            return onlineBazarEntities.Products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
