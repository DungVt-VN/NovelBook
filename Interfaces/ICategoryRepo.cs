using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepo
    {
        Task<ICollection<String>> GetCategoryByIdAsync(int bookId);
        Task<Category?> GetCategoryAsync(int categoryId);
        Task<string?> UpdateBookCategoryAsync(string[]? categoryIds, int bookId);
        Task<IEnumerable<Category>> GetAllCategoryAsync();

        Task<string?> DeleteCategoryAsync(int categoryId);
        Task<string?> UpdateCategoryAsync(Category category);
        Task<string?> InsertCategoryAsync(List<Category> categories);
    }
}
