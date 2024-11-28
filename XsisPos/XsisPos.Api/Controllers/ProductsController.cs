using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XsisPos.Api.Repositories;
using XsisPos.Dto;

namespace XsisPos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository<ProductDto> _repo;
        public ProductsController(IProductRepository<ProductDto> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
