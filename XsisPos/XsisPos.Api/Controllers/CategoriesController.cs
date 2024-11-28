using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XsisPos.Api.Repositories;
using XsisPos.Dto;
using XsisPos.Model;

namespace XsisPos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private ICategoryRepository<CategoryDto> _repo;
        public CategoriesController(ILogger<CategoriesController> logger, ICategoryRepository<CategoryDto> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> All()
        {
            return _repo.GetAll();
        }
    }
}
