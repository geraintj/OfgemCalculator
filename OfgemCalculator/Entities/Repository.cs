using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfgemCalculator.Entities
{
    public class Repository : IRepository
    {
        private readonly CalculationsContext _context;

        public Repository(CalculationsContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync(Calculation calculation)
        {
            _context.Calculations.Add(calculation);
            return  await _context.SaveChangesAsync() > 0;
        }
    }
}
