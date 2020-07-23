using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using OfgemCalculator.Entities;
using Xunit;

namespace CalculatorTests
{
    public class RepositoryTests
    {
        private readonly Mock<CalculationsContext> _context;

        public RepositoryTests()
        {
            var options = new DbContextOptionsBuilder().Options;
            _context = new Mock<CalculationsContext>(options);
        }

        [Fact]
        public async Task SaveChangesIsCalled()
        {
            // Arrange
            var repo = new Repository(_context.Object);

            // Act
            await repo.SaveAsync(new Calculation());

            // Verify
            _context.Verify(x => x.SaveChangesAsync(new CancellationToken()), Times.Once);
        }
    }
}
