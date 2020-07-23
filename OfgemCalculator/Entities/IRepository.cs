using System.Threading.Tasks;

namespace OfgemCalculator.Entities
{
    public interface IRepository
    {
        Task<bool> SaveAsync(Calculation calculation);
    }
}