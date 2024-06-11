using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Models;

namespace api.Interfaces
{
    public interface IBookItemRepo
    {
        Task<ICollection<AllBookDto>> GetAllAsync();
    }
}