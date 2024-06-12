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
    }
}
