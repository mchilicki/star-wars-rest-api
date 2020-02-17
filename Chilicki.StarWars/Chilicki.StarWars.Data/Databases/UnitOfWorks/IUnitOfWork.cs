using System.Threading.Tasks;

namespace Chilicki.StarWars.Data.Databases.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void Dispose();
    }
}