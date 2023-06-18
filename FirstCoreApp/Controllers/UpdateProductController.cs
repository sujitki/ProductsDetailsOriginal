using FirstCoreApp.Contracts;
using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Controllers
{
    public class UpdateProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public UpdateProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public IActionResult Index(int id)
        {
            var data = GetProductWithID(id).ToList();
            return View(data[0]);
        }

        public IActionResult Update(int id, string productName, int productPrice, string productDesc)
        {
            Products product = new Products();
            product.SN = id;
            product.ProductName = productName;
            product.Price = productPrice;
            product.Description = productDesc;
            product.Created = DateTime.Now;
            UpdateProducts(product);
            return RedirectToAction("Index","Product");
        }


        public IEnumerable<Products> GetProductWithID(int id)
        {
            try
            {
                return _productRepo.GetProductWithID(id);
            }
            catch (Exception ex)
            {
                //log error
                return null;
            }
        }


        public void UpdateProducts(Products product)
        {
            try
            {
                _productRepo.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                //log error
            }
        }
    }
}
