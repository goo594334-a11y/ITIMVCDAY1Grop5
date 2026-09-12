using ITIMVCDAY1Grop5.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITIMVCDAY1Grop5.Controllers
{
    public class ProductController : Controller
    {
        ProductBl Pro=new ProductBl();
        public IActionResult Index()
        {
            var Reselt = Pro.AllProduct();
            return View("Index" ,Reselt);
        }

        public IActionResult Detiles(int Id)
        {
            var Reselt = Pro.ProductPYId(Id);
            return View("Detiles", Reselt);
        }

    }
}
