using Menu_Default_WEBAPI.Infrastructure;
using Menu_Default_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Menu_Default_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryRepository categoryRepository,ILogger<CategoryController> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        // GET: api/<CategoryController>
        //[Route("GetAll")]http://yourdomain.com/GetAll
        [HttpGet("GetAll")]//http://yourdomain.com/api/controllerName/GetAll
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<CategoryModel> CategoryModels = _categoryRepository.GetAll();
                return Ok(CategoryModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in CategoryController.Get.");

                return StatusCode(500, "An error occurred while processing the request.");
            }

        }

        // GET api/<CategoryController>/5
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                CategoryModel? categoryModel = await _categoryRepository.GetById(Id);
                if (categoryModel == null)
                {
                    return NotFound();
                }
                return Ok(categoryModel);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in CategoryController.GetById.");

                return StatusCode(500, "An error occurred while processing the request.");
            }

        }

        // POST api/<CategoryController>
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryModel CategoryModel)
        {
            try
            {
                await _categoryRepository.Add(CategoryModel);
                return Ok(new { Message = "CategoryModel added successfully.", CategoryModel = CategoryModel });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in CategoryController.AddFood.");

                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut("UpdateCategory/{Id}")]
        public async Task<IActionResult> UpdateCategory(Guid Id, [FromBody] CategoryModel CategoryModel)
        {
            try
            {
                CategoryModel? ExistingCategoryModel = await _categoryRepository.GetById(Id);
                if (ExistingCategoryModel == null)
                {
                    return NotFound();
                }
                ExistingCategoryModel.Id = CategoryModel.Id;
                ExistingCategoryModel.CategoryName = CategoryModel.CategoryName;
                await _categoryRepository.Update(ExistingCategoryModel);
                return Ok(new { Message = "CategoryModel updated successfully.", CategoryModel = ExistingCategoryModel });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in CategoryController.UpdateFood.");

                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                CategoryModel? ExistingCategoryModel = await _categoryRepository.GetById(Id);
                if (ExistingCategoryModel == null)
                {
                    return NotFound();
                }
                await _categoryRepository.Delete(ExistingCategoryModel);
                return Ok($"CategoryModel {Id} deleted successfully.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in CategoryController.Delete.");

                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
