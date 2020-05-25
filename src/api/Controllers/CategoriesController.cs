using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAdo.System.Core.Application.Storage.Categories;
using ShopAdo.System.Core.Application.Storage.Categories.Commands.Create;
using ShopAdo.System.Core.Application.Storage.Categories.Commands.Delete;
using ShopAdo.System.Core.Application.Storage.Categories.Commands.Update;
using ShopAdo.System.Core.Application.Storage.Categories.Queries.Get;
using ShopAdo.System.Core.Application.Storage.Categories.Queries.Get.AsList;

namespace ShopAdo.WebAPI.Controllers
{
    public class CategoriesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriesListViewModel>> GetAll()
        {
            try
            {
                return Ok(await Mediator.Send(new GetCategoriesAsListQuery()));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryLookupDto>> Create([FromBody] CreateCategoryCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryLookupDto>> GetById(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetCategoryQuery {CategoryId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryLookupDto>> Update(int id,
            [FromBody] UpdateCategoryCommand command)
        {
            try
            {
                command.CategoryId = id;
                return Ok(await Mediator.Send(command));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryLookupDto>> Delete(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteCategoryCommand {CategoryId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}