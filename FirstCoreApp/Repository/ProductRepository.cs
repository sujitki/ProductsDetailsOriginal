using Dapper;
using FirstCoreApp.Context;
using FirstCoreApp.Contracts;
using FirstCoreApp.Models;

namespace FirstCoreApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<Products> GetProducts()
        {
            var query = "SELECT * FROM Products";
            using (var connection = _context.CreateConnection())
            {
                var products = connection.Query<Products>(query);
                return products.ToList();
            }
        }

        public IEnumerable<Products> GetProductWithID(int id)
        {
            var query = "SELECT * FROM Products where SN=" + id;
            using (var connection = _context.CreateConnection())
            {
                var products = connection.Query<Products>(query);
                return products.ToList();
            }
        }

        public void AddProducts(Products product)
        {
            try
            {
                var query = "Insert into Products(ProductName, Description, Price, Created) Values('" + product.ProductName + "', '" + product.Description + "', '"
                + product.Price + "', '" + product.Created + "')";
                using (var connection = _context.CreateConnection())
                {
                    connection.Execute(query);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        public void UpdateProduct(Products product)
        {
            try
            {
                var query = "Update Products SET ProductName = '" + product.ProductName + "'," +
                        "Description = '" + product.Description + "', Price = " + product.Price +
                        "Where SN = " + product.SN;
                using (var connection = _context.CreateConnection())
                {
                    connection.Execute(query);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public void DeleteProduct(int id)
        {
            try
            {
                var query = "delete from Products where SN = " + id;
                using (var connection = _context.CreateConnection())
                {
                    connection.Execute(query);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
