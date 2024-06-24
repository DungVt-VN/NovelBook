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
    public class AnotherNameRepo : IAnotherNameRepo
    {
        private readonly ApplicationDBContext _context;
        public AnotherNameRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ICollection<string>?> GetAnotherNameByIdAsync(int bookId)
        {
            var result = await _context.AnotherNames
                .Where(a => a.BookId == bookId)
                .Select(a => a.Name!)
                .ToListAsync();
            return result;
        }

        public async Task<string?> UpdateAnotherNameAsync(string[]? anotherNames, int bookId)
        {
            var book = await _context.BookItems.FirstOrDefaultAsync(a => a.BookId == bookId);
            if (book == null)
            {
                return null;
            }
            try
            {
                if (anotherNames == null)
                {
                    _context.AnotherNames.RemoveRange(_context.AnotherNames.Where(a => a.BookId == bookId));
                    await _context.SaveChangesAsync();
                    return "updated";
                } else {
                    _context.AnotherNames.RemoveRange(_context.AnotherNames.Where(a => a.BookId == bookId));
                    await _context.SaveChangesAsync();
                    foreach (var name in anotherNames)
                    {
                        _context.AnotherNames.Add(new AnotherName { BookId = bookId, Name = name });
                    }
                    await _context.SaveChangesAsync();
                    return "Updated";
                }
            } catch {
                return null;
            }
        }
    }
}