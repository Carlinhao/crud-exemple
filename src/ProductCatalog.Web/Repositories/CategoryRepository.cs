using Microsoft.EntityFrameworkCore;
using ProductCatalog.Web.Data;
using ProductCatalog.Web.Models;
using ProductCatalog.Web.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Web.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDataContext _context;
        public CategoryRepository(StoreDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetForId(int id)
        {
            return await _context.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProduct(int id)
        {
            return await _context.Products.AsNoTracking().Where(x => x.CategoryId == id).ToListAsync();
        }

        public async Task<Category> RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> SaveCategory(Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpDateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
