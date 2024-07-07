using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3.Model;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Tag = api.Models.Tag;

namespace api.Repository
{

    public class TagRepo : ITagRepo
    {
        private readonly ApplicationDBContext _context;
        public TagRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<string?> DeleteTagAsync(int tagId)
        {
            var tag = await _context.Tags.FindAsync(tagId);
            if (tag == null)
            {
                return null;
            }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return "Delete Sussesfully";
        }

        public async Task<IEnumerable<Models.Tag>> GetAllTagsAsync()
        {
            var tags = await _context.Tags.ToListAsync();
            return tags;
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

        public async Task<string?> InsertTagAsync(List<Tag> tags)
        {
            var existingTagNames = await _context.Tags.Select(c => c.TagName).ToListAsync();
            var newTags = tags
                .Where(c => !existingTagNames.Contains(c.TagName, StringComparer.OrdinalIgnoreCase))
                .ToList();

            if (!newTags.Any())
            {
                return "No new Tags to insert.";
            }

            await _context.Tags.AddRangeAsync(newTags);
            return await _context.SaveChangesAsync() > 0 ? "Insert Successful!" : null;
        }

        public async Task<string?> UpdateBookTagAsync(string[]? tags, int bookId)
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
                        var tag = await _context.Tags.FirstOrDefaultAsync(c => c.TagName == item);
                        if (tag != null)
                        {
                            _context.BookTags.Add(new BookTag()
                            {
                                BookId = bookId,
                                TagId = tag.TagId
                            });
                        }
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

        public async Task<string?> UpdateTagAsync(Tag tag)
        {
            var existingTags = await _context.Tags.FindAsync(tag.TagId);
            if (existingTags == null)
            {
                return "Tag not found";
            }
            _context.Tags.Update(tag);
            return await _context.SaveChangesAsync() > 0 ? "Update Sussesfully" : null;
        }
    }
}