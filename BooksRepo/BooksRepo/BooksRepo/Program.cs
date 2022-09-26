using BooksRepo;
using BooksRepo.Cotrollers;
using BooksRepo.Models;
using Microsoft.EntityFrameworkCore;

User user = new User();
Console.WriteLine("---Welcome To Books Repo---");

Console.WriteLine("Enter Username: ");
user.Name = Console.ReadLine().ToString();

Console.WriteLine("Enter Password: ");
user.Password = Console.ReadLine().ToString();

UserController userController = new UserController(user);

//-----------------

bool CheckUserResult = userController.CheckUser();

if (CheckUserResult == true)
{
    BookController bookController2 = new BookController();
    Console.WriteLine("-------All Books-------");
    Console.WriteLine("\n");
    Console.WriteLine("The Number Of Books In Repository Is: "+bookController2.GetAllBooks().Count);
    Console.WriteLine("\n");
    foreach (var item in bookController2.GetAllBooks())
    {
        Console.WriteLine($"Book Id: {item.Id}");
        Console.WriteLine($"Book Name: {item.Name}");
        Console.WriteLine("\n");
    }
    Console.WriteLine("-----------------------");
}
if (CheckUserResult == false)
{
    Console.WriteLine("Ooops! We Could not find you.");
    Console.WriteLine("You can try one of these actions: \n 1- Try Again. \n 2- Create new account.");
    Console.WriteLine("Please Enter Action Number:");
    int actionNum = Int32.Parse(Console.ReadLine());

    while (actionNum == 1)
    {
        Console.WriteLine("Enter Username: ");
        user.Name = Console.ReadLine().ToString();
        Console.WriteLine("Enter Password: ");
        user.Password = Console.ReadLine().ToString();

        CheckUserResult = userController.CheckUser();
        if (CheckUserResult == false)
        {
            Console.WriteLine("Ooops! We Could not find you.");
            Console.WriteLine("You can try one of these actions: \n 1- Try Again. \n 2- Create new account.");
            Console.WriteLine("Please Enter Action Number:");
            actionNum = Int32.Parse(Console.ReadLine());
        }
        if (CheckUserResult == true)
        {
            actionNum = 0;
            Console.WriteLine($"Welcome Back Mr. {user.Name} !");
        }
    }
    if (actionNum == 2)
    {
        userController.AddUser();
    }
}

Console.WriteLine("Do You Want To Add New Book To The Repository ? (y/n)");
string x = Console.ReadLine();
if (x.Equals("y"))
{
    BookController bookController1 = new BookController();
    bookController1.AddBook();
}
else if (x.Equals("n"))
{
    Console.WriteLine("Tsk, Looser :[");
}

BookController bookController = new BookController();

Console.WriteLine("Please Enter Book Name To Get Book Details: ");
Book bookDetails = bookController.GetBookByName(Console.ReadLine());
if (bookDetails != null)
{
    Console.WriteLine($" Book Id: {bookDetails.Id} \n Book Name: {bookDetails.Name} \n Book Title: {bookDetails.Title} \n Book Price: {bookDetails.Price} \n Book Version: {bookDetails.VersionNum} \n Book Author Id: {bookDetails.AuthorId}.");
}
else
{
    Console.WriteLine("No Books Found! \nPlease Try Again.");
}

Console.WriteLine("Please Enter Book Name to Update Book Details");
string n = Console.ReadLine();
Console.WriteLine("Enter New Title: ");
string t = Console.ReadLine();
Console.WriteLine("Enter New Price: ");
double p = double.Parse(Console.ReadLine());
Console.WriteLine("Enter New Version: ");
double v = double.Parse(Console.ReadLine());

Console.WriteLine();
bookController.UpdateBook(n,t,p,v);

Console.WriteLine("Press Any Key To Close The App.");
Console.ReadKey();

Console.WriteLine("---END---");
/*
96f65d12-95db-4197-a2b7-b8526feda3a3
cf162b02-a61d-4e10-b6dd-71cc2cce2ed6
33a53edf-27a1-40bf-9966-ca693cd7e9c3
4fcddff5-72d1-46c5-a46c-ec2ec7c8a675 
*/