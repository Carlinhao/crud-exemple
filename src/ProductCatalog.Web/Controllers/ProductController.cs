using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Web.Data;
using ProductCatalog.Web.Models;
using ProductCatalog.Web.Repositories.Contracts;
using ProductCatalog.Web.ViewModels;
using ProductCatalog.Web.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("v1/categories/{id}")]
        public async Task<IEnumerable<ProductViewModel>> Get()
        {
            return await _productRepository.GetProducts();
        }

        [HttpGet]
        [Route("v1/categories/{id}")]
        public async Task<Product> Get(int id)
        {
            return await _productRepository.Product(id);
        }

        [HttpPost]
        [Route("v1/products")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public async Task<ResultViewModel> Post([FromBody] EditorProductViewModel model)
        {
            model.Validate();

            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possivel cadastrar o produto",
                    Data = model.Notifications
                };

            var product = new Product();
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            await _productRepository.Save(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso!",
                Data = product
            };
        }

        [HttpPut]
        [Route("v1/products")]
        public async Task<ResultViewModel> Put([FromBody]EditorProductViewModel model)
        {
            model.Validate();

            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possivel alterar o produto",
                    Data = model.Notifications
                };

            var product = await _productRepository.Product(model.Id);
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            // product.CreateDate = DateTime.Now; // Nunca altera a data de criação
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            await _productRepository.Update(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto alterado com sucesso!",
                Data = product
            };
        }
    }
}