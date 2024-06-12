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
        public static AllBookDto ToViewAllBookAddAuthor(this BookItemBase bookItemBase, string author = "Not Found") {
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
                Followed = bookItemBase.Followed
            };
        }

        public static AllBookDto ToViewAllBookAddCommited(this AllBookDto allBookDto, int commented = 0) {
            return new AllBookDto() {
                Name = allBookDto.Name,
                Status = allBookDto.Status,
                CurrentChapter = allBookDto.CurrentChapter,
                Description = allBookDto.Description,
                Author = allBookDto.Author,
                Voted = allBookDto.Voted,
                Rating = allBookDto.Rating,
                Liked = allBookDto.Liked,
                Viewed = allBookDto.Viewed,
                Followed = allBookDto.Followed,
                Commented = commented
            };
        }

        public static AllBookDto ToViewAllBookAddCategories(this AllBookDto allBookDto, ICollection<Category> categories) {
            return new AllBookDto() {
                Name = allBookDto.Name,
                Status = allBookDto.Status,
                CurrentChapter = allBookDto.CurrentChapter,
                Description = allBookDto.Description,
                Author = allBookDto.Author,
                Voted = allBookDto.Voted,
                Rating = allBookDto.Rating,
                Liked = allBookDto.Liked,
                Viewed = allBookDto.Viewed,
                Followed = allBookDto.Followed,
                Commented = allBookDto.Commented,
                Categories = categories
            };
        }
    }
}