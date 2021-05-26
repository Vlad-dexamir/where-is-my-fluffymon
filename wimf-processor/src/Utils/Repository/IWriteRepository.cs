using System.Threading.Tasks;

namespace Utils.Repository
{
    public interface IWriteRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);

        Task Delete(string id);
    }
}