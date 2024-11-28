using XsisPos.Dto;
using XsisPos.Model;

namespace XsisPos.Api.Repositories
{
    public interface ICategoryRepository<T> : IRepository<T> where T : class
    {
    }

    public class CategoryRepository : ICategoryRepository<CategoryDto>
    {
        private XsisPosDbContext _context;
        public CategoryRepository(XsisPosDbContext context)
        {
            _context = context;
        }

        public CategoryDto Create(CategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _context.Categories.Select(o => new CategoryDto()
            {
                Id = o.Id,
                Initial = o.Initial,
                Name = o.Name,
                Description = o.Description,
                Active = o.Active,
                Created = o.Created,
            });
        }

        public CategoryDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> GetByParentId(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto Update(CategoryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
