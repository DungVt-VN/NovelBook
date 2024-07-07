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

        public async Task<string?> DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return "Delete Sussessful!";
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
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

        public async Task<string?> InsertCategoryAsync(List<Category> categories)
        {
            var existingCategoryNames = await _context.Categories.Select(c => c.CategoryName).ToListAsync();
            var newCategories = categories
                .Where(c => !existingCategoryNames.Contains(c.CategoryName, StringComparer.OrdinalIgnoreCase))
                .ToList();

            if (!newCategories.Any())
            {
                return "No new categories to insert.";
            }

            await _context.Categories.AddRangeAsync(newCategories);
            return await _context.SaveChangesAsync() > 0 ? "Insert Successful!" : null;
        }


        public async Task<string?> UpdateBookCategoryAsync(string[]? categories, int bookId)
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
                if (categories != null)
                {
                    foreach (var item in categories)
                    {
                        var categoryId = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == item);
                        if (categoryId != null)
                        {
                            _context.BookCategories.Add(new BookCategory
                            {
                                BookId = bookId,
                                CategoryId = categoryId.CategoryId
                            });
                        }
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

        public async Task<string?> UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.CategoryId);

            if (existingCategory == null)
            {
                return "Category not found"; // Trả về thông báo lỗi nếu thực thể không tồn tại.
            }

            _context.Categories.Update(category);

            return await _context.SaveChangesAsync() > 0 ? "Update Successful!" : "No changes were made.";
        }

    }
}
