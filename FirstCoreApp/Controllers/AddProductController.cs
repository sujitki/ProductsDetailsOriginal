using FirstCoreApp.Contracts;
using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Controllers
{
    public class AddProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public AddProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Save(string productName, int productPrice, string productDesc)
        {
            Products product = new Products();
            product.ProductName = productName;
            product.Price = productPrice;
            product.Description = productDesc;
            product.Created = DateTime.Now;
            AddProducts(product);
            return RedirectToAction("Index","Product");
        }

        public void AddProducts(Products product)
        {
            try
            {
                _productRepo.AddProducts(product);
            }
            catch (Exception ex)
            {
                //log error
            }
        }
    }
}
