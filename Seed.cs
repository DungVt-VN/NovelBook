using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Data.Enums;
using api.Data;

namespace api
{
    public class Seed
    {
        private readonly ApplicationDBContext _context;

        public Seed(ApplicationDBContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            // Ensure database is created
            if (!_context.Database.CanConnect())
            {
                _context.Database.EnsureCreated();
            }
    // Thêm dữ liệu các bảng ở đây


    // Seed Authors

    // Seed Chapters
if (!_context.Chapters.Any())
{
    var chapters = new List<Chapter>();

    // Loop through MangaIds from 2 to 51
    for (int mangaId = 2; mangaId <= 51; mangaId++)
    {
        // Generate 40 chapters for each MangaId
        for (int chapterNumber = 1; chapterNumber <= 40; chapterNumber++)
        {
            chapters.Add(new Chapter
            {
                Title = $"Chapter {chapterNumber} for MangaId {mangaId}",
                ChapterNumber = chapterNumber,
                Content = $"Content of Chapter {chapterNumber} for MangaId {mangaId}",
                MangaId = mangaId
            });
        }
    }

    _context.Chapters.AddRange(chapters);
    _context.SaveChanges();
}


    // Kết thúc ở đây

        }
    }
}
