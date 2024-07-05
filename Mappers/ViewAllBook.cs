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
        public static AllBookDto ToViewAllBook(this BookItemBase bookItemBase, string pseudonym, int commentCount, ICollection<String> categories, ICollection<string> tags, ICollection<string>? anotherNames)
        {
            return new AllBookDto
            {
                bookId = bookItemBase.BookId,
                Name = bookItemBase.Name,
                NameUrl = bookItemBase.NameUrl,
                OwnerId = bookItemBase.OwnerId,
                CoverImage = bookItemBase.CoverImage,
                Status = bookItemBase.Status,
                CurrentChapter = bookItemBase.CurrentChapter,
                Description = bookItemBase.Description,
                Author = pseudonym,
                Voted = bookItemBase.Voted,
                Rating = bookItemBase.Rating,
                Liked = bookItemBase.Liked,
                Viewed = bookItemBase.Viewed,
                Followed = bookItemBase.Followed,
                Commented = commentCount,
                Categories = categories,
                Tags = tags,
                AnotherNames = anotherNames,
                Actived = bookItemBase.Actived
            };
        }

        public static DetailBookDto ToViewDetailBook(this BookItemBase bookItemBase, string pseudonym, int commentCount, ICollection<String> categories, ICollection<String> tags, ICollection<String>? anotherNames)
        {
            return new DetailBookDto
            {
                bookId = bookItemBase.BookId,
                Name = bookItemBase.Name,
                NameUrl = bookItemBase.NameUrl,
                OwnerId = bookItemBase.OwnerId,
                CoverImage = bookItemBase.CoverImage,
                Status = bookItemBase.Status,
                CurrentChapter = bookItemBase.CurrentChapter,
                Description = bookItemBase.Description,
                Author = pseudonym,
                Voted = bookItemBase.Voted,
                Rating = bookItemBase.Rating,
                Liked = bookItemBase.Liked,
                Viewed = bookItemBase.Viewed,
                Followed = bookItemBase.Followed,
                Commented = commentCount,
                Categories = categories,
                Tags = tags,
                AnotherNames = anotherNames,
            };
        }

        public static (BookItemBase BookItem, string[]? Categories, string[]? Tags, string? Author)? ToEditBook(this EditBookDto editBookDto)
        {
            if (editBookDto != null)
            {
                var bookItemBase = new BookItemBase
                {
                    BookId = editBookDto.BookId,
                    Name = editBookDto.Name,
                    OwnerId = editBookDto.OwnerId,
                    Description = editBookDto.Description,
                    CoverImage = editBookDto.CoverImage,
                    Status = editBookDto.Status,
                    Actived = editBookDto.Actived
                };
                return (bookItemBase, editBookDto.Categories, editBookDto.Tags, editBookDto.Author);
            }
            return null;
        }

        public static (Chapter chapter, List<Images> images)? FromCreateChapter(this CreateChapterDto createChapterDto)
        {
            if (createChapterDto != null)
            {
                var chapter = new Chapter
                {
                    ChapterId = createChapterDto.ChapterId,
                    Title = createChapterDto.Title,
                    MangaId = createChapterDto.MangaId,
                    ChapterNumber = createChapterDto.ChapterNumber,
                    Content = createChapterDto.Content ?? "",
                    PublishedDate = createChapterDto.PublishedDate,
                    viewed = createChapterDto.Viewed,
                };
                return (chapter, createChapterDto.Images);
            }
            return null;
        }
    }
}