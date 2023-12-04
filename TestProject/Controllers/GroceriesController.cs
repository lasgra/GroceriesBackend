using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestProject.Entities;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.Controllers
{
    [Route("api/grocery")]
    [ApiController]
    [Authorize]
    public class GroceriesController : ControllerBase
    {
        private readonly IGroceryEntryService _groceryListService;
        public GroceriesController(IGroceryEntryService groceryListService)
        {
            _groceryListService = groceryListService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<GroceryListEntry>> GetAll([FromQuery]GroceryQuery? query = null)
        {
            return Ok(_groceryListService.GetAll(query));
        }

        [HttpGet("{Id}")]
        public ActionResult<GroceryListEntry> Get([FromRoute]int Id)
        {
            var Entry = _groceryListService.GetById(Id);
            return Ok(Entry);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGroceryEntry([FromBody]GroceryListEntry Grocery)
        {
            _groceryListService.CreateGroceryEntry(Grocery);
            return Created();
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteGroceryEntry([FromRoute] int Id)
        {
            _groceryListService.DeleteGrocery(Id);
            return NoContent();
        }

        [HttpPut("{Id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult PutGroceryEntry([FromRoute] int Id, [FromBody] decimal Price)
        {
            _groceryListService.PutGrocery(Price, Id);
            return Ok();

        }
    }
}
