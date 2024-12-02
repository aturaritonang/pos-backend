using XsisPos.Dto;
using XsisPos.Model;

namespace XsisPos.Api.Repositories
{
    public interface ICategoryRepository<T, U> : IRepository<T, U>
        where T : class
        where U : class
    {
    }

    public class CategoryRepository : ICategoryRepository<CategoryDto, ChangeCategoryDto>
    {
        private XsisPosDbContext _context;
        public CategoryRepository(XsisPosDbContext context)
        {
            _context = context;
        }

        public CategoryDto Create(ChangeCategoryDto dto)
        {
            try
            {
                Category entity = new Category();
                entity.Name = dto.Name;
                entity.Initial = dto.Initial;
                entity.Description = dto.Description;
                entity.Active = dto.Active;

                _context.Categories.Add(entity);
                _context.SaveChanges();

                return new CategoryDto()
                {
                    Id = entity.Id,
                    Initial = dto.Initial,
                    Name = dto.Name,
                    Description = dto.Description,
                    Active = dto.Active
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //public CategoryDto Create(ChangeCategoryDto dto)
        //{
        //    throw new NotImplementedException();
        //}

        public bool Delete(int id)
        {
            Category? category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _context.Categories
                .Select(o => new CategoryDto()
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

        public IEnumerable<CategoryDto> GetByIds(List<int> ids)
        {
            return _context.Categories.Where(o => ids.Contains(o.Id))
                .Select(o => new CategoryDto()
                {
                    Id = o.Id,
                    Initial = o.Initial,
                    Name = o.Name,
                    Description = o.Description,
                    Active = o.Active,
                    Created = o.Created,
                });
        }

        public IEnumerable<CategoryDto> GetByParentId(int id)
        {
            throw new NotImplementedException();
        }

        //public CategoryDto Update(CategoryDto entity)
        //{
        //    Category? category = _context.Categories
        //        .Where(c => c.Id == entity.Id).FirstOrDefault();

        //    if (category == null)
        //    {
        //        entity.Id = 0;
        //        return entity;
        //    }

        //    category.Name = entity.Name;
        //    category.Initial = entity.Initial;
        //    category.Description = entity.Description;
        //    category.Active = entity.Active;

        //    _context.SaveChanges();

        //    entity.Created = category.Created;
        //    return entity;
        //}

        public CategoryDto Update(ChangeCategoryDto dto)
        {
            try
            {
                Category? entity = _context.Categories
                    .Where(c => c.Id == dto.Id).FirstOrDefault();

                if (entity == null)
                {
                    entity.Id = 0;
                    return new CategoryDto()
                    {
                        Id = (int)dto.Id,
                        Initial = dto.Initial,
                        Name = dto.Name,
                        Description = dto.Description,
                        Active = dto.Active,
                    };
                }

                entity.Name = dto.Name;
                entity.Initial = dto.Initial;
                entity.Description = dto.Description;
                entity.Active = dto.Active;

                _context.SaveChanges();
                return new CategoryDto()
                {
                    Id = entity.Id,
                    Initial = entity.Initial,
                    Name = entity.Name,
                    Description = entity.Description,
                    Active = entity.Active,
                };
            }
            catch (Exception e)
            {
                return new CategoryDto();
            }
        }
    }
}
