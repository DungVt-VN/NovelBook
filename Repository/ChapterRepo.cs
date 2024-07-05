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
    public class ChapterRepo : IChapterRepo
    {
        private readonly ApplicationDBContext _context;
        public ChapterRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Chapter>> GetAllChapterByIdAsync(int bookId)
        {
            var chapter = await _context.Chapters.Where(c => c.MangaId == bookId).ToListAsync();
            return chapter;
        }

        public async Task<int?> CreateChapterAsync(Chapter chapter)
        {
            try
            {
                var book = await _context.BookItems.FirstOrDefaultAsync(c => c.BookId == chapter.MangaId);
                if (book == null)
                {
                    return null;
                }
                var chapters = await _context.Chapters
                    .Where(c => c.MangaId == chapter.MangaId)
                    .Select(c => c.ChapterNumber)
                    .ToListAsync();

                if (chapters.Contains(chapter.ChapterNumber))
                {
                    return -1;
                }

                await _context.Chapters.AddAsync(chapter);
                await _context.SaveChangesAsync();
                return chapter.ChapterId;
            }
            catch
            {
                return null;
            }

        }

        public async Task<string?> CreateImageAsync(List<Images> images, int chapterId)
        {
            if (chapterId == -1)
            {
                return null;
            }
            try
            {
                var chapter = await _context.Chapters.FindAsync(chapterId);
                if (chapter == null)
                {
                    return null;
                }
                foreach (var image in images)
                {
                    image.ChapterId = chapterId;
                }
                await _context.Images.AddRangeAsync(images);
                await _context.SaveChangesAsync();
                return "Created Images!";
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi để có thể gỡ lỗi dễ dàng hơn
                Console.Error.WriteLine($"Error creating images: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<string>> GetAllImagesAsync(int chapterId)
        {
            var images = await _context.Images
                .Where(i => i.ChapterId == chapterId)
                .OrderBy(i => i.NumericalOrder)
                .Select(i => i.Url)
                .ToListAsync();

            return images;
        }


        public async Task<int?> EditChapterAsync(Chapter chapter)
        {
            var result = await _context.Chapters.FirstOrDefaultAsync(c => c.ChapterId == chapter.ChapterId);
            if (result == null)
            {
                return await CreateChapterAsync(chapter);
            }
            result.ChapterNumber = chapter.ChapterNumber;
            result.Title = chapter.Title;
            result.Content = chapter.Content;
            result.PublishedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return chapter.ChapterId;
        }
        public async Task<string?> UpdateImageAsync(List<Images> images, int? chapterId)
        {
            if (chapterId == null || chapterId == -1)
            {
                return null;
            }

            try
            {
                var chapter = await _context.Chapters.FirstOrDefaultAsync(c => c.ChapterId == chapterId);
                if (chapter == null)
                {
                    return null;
                }

                var existingImages = await _context.Images.Where(i => i.ChapterId == chapter.ChapterId).ToListAsync();

                _context.Images.RemoveRange(existingImages);
                foreach (var image in images)
                {
                    image.ChapterId = chapter.ChapterId;
                }

                await _context.Images.AddRangeAsync(images);
                await _context.SaveChangesAsync();

                return "Updated Images!";
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error updating images: {ex.Message}");
                return null;
            }
        }

    }
}