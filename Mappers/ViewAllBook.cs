using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Models;

namespace api.Mappers
{
    public static class ViewAllBook
    {
        public static AllBookDto ToViewAllBook(this BookItemBase bookItemBase, string author, int commented, ICollection<Category>? categories) {
            return new AllBookDto() {
                Name = bookItemBase.Name,
                Status = bookItemBase.Status,
                CurrentChapter = bookItemBase.CurrentChapter,
                Description = bookItemBase.Description,
                Author = author,
                Voted = bookItemBase.Voted,
                Rating = bookItemBase.Rating,
                Liked = bookItemBase.Liked,
                Viewed = bookItemBase.Viewed,
                Followed = bookItemBase.Followed,
                Commented = commented,
                Categories = categories,
            };
        }
    }
}