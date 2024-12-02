using XsisPos.Dto;
using XsisPos.Model;

namespace XsisPos.Api.Repositories
{
    public interface IProductRepository<T, U> : IRepository<T, U> where T : class
    {
    }

    public class ProductRepository : IProductRepository<ProductDto, ChangeProductDto>
    {
        private XsisPosDbContext _context;
        public ProductRepository(XsisPosDbContext context)
        {
            _context = context;
        }

        public ProductDto Create(ChangeProductDto dto)
        {
            try
            {
                Product entity = new Product();
                entity.Name = dto.Name;
                entity.CategoryId = (int)dto.CategoryId!;
                entity.Initial = dto.Initial;
                entity.Description = dto.Description;
                entity.Active = dto.Active;

                _context.Products.Add(entity);
                _context.SaveChanges();

                CategoryDto categoryDto = _context.Categories
                    .Where(o => o.Id == entity.CategoryId)
                    .Select(o => new CategoryDto()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Initial = o.Initial,
                        Description = o.Description,
                        Active = o.Active
                    })
                    .FirstOrDefault()!;


                return new ProductDto()
                {
                    Id = entity.Id,
                    Initial = dto.Initial,
                    Name = entity.Name,
                    Description = entity.Description,
                    Active = entity.Active,
                    Category = categoryDto
                };
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public bool Delete(int id)
        {
            Product? entity = _context.Products.FirstOrDefault(c => c.Id == id);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products
                .Select(o => new ProductDto()
                {
                    Id = o.Id,
                    Initial = o.Initial,
                    Name = o.Name,
                    Description = o.Description,
                    Active = o.Active,
                    Created = o.Created,
                    Category = new CategoryDto()
                    {
                        Id = o.Category.Id,
                        Initial = o.Category.Initial,
                        Active = o.Category.Active
                    }
                });
        }

        public ProductDto GetById(int id)
        {
            return _context.Products
                .Where(c => c.Id == id)
                .Select(c => new ProductDto()
                {
                    Id = c.Id,
                    Category = new CategoryDto()
                    {
                        Id = c.Category.Id,
                        Initial = c.Category.Initial,
                    },
                    Initial = c.Initial,
                    Name = c.Name,
                    Description = c.Description,
                    Active = c.Active,
                    Created = c.Created,
                }).FirstOrDefault()!;
        }

        public IEnumerable<ProductDto> GetByIds(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetByParentId(int id)
        {
            throw new NotImplementedException();
        }

        public ProductDto Update(ChangeProductDto dto)
        {
            try
            {
                Product? entity = _context.Products
                    .Where(c => c.Id == dto.Id).FirstOrDefault();

                if (entity == null)
                {
                    entity.Id = 0;
                    return new ProductDto()
                    {
                        Id = (int)dto.Id,
                        Category = new CategoryDto()
                        {
                            Id = entity.Category.Id,
                            Initial = entity.Category.Initial,
                        },
                        Initial = dto.Initial,
                        Name = dto.Name,
                        Description = dto.Description,
                        Active = dto.Active,
                    };
                }

                entity.CategoryId = (int)dto.CategoryId;
                entity.Name = dto.Name;
                entity.Initial = dto.Initial;
                entity.Description = dto.Description;
                entity.Active = dto.Active;

                _context.SaveChanges();
                return new ProductDto()
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
                return null;
            }
        }
    }
}
