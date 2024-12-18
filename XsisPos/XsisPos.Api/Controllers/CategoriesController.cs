﻿using Microsoft.AspNetCore.Mvc;
using XsisPos.Api.Repositories;
using XsisPos.Dto;

namespace XsisPos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private ICategoryRepository<CategoryDto, ChangeCategoryDto> _repo;
        public CategoriesController(ILogger<CategoriesController> logger, ICategoryRepository<CategoryDto, ChangeCategoryDto> repo)
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
        public IActionResult Create(ChangeCategoryDto changeCategoryDto)
        {
            return Ok(_repo.Create(changeCategoryDto));
        }

        [HttpPut]
        public IActionResult Update(ChangeCategoryDto changeCategoryDto)
        {
            return Ok(_repo.Update(changeCategoryDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_repo.Delete(id));
        }
    }
}
