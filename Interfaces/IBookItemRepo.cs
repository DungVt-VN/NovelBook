using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Helpers;
using api.Models;
using Microsoft.AspNetCore.Http.Extensions;

namespace api.Interfaces
{
    public interface IBookItemRepo
    {
        Task<ICollection<BookItem>> GetAllAsync(QueryObject queryObject);
        Task<List<BookItem>> GetAllBooksWithAuthorsAndCategoriesAsync();
        Task<List<BookItem>> GetAllBooksWithAuthorsAsync();

        Task<List<BookItem>> GetBooksQueryAsync(QueryObject queryObject);
        Task<BookItem?> GetBookByIdAsync(string id);
        Task<(string?, int)> UpdateBookAsync(BookItem bookItem);

    }
}