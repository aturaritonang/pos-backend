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
            Category category = new Category();
            category.Name = entity.Name;
            category.Initial = entity.Initial;
            category.Description = entity.Description;
            category.Active = entity.Active;

            _context.Categories.Add(category);
            _context.SaveChanges();

            entity.Id = category.Id;
            entity.Created = category.Created;
            return entity;
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
            return _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto()
                {
                    Id = c.Id,
                    Initial = c.Initial,
                    Name = c.Name,
                    Description = c.Description,
                    Active = c.Active,
                    Created = c.Created,
                }).FirstOrDefault()!;
        }

        public IEnumerable<CategoryDto> GetByParentId(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto Update(CategoryDto entity)
        {
            Category? category = _context.Categories
                .Where(c => c.Id == entity.Id).FirstOrDefault();
            
            if (category == null)
            {
                entity.Id = 0;
                return entity;
            }

            category.Name = entity.Name;
            category.Initial = entity.Initial;
            category.Description = entity.Description;
            category.Active = entity.Active;

            _context.SaveChanges();

            entity.Created = category.Created;
            return entity;
        }
    }
}
