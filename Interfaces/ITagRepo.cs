using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3.Model;

namespace api.Interfaces
{
    public interface ITagRepo
    {
        Task<ICollection<string>> GetTagByIdAsync(int bookId);
        Task<string?> UpdateTagAsync(int[]? tags, int bookId);
    }
}