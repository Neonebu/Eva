using Eva.Context;
using Eva.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Eva.Repositories
{
    public class ShareRepository : IShareRepository
    {
        private readonly EvaDbContext _context;

        public ShareRepository(EvaDbContext context)
        {
            _context = context;
        }

        public async Task<Share> GetBySymbolAsync(string symbol)
        {
            return await _context.Shares.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }
    }
}
