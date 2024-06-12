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

        public async Task<IEnumerable<Author?>> GetAllAuthorAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<string?> GetAuthorAsync(int authorId)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);

            if (author == null)
            {
                return null;
            }

            return author.Pseudonym;
        }
    }
}
