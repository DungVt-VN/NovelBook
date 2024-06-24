using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAuthorRepo
    {
        Task<String?> GetAuthorByIdAsync(int bookId);
        Task<List<Author>> GetAllAuthorsAsync();
        Task<int> UpdateNewAuthorAsync(string authors);
        Task<int?> GetAuthorByNameAsync(string author);
    }
}