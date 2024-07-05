using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepo
    {
        Task<ICollection<String>> GetCategoryByIdAsync(int bookId);
        Task<Category?> GetCategoryAsync(int categoryId);
        Task<string?> UpdateCategoryAsync(string[]? categoryIds, int bookId);
        Task<IEnumerable<Category>> GetAllCategoryAsync();
    }
}
