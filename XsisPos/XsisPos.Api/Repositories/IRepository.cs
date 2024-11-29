namespace XsisPos.Api.Repositories
{
    public interface IRepository<T> //where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByParentId(int id);
        T GetById(int id);
        IEnumerable<T> GetByIds(List<int> ids);
        T Create(T entity);
        T Update(T entity);
        bool Delete(int id);
    }
}
