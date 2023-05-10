using Microsoft.AspNetCore.Mvc;
using Onis.Domain.Entities;
using static Onis.Domain.Contracts.IRepository;

namespace Onis.Catalog.Controllers
{
    [ApiController]
    [Route("api/catalog")]

    public class CatalogController:ControllerBase
    {
        private readonly IRepository<CatalogItem> itemsRepository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger, IRepository<CatalogItem> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            _logger.LogInformation("Method GetAllAsync invoked");
            try
            {
                var items = (await itemsRepository.GetAllAsync());
                return Ok(items);
            }
            catch(Exception e)
            {
                _logger.LogError("Error",e);
                return StatusCode(500);
            }
            

           

        }

       [HttpGet("{id}")]
        public async Task<ActionResult<CatalogItem>> GetByIdAsync(int id)
        {
            _logger.LogInformation("Method GetByIdAsync invoked");

            try
            {
                var item = await itemsRepository.GetAsync(id);


                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
            catch(Exception e)
            {
                _logger.LogError("Error", e);
                return StatusCode(500, new { IsError = true, Message = "Error on search" });
            }
           
        }


        //public async Task CreateAsync(CatalogItem catalog)
        //{

        //    await itemsRepository.CreateAsync(catalog);

        //    // return CreatedAtAction(nameof(GetByIdAsync), new { id = catalog.Id });

        //}
        [HttpPost]
        public async Task<IActionResult> PostAsync(CatalogItem catalog)
        {
            try
            {
                _logger.LogInformation("Method PostAsync invoked");

                await itemsRepository.CreateAsync(catalog);

                return StatusCode(200);

            }
            catch(Exception e)
            {
                _logger.LogError("Error", e);
                return StatusCode(500, new { IsError = true, Message = "Not created" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, CatalogItem updatedItem)
        {
            _logger.LogInformation("Method PutAsync invoked");

            try
            {
                var existingItem = await itemsRepository.GetAsync(id);

                if (existingItem == null)
                {
                    return NotFound();
                }

                existingItem.Name = updatedItem.Name;
                existingItem.Description = updatedItem.Description;
                existingItem.Price = updatedItem.Price;

                await itemsRepository.UpdateAsync(existingItem);

                return StatusCode(200);
            }
            catch(Exception e)
            {
                _logger.LogError("Error", e);
                return StatusCode(500);
            }

           

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteasync(int id)
        {
            _logger.LogInformation("Method Deleteasync invoked");

            try
            {
                var item = await itemsRepository.GetAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                await itemsRepository.RemoveAsync(item);

                return StatusCode(200);
            }
            catch(Exception e)
            {
                _logger.LogError("Error", e);
                return StatusCode(500);
            }

           
        }


    }
}
