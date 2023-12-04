using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using TestProject.Entities;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.Controllers
{
    [Route("api/grocerylist")]
    [ApiController]
    [Authorize]
    public class GroceryListController : ControllerBase
    {
        private readonly IGroceryListService _groceryservice;
        public GroceryListController(IGroceryListService groceryservice)
        {
            _groceryservice = groceryservice;
        }

        [HttpGet("all/{UserId}")]
        public ActionResult Get([FromQuery] GroceryQuery? query = null)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var list = _groceryservice.GetLists(userId, query);
            return Ok(list);
        }

        [HttpGet("{ListId}")]
        public ActionResult GetList([FromRoute] int ListId, [FromQuery] GroceryQuery? query = null)
        {
            var list = _groceryservice.GetList(ListId, query);
            return Ok(list);
        }

        [HttpPost]
        public ActionResult Post([FromBody] GroceryListDTO dto)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var result = _groceryservice.PostList(dto, userId);
            return Ok(result);
        }

        [HttpPost("{ListId}")]
        public ActionResult PostEntry([FromRoute] int ListId, [FromBody] GroceryListEntryDTO dto)
        {
            var result = _groceryservice.AddEntry(ListId, dto);
            return Ok(result);
        }

        [HttpDelete("entry/{ListId}")]
        public ActionResult DeleteEntry([FromRoute] int ListId, [FromBody] GroceryListEntryDTO dto)
        {
            var result = _groceryservice.DeleteEntry(ListId, dto.Name, User);
            return Ok(result);
        }

        [HttpDelete("{ListId}")]
        public ActionResult DeleteList([FromRoute] int ListId)
        {
            var result = _groceryservice.DeleteList(ListId, User);
            return Ok(result);
        }

        [HttpPut("{ListId}")]
        public ActionResult EditList([FromRoute] int ListId, [FromBody] EditGroceryDTO query)
        {
            var result = _groceryservice.EditList(ListId, query);
            return Ok(result);
        }

    }
}
