namespace Data.Abstracts
{
    public interface IUnitOfWork
    {
       IRepository<T> Repositories<T>() where T : class;
       void SaveChanges();
    }
}
