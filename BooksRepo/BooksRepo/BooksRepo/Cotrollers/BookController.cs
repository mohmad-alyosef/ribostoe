using BooksRepo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BooksRepo.Cotrollers
{
    public class BookController
    {
        public BookController()
        {
            
        }

        public List<Book> GetAllBooks()
        {
            using (var context = new BRDbContext())
            {
                return context.Books.ToList<Book>();
            }
        }

        public Book GetBookByName(string bookName)
        {
            using (var context = new BRDbContext())
            {
                return context.Books.Where(b => b.Name.Equals(bookName)).FirstOrDefault<Book>();
            }
        }

        public async Task<Guid> AddBook()
        {
            using (var context = new BRDbContext())
            {
                Book book = new Book();

                Console.WriteLine("Do You Want To Add New Author Or Choose An Existing Author ? (1/2)");
                var authorAction = Int32.Parse(Console.ReadLine());

                if (authorAction == 1)
                {
                    Author author = new Author();
                    Console.WriteLine("Enter Author Name: ");
                    author.Name = Console.ReadLine().ToString();

                    await context.Authors.AddAsync(author);

                    await context.SaveChangesAsync();
                    if (context.SaveChangesAsync().IsCompleted)
                    {
                        Console.WriteLine("Adding Author To Database Was Completed Successfully !");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong while we try to add the author, Please try again ...");
                    }

                    Console.WriteLine("Enter Book Name: ");
                    string bookName = Console.ReadLine().ToString();

                    Console.WriteLine("Enter Book Price: ");
                    double bookPrice = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Book Title: ");
                    string bookTitle = Console.ReadLine().ToString();

                    Console.WriteLine("Enter Book Version Number: ");
                    double bookVersion = double.Parse(Console.ReadLine());

                    book.Id = Guid.NewGuid();
                    book.AuthorId = author.Id;
                    book.Name = bookName;
                    book.Price = bookPrice;
                    book.Title = bookTitle;
                    book.VersionNum = bookVersion;
                    
                    var addingResultawait = await context.Books.AddAsync(book);

                    await context.SaveChangesAsync();
                    if (context.SaveChangesAsync().IsCompleted)
                    {
                        Console.WriteLine("Adding Book To Database Was Completed Successfully");
                        return book.Id;
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong while we try to add the book, Please try again ...");
                        return Guid.Empty;
                    }
                }

                if (authorAction == 2) {
                    bool nullSafity = false;

                    while (nullSafity != true)
                    {
                        Console.WriteLine("Please Enter Author Name To Search In Database: ");

                        string authorName = Console.ReadLine();

                        var author = context.Authors.Where(a => a.Name == authorName).FirstOrDefault();

                        if (author != null)
                        {
                            nullSafity = true;

                            Console.WriteLine("Enter Book Name: ");
                            string bookName = Console.ReadLine().ToString();

                            Console.WriteLine("Enter Book Price: ");
                            double bookPrice = double.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Book Title: ");
                            string bookTitle = Console.ReadLine().ToString();

                            Console.WriteLine("Enter Book Version Number: ");
                            double bookVersion = double.Parse(Console.ReadLine());

                            book.Id = Guid.NewGuid();
                            book.AuthorId = author.Id;
                            book.Name = bookName;
                            book.Price = bookPrice;
                            book.Title = bookTitle;
                            book.VersionNum = bookVersion;

                            var addingResultawait = await context.Books.AddAsync(book);

                            await context.SaveChangesAsync();
                            if (context.SaveChangesAsync().IsCompleted)
                            {
                                Console.WriteLine("Adding Book To Database Was Completed Successfully");
                                return book.Id;
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong while we try to add the book, Please try again ...");
                                return Guid.Empty;
                            }

                        }
                        else
                        {
                            Console.WriteLine("We Couldn't Find The Author, Please Choose One Of These Actions: \n 1- Re-Enter Author Name. \n 2- Close This Operation. ");
                            var x = Int32.Parse(Console.ReadLine());

                            if (x == 2)
                            {
                                break;
                            }
                        }
                    }

                }
                return book.Id;
            }
        }

        public async void RemoveBook(string bookName)
        {
            using (var context = new BRDbContext())
            {
                var book = context.Books.Where(b => b.Name.Contains(bookName)).FirstOrDefault();

                var removiningResult = context.Books.Remove(book);

                await context.SaveChangesAsync();
                if (context.SaveChangesAsync().IsCompleted)
                {
                    Console.WriteLine("Removing Book From Database Was Completed Successfully");
                }
                else
                {
                    Console.WriteLine("Something went wrong while we try to remove the book, Please try again ...");
                }
            }
        }

        public async Task<Guid> UpdateBook(string bookName, string bookTitle, double bookPrice, double bookVersion)
        {
            using (var context = new BRDbContext())
            {
                var book = context.Books.Where(b => b.Name.Contains(bookName)).FirstOrDefault();

                book.Title = bookTitle;
                book.Price = bookPrice;
                book.VersionNum = bookVersion;

                await context.SaveChangesAsync();
                if (context.SaveChangesAsync().IsCompleted)
                {
                    Console.WriteLine("Updating Book Details In Database Was Completed Successfully");
                    return book.Id;
                }
                else
                {
                    Console.WriteLine("Something went wrong while we try to update the book details, Please try again ...");
                    return Guid.Empty;
                }
            }
        }
        public async Task<Guid> UpdateBook(string bookName,string bookTitle, double bookPrice)
        {
            using (var context = new BRDbContext())
            {
                var book = context.Books.Where(b => b.Name.Contains(bookName)).FirstOrDefault();

                book.Title = bookTitle;
                book.Price = bookPrice;

                await context.SaveChangesAsync();
                if (context.SaveChangesAsync().IsCompleted)
                {
                    Console.WriteLine("Updating Book Details In Database Was Completed Successfully");
                    return book.Id;
                }
                else
                {
                    Console.WriteLine("Something went wrong while we try to update the book details, Please try again ...");
                    return Guid.Empty;
                }
            }
        }
        public async Task<Guid> UpdateBook(string bookName, string bookTitle)
        {
            using (var context = new BRDbContext())
            {
                var book = context.Books.Where(b => b.Name.Contains(bookName)).FirstOrDefault();

                book.Title = bookTitle;

                await context.SaveChangesAsync();
                if (context.SaveChangesAsync().IsCompleted)
                {
                    Console.WriteLine("Updating Book Details In Database Was Completed Successfully");
                    return book.Id;
                }
                else
                {
                    Console.WriteLine("Something went wrong while we try to update the book details, Please try again ...");
                    return Guid.Empty;
                }
            }
        }
        public async Task<Guid> UpdateBook(string bookName, double bookPrice)
        {
            using (var context = new BRDbContext())
            {
                var book = context.Books.Where(b => b.Name.Contains(bookName)).FirstOrDefault();

                book.Price = bookPrice;

                await context.SaveChangesAsync();
                if (context.SaveChangesAsync().IsCompleted)
                {
                    Console.WriteLine("Updating Book Details In Database Was Completed Successfully");
                    return book.Id;
                }
                else
                {
                    Console.WriteLine("Something went wrong while we try to update the book details, Please try again ...");
                    return Guid.Empty;
                }
            }
        }
    }
}
