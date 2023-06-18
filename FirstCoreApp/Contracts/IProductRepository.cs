using FirstCoreApp.Models;

namespace FirstCoreApp.Contracts
{
    public interface IProductRepository
    {
        public IEnumerable<Products> GetProducts();
        public IEnumerable<Products> GetProductWithID(int id);
        public void AddProducts(Products product);
        public void UpdateProduct(Products product);
        public void DeleteProduct(int id);
    }
}
