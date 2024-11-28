using XsisPos.Dto;
using XsisPos.Model;

namespace XsisPos.Api.Repositories
{
    public interface IProductRepository<T> : IRepository<T> where T : class
    {
    }

    public class ProductRepository : IProductRepository<ProductDto>
    {
        private XsisPosDbContext _context;
        public ProductRepository(XsisPosDbContext context)
        {
            _context = context;
        }

        public ProductDto Create(ProductDto entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetByParentId(int id)
        {
            throw new NotImplementedException();
        }

        public ProductDto Update(ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
