using Menu_Default_WEBAPI.Infrastructure;
using Menu_Default_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Menu_Default_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _foodRepository;
        private readonly ILogger<FoodController> _logger;
        public FoodController(IFoodRepository foodRepository,ILogger<FoodController> logger)
        {
            _foodRepository = foodRepository;
            _logger = logger;
        }
        // GET: api/<FoodController>
        //[Route("GetAll")]http://yourdomain.com/GetAll
        [HttpGet("GetAll")]//http://yourdomain.com/api/controllerName/GetAll
        public IActionResult GetAll()
        {
            try
            {
               IEnumerable<FoodModel> FoodModels =  _foodRepository.GetAll();
               return Ok(FoodModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in FoodController.Get.");

                return StatusCode(500, "An error occurred while processing the request.");
            }
            
        }

        // GET api/<FoodController>/5
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                FoodModel? foodModel =  await _foodRepository.GetById(Id);
                if (foodModel == null) 
                {
                    return NotFound();
                }
                return Ok(foodModel);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in FoodController.GetById.");

                return StatusCode(500, "An error occurred while processing the request.");
            }
            
        }

        // POST api/<FoodController>
        [HttpPost("AddFood")]
        public async Task<IActionResult> AddFood([FromBody] FoodModel FoodModel)
        {
            try
            {
                await _foodRepository.Add(FoodModel);
                return Ok(new { Message = "FoodModel added successfully.", FoodModel = FoodModel });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in FoodController.AddFood.");

                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        // PUT api/<FoodController>/5
        [HttpPut("UpdateFood/{Id}")]
        public async Task<IActionResult> UpdateFood(Guid Id, [FromBody] FoodModel FoodModel)
        {
            try
            {
                FoodModel? ExistingFoodModel = await _foodRepository.GetById(Id);
                if (ExistingFoodModel == null)
                {
                    return NotFound();
                }
                ExistingFoodModel.CategoryId = FoodModel.CategoryId;
                ExistingFoodModel.FoodTitle = FoodModel.FoodTitle;
                ExistingFoodModel.Price = FoodModel.Price;
                await _foodRepository.Update(ExistingFoodModel);
                return Ok(new { Message = "FoodModel updated successfully.", FoodModel = ExistingFoodModel });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in FoodController.UpdateFood.");

                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                FoodModel? ExistingFoodModel = await _foodRepository.GetById(Id);
                if (ExistingFoodModel == null)
                {
                    return NotFound();
                }
                await _foodRepository.Delete(ExistingFoodModel);
                return Ok($"FoodModel {Id} deleted successfully.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in FoodController.Delete.");

                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
