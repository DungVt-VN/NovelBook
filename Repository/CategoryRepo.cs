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

        public async Task<ICollection<String>> GetCategoryByIdAsync(int bookId)
        {
            var categoryIds = await _context.BookCategories
                                .Where(c => c.BookId == bookId)
                                .Select(c => c.CategoryId)
                                .ToListAsync();
            var result = await _context.Categories
                     .Where(c => categoryIds.Contains(c.CategoryId))
                     .ToListAsync();
            return result.Select(c => c.CategoryName).ToList();
        }

        public async Task<string?> UpdateCategoryAsync(int[]? categoryIds, int bookId)
        {
            var book = await _context.BookItems.FindAsync(bookId);
            if (book == null)
            {
                return null;
            }
            try
            {
                _context.BookCategories.RemoveRange(_context.BookCategories.Where(c => c.BookId == bookId));
                await _context.SaveChangesAsync();
                if (categoryIds != null)
                {
                    foreach (var categoryId in categoryIds)
                    {
                        _context.BookCategories.Add(new BookCategory
                        {
                            BookId = bookId,
                            CategoryId = categoryId
                        });
                    }
                    await _context.SaveChangesAsync();
                }
                return "Updated!";
            }
            catch
            {
                return null;
            }
        }

    }
}
