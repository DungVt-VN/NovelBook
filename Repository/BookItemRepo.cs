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
        private readonly IAuthorRepo _authorRepo;
        private readonly ICommentRepo _commentRepo;
        private readonly ICategoryRepo _categoryRepo;

        public BookItemRepo(ApplicationDBContext context, IAuthorRepo authorRepo, 
            ICommentRepo commentRepo, ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _context = context;
            _authorRepo = authorRepo;
            _commentRepo = commentRepo;
        }

        public async Task<ICollection<AllBookDto>> GetAllAsync()
        {
            var result = await _context.BookItems.ToListAsync();
            var allBookDtoTasks = result.Select(async a =>
            {
                // Get Author
                var author = await _authorRepo.GetAuthor(a.AuthorId);
                var pseudonym = string.Empty;
                if (author != null)
                {
                    pseudonym = author.Pseudonym;
                }

                // Get Comment Count
                int countOfComment = 0;
                var comments = await _commentRepo.GetAllCommentsOfBook(a.BookId);
                if (comments != null)
                {
                    countOfComment = comments.Count();
                }

                // Get Categories
                var categories = await _categoryRepo.GetCategoriesAsync(a.BookId);

                // call ToViewAllBook
                return a.ToViewAllBook(pseudonym, countOfComment, categories);
            });

            var allBookDto = await Task.WhenAll(allBookDtoTasks);
            return allBookDto.ToList();
        }
    }
}
