using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InClassAspNet.Controllers
{
    public class ProductController : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            var viewModel = new ViewModels.ProductIndexViewModel();
            ProductRepository repo = new ProductRepository();
            viewModel.Products = repo.GetAllProducts();

            return View(viewModel);
        }

        public IActionResult Delete(int IdForDeletion)
        {
            ProductRepository repo = new ProductRepository();
            repo.DeleteProduct(IdForDeletion);

            return RedirectToAction("Index", "Product");
        }
        public IActionResult NewProduct()
        {
            return View();
        }

        public IActionResult Create(string name, decimal price)
        {

            ProductRepository repo = new ProductRepository();
            repo.InsertProduct(name, price);

            return RedirectToAction("Index", "Product");

        }
    }
}
