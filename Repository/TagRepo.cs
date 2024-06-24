using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3.Model;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    public class TagRepo : ITagRepo
    {
        private readonly ApplicationDBContext _context;
        public TagRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ICollection<string>> GetTagByIdAsync(int bookId)
        {
            var tagIds = await _context.BookTags
                                .Where(c => c.BookId == bookId)
                                .Select(c => c.TagId)
                                .ToListAsync();
            var result = await _context.Tags
                     .Where(t => tagIds.Contains(t.TagId))
                     .ToListAsync();
            return result.Select(c => c.TagName).ToList();
        }

        public async Task<string?> UpdateTagAsync(int[]? tags, int bookId)
        {
            var book = await _context.BookItems.FindAsync(bookId);
            if (book == null)
            {
                return null;
            }
            try
            {
                var result = await _context.BookTags.Where(c => c.BookId == bookId).ToListAsync();

                _context.BookTags.RemoveRange(result);
                if (tags != null)
                {
                    foreach (var item in tags)
                    {
                        _context.BookTags.Add(new BookTag()
                        {
                            BookId = bookId,
                            TagId = item
                        });
                    }
                }

                await _context.SaveChangesAsync();
                return "Updated!";
            }
            catch
            {
                return null;
            }
        }

    }
}