using ProductCatalog.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.Web.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> GetForId(int id);
        Task<IEnumerable<Product>> GetProduct(int id);
        Task<Category> UpDateCategory(Category category);
        Task<Category> SaveCategory(Category category);
        Task<Category> RemoveCategory(Category category);
    }
}
