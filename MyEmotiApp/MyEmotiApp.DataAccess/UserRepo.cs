using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyEmotiApp.DataAccess.Interfaces;
using MyEmotiApp.Models;

namespace MyEmotiApp.DataAccess
{
    public class UserRepo(AppDbContext context) : IUserRepo
    {
        public async Task<bool> Register(string username, string password)
        {
            if (await context.Users.AnyAsync(u => u.Username == username))
                return false;

            var user = new User
            {
                Username = username,
                HashPassword = HashPass(password)
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<User> Login(string username, string password)
        {
            var us = context.Users.Where(u=>u.Username!=null);

            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user != null && user.HashPassword == HashPass(password))
            {
                return user;
            }

            return new User();
        }

        private string HashPass(string notHashedPass)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(notHashedPass);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (var byteValue in hashBytes)
                {
                    hashStringBuilder.Append(byteValue.ToString("x2"));
                }
                return hashStringBuilder.ToString();
            }
        }
    }
}
