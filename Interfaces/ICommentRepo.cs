using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepo
    {
        Task<ICollection<Comment>?> GetAllCommentsOfBook(int bookId);
        Task<int> GetCountCommentOfBook(int bookId);
    }
}