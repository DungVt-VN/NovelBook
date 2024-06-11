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
    public class CommentRepo : ICommentRepo
    {
        private readonly ApplicationDBContext _context;
        public CommentRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Comment>?> GetAllCommentsOfBook(int bookId)
        {
            var comments = await _context.Comments.Where(c => c.BookItemId == bookId).ToListAsync();
            return comments;
        }
    }
}