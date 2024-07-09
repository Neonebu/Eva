using Eva.Context;
using Eva.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Eva.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EvaDbContext _context;

        public UserRepository(EvaDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
