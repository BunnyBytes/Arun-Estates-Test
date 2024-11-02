using ArunEstatesTestOlivia.Models;

namespace ArunEstatesTestOlivia.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<List<Product>> SearchProductsAsync(string searchTerm);
    }
}
