using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAnotherNameRepo
    {
        Task<ICollection<string>?> GetAnotherNameByIdAsync(int bookId);
        Task<string?> UpdateAnotherNameAsync(string[]? anotherNames, int bookId);
    }
}