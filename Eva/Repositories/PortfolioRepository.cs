using Eva.Context;
using Eva.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Eva.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly EvaDbContext _context;

        public PortfolioRepository(EvaDbContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> GetByIdAsync(int portfolioId)
        {
            return await _context.Portfolios.Include(p => p.Trades).FirstOrDefaultAsync(p => p.PortfolioId == portfolioId);
        }
    }
}
