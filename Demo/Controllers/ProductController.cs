using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class ProductController : Controller
    {
        ProductSampleData sample = new ProductSampleData();
        public IActionResult Index() 
        {
           List< Product> GetAllProduct = sample.GetAll();
            return View("Index",GetAllProduct); 
        }

        public IActionResult Detail(int id)
        {
          
           Product product= sample.GetById(id);

            return View("ProductDetails", product);
        }
    }
}
