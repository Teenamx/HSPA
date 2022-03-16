using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dc;

        public UserRepository(DataContext dc)
        {
            this.dc = dc;
        }

     

        public async Task<User> Authenticate(string userName, string passwordText)
        {
            var user= await dc.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null || user.PasswordKey==null)
                return null;
            if(!MatchPasswordHash(passwordText,user.Password,user.PasswordKey))
            {
                return null;
            }
            return user;


            //&& x.Password == password);
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                
             var passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));
                for(int i=0;i < passwordhash.Length;i++)
                {
                    if (passwordhash[i] != password[i])
                        return false;
                }

                return true;

            }
        }

        public void Register(string userName, string password)
        {
            byte[] passwordhash, passwordKey;
            using(var hmac=new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
            User user = new User();
            user.UserName = userName;
            user.Password = passwordhash;
            user.PasswordKey = passwordKey;

            dc.Users.Add(user);
            

        }
       
        public async Task<bool> UserAlreadyExists(string userName)
        {
            return await dc.Users.AnyAsync(x => x.UserName == userName);
        }
    }
}
