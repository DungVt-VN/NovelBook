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
            if (result != null) {
                return result.Pseudonym;
            }
            return null;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var result = await _context.Authors.ToListAsync();
            return result;
        }
    }
}
