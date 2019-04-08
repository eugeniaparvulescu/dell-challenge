using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _productService.Add(newProduct);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var product = _productService.Get(id);
            var model = new UpdateProductModel()
            {
                Id = product.Id,
                Category = product.Category,
                Name = product.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _productService.Update(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var product = _productService.Get(id);
            var model = new ProductModel()
            {
                Id = product.Id,
                Category = product.Category,
                Name = product.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(string id)
        {
            _productService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}