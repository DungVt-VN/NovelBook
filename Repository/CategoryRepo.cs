using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Category?> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<ICollection<int>> GetCategoryIdAsync(int bookId)
        {
            var categoryIds = await _context.BookCategories
                                .Where(c => c.BookId == bookId)
                                .Select(c => c.CategoryId)
                                .ToListAsync();
            return categoryIds;
        }

        public async Task<ICollection<String>> GetCategoriesAsync(ICollection<int> categoryIds)
        {
            var result = await _context.Categories
                                 .Where(c => categoryIds.Contains(c.CategoryId))
                                 .ToListAsync();
            return result.Select(c => c.CategoryName).ToList();
        }
    }
}
