using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Web.Data;
using ProductCatalog.Web.Models;
using ProductCatalog.Web.Repositories.Contracts;

namespace ProductCatalog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Route("v1/categories")]
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryRepository.Get();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public async Task<Category> Get(int id)
        {
            return await _categoryRepository.GetForId(id);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts(int id)
        {
            return await _categoryRepository.GetProduct(id);
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody]Category category)
        {
            _categoryRepository.UpDateCategory(category);
            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody]Category category)
        {
            _categoryRepository.SaveCategory(category);
            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Remove([FromBody]Category category)
        {
            _categoryRepository.RemoveCategory(category);
            return category;
        }
    }
}