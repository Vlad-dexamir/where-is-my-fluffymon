namespace Utils.Repository
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : BaseEntity
    {
        
    }
}