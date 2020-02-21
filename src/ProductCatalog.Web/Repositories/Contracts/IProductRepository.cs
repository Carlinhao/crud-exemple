using ProductCatalog.Web.Models;
using ProductCatalog.Web.ViewModels.ProductViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.Web.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<Product> Product(int id);
        Task Save(Product product);
        Task Update(Product product);
    }
}
