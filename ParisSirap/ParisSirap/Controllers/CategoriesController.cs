using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParisSirap.Models;
using ParisSirap.Services;

namespace ParisSirap.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryInfoRepository _categoryInfoRepository;

        public CategoriesController(ICategoryInfoRepository categoryInfoRepository)
        {
            _categoryInfoRepository = categoryInfoRepository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categoryEntities = _categoryInfoRepository.GetCategories();
            var results = Mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
            return Ok(results);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int categoryId)
        {
            var category = _categoryInfoRepository.GetCategory(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            var result = Mapper.Map<CategoryDto>(category);
            return Ok(result);
        }

        [HttpGet("letter")]
        public IActionResult GetCategoriesByName(string letter)
        {
            var categoryEntities = _categoryInfoRepository.GetCategoriesByFirstNamesLetter(letter);
            if (categoryEntities == null)
            {
                return NotFound();
            }
            var results = Mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
            return Ok(results);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!_categoryInfoRepository.CategoryExists(categoryId))
            {
                return NotFound();
            }

            var categoryToDelete = _categoryInfoRepository.GetCategory(categoryId);
            _categoryInfoRepository.DeleteCategory(categoryToDelete.Id);

            if (!_categoryInfoRepository.Save())
            {
                return StatusCode(500, "Problem while handling request");
            }
            return NoContent();
        }
    }
}
