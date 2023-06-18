using FirstCoreApp.Contracts;
using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
            var data = GetProducts();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            DeleteProducts(id);
            var data = GetProducts();
            return View("Index", data);
        }

        public IEnumerable<Products> GetProducts()
        {
            try
            {
                return _productRepo.GetProducts();
            }
            catch (Exception ex)
            {
                //log error
                return null;
            }
        }

        public void DeleteProducts(int id)
        {
            try
            {
                _productRepo.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                //log error
            }
        }
    }
}
