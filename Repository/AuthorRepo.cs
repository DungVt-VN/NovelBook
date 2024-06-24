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
    public class AuthorRepo : IAuthorRepo
    {
        private readonly ApplicationDBContext _context;
        public AuthorRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<String?> GetAuthorByIdAsync(int authorId)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
            if (result != null)
            {
                return result.Pseudonym;
            }
            return null;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var result = await _context.Authors.ToListAsync();
            return result;
        }

        public async Task<int> UpdateNewAuthorAsync(string authors)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Pseudonym == authors);
            if (author == null)
            {
                var newAuthor = new Author
                {
                    Pseudonym = authors,
                    DateOfBirth = new DateTime(1970, 1, 1),
                    Biography = "Biography of Author 1"
                };
                _context.Authors.Add(newAuthor);
                await _context.SaveChangesAsync();
                return newAuthor.AuthorId;
            }
            return author.AuthorId;
        }

        public async Task<int?> GetAuthorByNameAsync(string author)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(a => a.Pseudonym == author);
            if (result!= null)
            {
                return result.AuthorId;
            }
            return null;
        }
    }
}
