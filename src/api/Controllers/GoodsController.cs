using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAdo.System.Core.Application.Storage.Goods.Commands.Create;
using ShopAdo.System.Core.Application.Storage.Goods.Commands.Delete;
using ShopAdo.System.Core.Application.Storage.Goods.Commands.Update;
using ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodDetail;
using ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodsList;

namespace ShopAdo.WebAPI.Controllers
{
    public class GoodsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GoodsListViewModel>> GetAll()
        {
            try
            {
                return Ok(await Mediator.Send(new GetGoodsListQuery()));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GoodDto>> Create([FromBody] CreateGoodCommand command)
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
        public async Task<ActionResult<GoodDetailViewModel>> GetById(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetGoodDetailQuery {GoodId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GoodDto>> Update(int id,
            [FromBody] UpdateGoodCommand command)
        {
            try
            {
                command.GoodId = id;
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
        public async Task<ActionResult<GoodDto>> Delete(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteGoodCommand {GoodId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}