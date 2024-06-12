using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepo
    {
        Task<ICollection<int>> GetCategoryIdAsync(int bookId);
        Task<Category?> GetCategoryAsync(int categoryId);
        Task<ICollection<String>> GetCategoriesAsync(ICollection<int> categoryIds);
    }
}
