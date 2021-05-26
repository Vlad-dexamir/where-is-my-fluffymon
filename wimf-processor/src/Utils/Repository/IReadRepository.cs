using System.Collections.Generic;
using System.Threading.Tasks;

namespace Utils.Repository
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        Task<T> GetById(string id);

        Task<IEnumerable<T>> GetAll();
    }
}