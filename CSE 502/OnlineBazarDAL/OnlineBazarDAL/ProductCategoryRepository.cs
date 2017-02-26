using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBazarDAL
{
    public class ProductCategoryRepository
    {
        public OnlineBazarEntities onlineBazarEntities = null;

        public ProductCategoryRepository()
        {
            onlineBazarEntities = new OnlineBazarEntities();
        }

        public bool AddProductCategory(ProductCategory productCategory)
        {
            onlineBazarEntities.ProductCategories.Add(productCategory);
            return onlineBazarEntities.SaveChanges() > 0;
        }

        public bool EditProductCategory(ProductCategory productCategory)
        {
            onlineBazarEntities.ProductCategories.Attach(productCategory);
            onlineBazarEntities.Entry(productCategory).State = System.Data.Entity.EntityState.Modified;
            return onlineBazarEntities.SaveChanges() > 0;
        }

        public bool DeleteProductCategory(ProductCategory productCategory)
        {
            onlineBazarEntities.ProductCategories.Attach(productCategory);
            onlineBazarEntities.Entry(productCategory).State = System.Data.Entity.EntityState.Deleted;
            return onlineBazarEntities.SaveChanges() > 0;
        }

        public List<ProductCategory> GetProductCategoryList()
        {
            return onlineBazarEntities.ProductCategories.ToList();
        }

        public ProductCategory GetProductCategory(int ProductCategoryId)
        {
            return onlineBazarEntities.ProductCategories.FirstOrDefault(p => p.Id == ProductCategoryId);
        }
    }
}
