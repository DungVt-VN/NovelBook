using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IChapterRepo
    {
        Task<ICollection<Chapter>> GetAllChapterByIdAsync(int bookId);
        Task<int?> CreateChapterAsync(Chapter chapter);
        Task<string?> CreateImageAsync(List<Images> images, int chapterId);
        Task<IEnumerable<string>> GetAllImagesAsync(int chapterId);
        Task<int?> EditChapterAsync(Chapter chapter);
        Task<string?> UpdateImageAsync(List<Images> images, int? chapterId);
    }
}