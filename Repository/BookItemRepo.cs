using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Dtos.Book;
using Microsoft.EntityFrameworkCore;
using api.Helpers;

namespace api.Repository
{
    public class BookItemRepo : IBookItemRepo
    {
        private readonly ApplicationDBContext _context;

        public BookItemRepo(ApplicationDBContext context, IAuthorRepo authorRepo,
            ICommentRepo commentRepo, ICategoryRepo categoryRepo)
        {
            _context = context;
        }

        public async Task<ICollection<BookItemBase>> GetAllAsync()
        {
            var books = await _context.BookItems.ToListAsync();
            return books;
        }

        public async Task<List<BookItemBase>> GetAllBooksWithAuthorsAsync()
        {
            return await _context.BookItems
                .Include(b => b.Author) // Eager loading to include Author data
                .ToListAsync();
        }

        public async Task<List<BookItemBase>> GetAllBooksWithAuthorsAndCategoriesAsync()
        {
            return await _context.BookItems
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .ToListAsync();
        }
        public async Task<List<BookItemBase>> GetBooksQueryAsync(QueryObject queryObject)
        {
            var bookItem = _context.BookItems.AsQueryable();

            if (queryObject.NewChapter)
            {
                // Sắp xếp sách theo chương mới nhất
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                bookItem = bookItem
                    .GroupJoin(
                        _context.Chapters,
                        book => book.BookId,
                        chapter => chapter.MangaId,
                        (book, chapters) => new { Book = book, Chapters = chapters })
                    .SelectMany(
                        bc => bc.Chapters.DefaultIfEmpty(),
                        (bc, chapter) => new { bc.Book, LatestChapterDate = chapter.PublishedDate })
                    .OrderByDescending(bc => bc.LatestChapterDate)
                    .Select(bc => bc.Book);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            if (queryObject.MostChapter)
            {
                // Sắp xếp theo số lượng chương giảm dần
                bookItem = bookItem.OrderByDescending(b => b.Chapter);
            }

            if (queryObject.Viewed)
            {
                bookItem = bookItem.OrderByDescending(b => b.Viewed);
            }

            if (queryObject.Liked)
            {
                bookItem = bookItem.OrderByDescending(b => b.Liked);
            }

            if (queryObject.Followed)
            {
                bookItem = bookItem.OrderByDescending(b => b.Followed);
            }

            if (queryObject.Commented)
            {
                bookItem = bookItem.OrderByDescending(b => b.Commented);
            }

            // if (queryObject.TopDate)
            // {
            //     bookItem = bookItem.Where(b => b.TopDate);
            // }

            // if (queryObject.TopWeek)
            // {
            //     bookItem = bookItem.Where(b => b.TopWeek);
            // }

            // if (queryObject.TopMonth)
            // {
            //     bookItem = bookItem.Where(b => b.TopMonth);
            // }

            // if (queryObject.TopAll)
            // {
            //     bookItem = bookItem.Where(b => b.TopAll);
            // }

            if (queryObject.NewBook)
            {
                bookItem = bookItem
                .Join(
                    _context.Chapters.Where(c => c.ChapterNumber == 1),
                    book => book.BookId,
                    chapter => chapter.MangaId,
                    (book, chapter) => new { Book = book, Chapter = chapter }
                )
                .OrderByDescending(bc => bc.Chapter.PublishedDate)
                .Select(bc => bc.Book);
            }

            // Phân trang
            bookItem = bookItem
                .Skip((queryObject.PageNumber - 1) * queryObject.PageSize)
                .Take(queryObject.PageSize);

            return await bookItem.ToListAsync();
        }

        public async Task<BookItemBase?> GetBookByIdAsync(string id)
        {
            bool isNumber = int.TryParse(id, out int number);
            if (isNumber)
            {
                int bookId = int.Parse(id);
                var book = await _context.BookItems.FirstOrDefaultAsync(b => b.BookId == bookId);
                if (book != null)
                {
                    return book;
                }
                return null;
            }
            else
            {
                var book = await _context.BookItems.FirstOrDefaultAsync(b => b.NameUrl.ToLower() == id.ToLower());
                if (book != null)
                {
                    return book;
                }
                return null;
            }

        }

        public async Task<(string?, int)> UpdateBookAsync(BookItemBase bookItem)
        {
            var book = await _context.BookItems.FirstOrDefaultAsync(b => b.BookId == bookItem.BookId);
            if (book == null)
            {
                var newBook = new BookItemBase
                {
                    Name = bookItem.Name ?? string.Empty,
                    Actived = bookItem.Actived,
                    CoverImage = bookItem.CoverImage ?? string.Empty,
                    Status = bookItem.Status,
                    CurrentChapter = bookItem.CurrentChapter,
                    Description = bookItem.Description ?? string.Empty,
                    AuthorId = bookItem.AuthorId,
                    OwnerId = bookItem.OwnerId
                };
                await _context.BookItems.AddAsync(newBook);
                await _context.SaveChangesAsync();
                var idNewBook = await _context.BookItems.FirstOrDefaultAsync(b => b.Name == bookItem.Name);
                if (idNewBook != null)
                {
                    return ("Book add successfully!", idNewBook.BookId);
                }
                return (null, -1);
            }
            try
            {
                book.Name = bookItem.Name;
                book.Actived = bookItem.Actived;
                book.CoverImage = bookItem.CoverImage;
                book.Status = bookItem.Status;
                book.CurrentChapter = bookItem.CurrentChapter;
                book.Description = bookItem.Description;
                book.AuthorId = bookItem.AuthorId;
                book.OwnerId = bookItem.OwnerId;

                // Save changes to the database
                await _context.SaveChangesAsync();

                return ("Book updated successfully", bookItem.BookId);
            }
            catch
            {
                return (null, -1);
            }
        }

    }
}
