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
        private IProductRepository<ProductDto, ChangeProductDto> _repo;
        public ProductsController(IProductRepository<ProductDto, ChangeProductDto> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult All()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ById(int id)
        {
            try
            {
                //ProductDto dto = _repo.GetById(id);
                //return Ok(new ChangeProductDto()
                //{
                //    Id = dto.Id,
                //    CategoryId = dto.Category.Id,
                //    Initial = dto.Initial,
                //    Name = dto.Name,
                //    Description = dto.Description,
                //    Active = dto.Active,
                //});
                return Ok(_repo.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ChangeProductDto changeProductDto)
        {
            return Ok(_repo.Create(changeProductDto));
        }

        [HttpPut]
        public IActionResult Update(ChangeProductDto changeProductDto)
        {
            return Ok(_repo.Update(changeProductDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_repo.Delete(id));
        }
    }
}
