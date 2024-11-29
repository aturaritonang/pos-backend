using Microsoft.AspNetCore.Mvc;
using XsisPos.Api.Repositories;
using XsisPos.Dto;

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
        public IActionResult All()
        {
            try
            {
                _logger.LogInformation("Get all categories");
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult ById(int id)
        {
            try
            {
                return Ok(_repo.GetById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpGet("any")]
        public IActionResult ByIds([FromQuery] List<int> ids)
        {
            try
            {
                return Ok(_repo.GetByIds(ids));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public CategoryDto Create(ModifyCategoryDto modifyCategoryDto)
        {
            return _repo.Create(new CategoryDto()
            {
                Initial = modifyCategoryDto.Initial,
                Name = modifyCategoryDto.Name,
                Description = modifyCategoryDto.Description,
                Active = modifyCategoryDto.Active
            });
        }

        [HttpPut]
        public CategoryDto Update(ModifyCategoryDto modifyCategoryDto)
        {
            return _repo.Update(new CategoryDto()
            {
                Id = (int)modifyCategoryDto.Id,
                Initial = modifyCategoryDto.Initial,
                Name = modifyCategoryDto.Name,
                Description = modifyCategoryDto.Description,
                Active = modifyCategoryDto.Active
            });
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
