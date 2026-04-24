using MediatR;
using Microsoft.AspNetCore.Mvc;
using News_Management.Application.Features.Menus.Commands;
using News_Management.Application.Features.Menus.Queries;



namespace News_Management.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {

        private readonly IMediator _mediator; //
        public MenusController(IMediator mediator)
        {
            _mediator = mediator;
        }







        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllMenusQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMenuCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteMenuCommand { Id = id });
            return Ok(result);
        }
    }
}
