using BulletinBoard.Application.DTO.Bulletin;
using BulletinBoard.Application.Features.Bulletin;
using BulletinBoard.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard.API.Controllers
{
    public class BulletinController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IList<BulletinGetAllDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BulletinByIdDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateCommand command)
        {
            var result = await _mediator.Send(command);
            if (result) return Created();
            else return BadRequest("Failed to create bulletin.");
        }

        [HttpPatch]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteQuery() { Id = id });
            return Ok(result);
        }
    }
}
