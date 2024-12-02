namespace XsisPos.Api.Repositories
{
    public interface IRepository<out T, in U> //where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByParentId(int id);
        T GetById(int id);
        IEnumerable<T> GetByIds(List<int> ids);
        T Create(U dto);
        T Update(U dto);
        bool Delete(int id);
    }
}
