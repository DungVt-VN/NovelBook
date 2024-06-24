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
        Task<ICollection<BookItemBase>> GetAllAsync();
        Task<List<BookItemBase>> GetAllBooksWithAuthorsAndCategoriesAsync();
        Task<List<BookItemBase>> GetAllBooksWithAuthorsAsync();

        Task<List<BookItemBase>> GetBooksQueryAsync(QueryObject queryObject);
        Task<BookItemBase?> GetBookByIdAsync(string id);
        Task<(string?, int)> UpdateBookAsync(BookItemBase bookItem);

    }
}