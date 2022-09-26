using BooksRepo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksRepo.Cotrollers
{
    public class UserController
    {
        public User _user { get; set; }
        public UserController(User usr)
        {
            _user = usr;
        }

        public bool CheckUser()
        {
            using (var context = new BRDbContext())
            {
                bool result = false;
                var users = context.Users.ToList<User>();

                if (users != null)
                {
                    foreach (var user in users)
                    {
                        if ((_user.Name == user.Name) && (_user.Password == user.Password))
                        {
                            result = true;
                            break;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                return result;
            }
        }

        public async Task<Guid> AddUser()
        {
            using (var context = new BRDbContext())
            {
                User user = new User();
                Console.WriteLine("Enter Username: ");
                user.Name = Console.ReadLine().ToString();

                Console.WriteLine("Enter Password: ");
                user.Password = Console.ReadLine().ToString();

                var addResult = context.Users.Add(user);

                await context.SaveChangesAsync();
                if (context.SaveChangesAsync().IsCompleted)
                {
                    Console.WriteLine("Add User To Database Was Completed Successfully");
                    return user.Id;
                }
                else
                {
                    Console.WriteLine("Something went wrong while we try to add the user, Please try again ...");
                    return Guid.Empty;
                }
            }
        }
    }
}
