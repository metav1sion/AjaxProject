using System.Text.Json.Serialization;
using AjaxProject.Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AjaxProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            var newproduct = JsonConvert.SerializeObject(product);
            return Json(newproduct);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x=>x.ProductId == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            var productResponse = JsonConvert.SerializeObject(product);
            //return Json(productResponse);
            return NoContent();
        }

        [HttpPost]
        public  IActionResult UpdateProduct(Product product)
        {
            //var product = _context.Products.FirstOrDefault(x=>x.ProductId == id);
            _context.Products.Update(product);
            _context.SaveChanges();
            return NoContent();
        }

        
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.FirstOrDefault(x=>x.ProductId == id);
            var jsonValue = JsonConvert.SerializeObject(value);
            return Json(jsonValue);
        }
    }
}
