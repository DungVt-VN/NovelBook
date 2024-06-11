using System;
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

        public async Task<ICollection<Category>?> GetCategoriesAsync(int bookId)
        {
            var categoryIds = await _context.BookCategories
                                            .Where(c => c.BookId == bookId)
                                            .Select(c => c.CategoryId)
                                            .ToListAsync();

            var categoryTasks = categoryIds.Select(async id => await _context.Categories.FirstOrDefaultAsync(a => a.CategoryId == id));

            var categories = await Task.WhenAll(categoryTasks);

            // Lọc ra các giá trị null và chuyển đổi thành ICollection<Category>
            return categories.Where(c => c != null).ToList()!;
        }

    }
}