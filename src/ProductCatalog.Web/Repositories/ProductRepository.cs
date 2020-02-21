using Microsoft.EntityFrameworkCore;
using ProductCatalog.Web.Data;
using ProductCatalog.Web.Models;
using ProductCatalog.Web.Repositories.Contracts;
using ProductCatalog.Web.ViewModels.ProductViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Web.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDataContext _context;

        public ProductRepository(StoreDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            return await _context.Products
            .Include(x => x.Category)
            .Select(x => new ProductViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Price = x.Price,
                Category = x.Category.Title,
                CategoryId = x.Category.Id
            })
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<Product> Product(int id)
        {
            return await _context.Products.FindAsync(id);
            //_context.Products.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Save(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
