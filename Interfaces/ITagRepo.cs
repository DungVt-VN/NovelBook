using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ITagRepo
    {
        Task<ICollection<string>> GetTagByIdAsync(int bookId);
        Task<string?> UpdateBookTagAsync(string[]? tags, int bookId);
        Task<IEnumerable<Tag>> GetAllTagsAsync();
        Task<string?> DeleteTagAsync(int tagId);
        Task<string?> UpdateTagAsync(Tag tag);
        Task<string?> InsertTagAsync(List<Tag> tags);
    }
}