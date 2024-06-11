// using System;
// using System.Collections.Generic;
// using System.Linq;
// using api.Models;
// using api.Data.Enums;
// using api.Data;

// namespace api
// {
//     public class WSeedTest
//     {
//         private readonly ApplicationDBContext _context;

//         public WSeedTest(ApplicationDBContext context)
//         {
//             _context = context;
//         }

//         public void SeedDataContext()
//         {
//             // Ensure database is created
//             if (!_context.Database.CanConnect())
//             {
//                 _context.Database.EnsureCreated();
//             }

//             // Seed Authors
//             if (!_context.Authors.Any())
//             {
//                 var authors = new List<Author>
//                 {
//                     new Author { Pseudonym = "Author 1", DateOfBirth = new DateTime(1970, 1, 1), Biography = "Biography of Author 1" },
//                     new Author { Pseudonym = "Author 2", DateOfBirth = new DateTime(1980, 2, 2), Biography = "Biography of Author 2" }
//                 };

//                 _context.Authors.AddRange(authors);
//                 _context.SaveChanges();
//             }

//             // Seed Categories
            // if (!_context.Categories.Any())
            // {
            //     var categories = new List<Category>
            //     {
            //         new Category { CategoryName = "Fantasy" },
            //         new Category { CategoryName = "Science Fiction" },
            //         new Category { CategoryName = "Mystery" }
            //     };

            //     _context.Categories.AddRange(categories);
            //     _context.SaveChanges();
            // }

            // // Seed Tags
            // if (!_context.Tags.Any())
            // {
            //     var tags = new List<Tag>
            //     {
            //         new Tag { TagName = "Adventure" },
            //         new Tag { TagName = "Drama" },
            //         new Tag { TagName = "Romance" }
            //     };

            //     _context.Tags.AddRange(tags);
            //     _context.SaveChanges();
            // }

            // // Seed BookItems
            // if (!_context.BookItems.Any())
            // {
            //     var bookItems = new List<BookItemBase>
            //     {
            //         new Manga
            //         {
            //             BookId = 1,
            //             Name = "Sample Book 1",
            //             Status = BookStatusEnum.Ongoing,
            //             CurrentChapter = 1,
            //             Description = "Description for Sample Book 1",
            //             AuthorId = 1,
            //             Voted = 100,
            //             Rating = 5,
            //             Liked = 200,
            //             Followed = 300,
            //             Viewed = 400,
            //             Commented = 500,
            //             Chapter = 10
            //         },
            //         new Manga
            //         {
            //             BookId = 2,
            //             Name = "Sample Book 2",
            //             Status = BookStatusEnum.Completed,
            //             CurrentChapter = 20,
            //             Description = "Description for Sample Book 2",
            //             AuthorId = 2,
            //             Voted = 150,
            //             Rating = 4,
            //             Liked = 250,
            //             Followed = 350,
            //             Viewed = 450,
            //             Commented = 550,
            //             Chapter = 20
            //         }
            //     };

            //     _context.BookItems.AddRange(bookItems);
            //     _context.SaveChanges();
            // }

            // // Seed BookCategories
            // if (!_context.BookCategories.Any())
            // {
            //     var bookCategories = new List<BookCategory>
            //     {
            //         new BookCategory { BookId = 1, CategoryId = 1 },
            //         new BookCategory { BookId = 1, CategoryId = 2 },
            //         new BookCategory { BookId = 2, CategoryId = 2 },
            //         new BookCategory { BookId = 2, CategoryId = 3 }
            //     };

            //     _context.BookCategories.AddRange(bookCategories);
            //     _context.SaveChanges();
            // }

            // // Seed BookTags
            // if (!_context.BookTags.Any())
            // {
            //     var bookTags = new List<BookTag>
            //     {
            //         new BookTag { BookId = 1, TagId = 1 },
            //         new BookTag { BookId = 1, TagId = 2 },
            //         new BookTag { BookId = 2, TagId = 2 },
            //         new BookTag { BookId = 2, TagId = 3 }
            //     };

            //     _context.BookTags.AddRange(bookTags);
            //     _context.SaveChanges();
            // }

            // // Seed AnotherNames
            // if (!_context.AnotherNames.Any())
            // {
            //     var anotherNames = new List<AnotherName>
            //     {
            //         new AnotherName { BookId = 1, Name = "Another Name 1" },
            //         new AnotherName { BookId = 2, Name = "Another Name 2" }
            //     };

            //     _context.AnotherNames.AddRange(anotherNames);
            //     _context.SaveChanges();
            // }

            // // Seed Comments
            // if (!_context.Comments.Any())
            // {
            //     var comments = new List<Comment>
            //     {
            //         new Comment { Content = "Great Book!", BookItemId = 1, UserId = "1" },
            //         new Comment { Content = "Amazing read.", BookItemId = 2, UserId = "2" }
            //     };

            //     _context.Comments.AddRange(comments);
            //     _context.SaveChanges();
            // }

            // // Seed UserBooks
            // if (!_context.UserBooks.Any())
            // {
            //     var userBooks = new List<UserBook>
            //     {
            //         new UserBook { UserId = "0d8ce4f1-34b4-4a5a-92a3-a38ad1b73a4a", BookItemId = 1, Liked = true, Followed = true, Rating = 5, Viewed = 100 },
            //         new UserBook { UserId = "164a3667-9635-4804-ac63-ccfbcc998782", BookItemId = 2, Liked = true, Followed = false, Rating = 4, Viewed = 50 }
            //     };

            //     _context.UserBooks.AddRange(userBooks);
            //     _context.SaveChanges();
            // }

            // // Seed Chapters
            // if (!_context.Chapters.Any())
            // {
            //     var chapters = new List<Chapter>
            //     {
            //         new Chapter { Title = "Chapter 1", ChapterNumber = 1, Content = "Content of Chapter 1", MangaId = 1 },
            //         new Chapter { Title = "Chapter 2", ChapterNumber = 2, Content = "Content of Chapter 2", MangaId = 1 }
            //     };

            //     _context.Chapters.AddRange(chapters);
            //     _context.SaveChanges();
            // }

//         }
//     }
// }
