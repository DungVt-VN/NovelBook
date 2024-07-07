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

        public async Task<ICollection<BookItem>> GetAllAsync(QueryObject queryObject)
        {
            var skipNumber = (queryObject.PageNumber - 1)*queryObject.PageSize;
            return await _context.BookItems.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
        }

        public async Task<List<BookItem>> GetAllBooksWithAuthorsAsync()
        {
            return await _context.BookItems
                .Include(b => b.Author) // Eager loading to include Author data
                .ToListAsync();
        }

        public async Task<List<BookItem>> GetAllBooksWithAuthorsAndCategoriesAsync()
        {
            return await _context.BookItems
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .ToListAsync();
        }
        public async Task<List<BookItem>> GetBooksQueryAsync(QueryObject queryObject)
        {
            var bookItem = _context.BookItems.AsQueryable();

            if (queryObject.NewChapter)
            {
                bookItem = bookItem
                    .GroupJoin(
                        _context.Chapters, // Thực hiện group join với bảng Chapters trong DbContext (_context)
                        book => book.BookId, // Khóa chính của bảng sách (bookItem)
                        chapter => chapter.BookItemId, // Khóa ngoại trỏ đến sách trong bảng Chapters
                        (book, chapters) => new { Book = book, Chapters = chapters }) // Kết quả trả về là một object có thuộc tính Book và Chapters
                    .SelectMany(
                        bc => bc.Chapters.DefaultIfEmpty(), // SelectMany để kết hợp các sách với chương tương ứng, mặc định nếu không có chương
                        (bc, chapter) => new
                        {
                            bc.Book,
                            LatestChapterDate = (chapter != null) ? chapter.PublishedDate : (DateTime?)null
                        }) // Lấy sách và ngày phát hành chương mới nhất
                    .OrderByDescending(bc => bc.LatestChapterDate) // Sắp xếp giảm dần theo ngày phát hành chương mới nhất
                    .Select(bc => bc.Book); // Chọn ra các sách đã được sắp xếp theo chương mới nhất

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
                    chapter => chapter.BookItemId,
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

        public async Task<BookItem?> GetBookByIdAsync(string id)
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

        public async Task<(string?, int)> UpdateBookAsync(BookItem bookItem)
        {
            var book = await _context.BookItems.FirstOrDefaultAsync(b => b.BookId == bookItem.BookId);
            if (book == null)
            {
                var newBook = new BookItem
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
