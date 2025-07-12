using BulletinBoard.Application.DTO.Bulletin;
using BulletinBoard.Application.Features.Bulletin;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DetailsModel : PageModel
{
    private readonly IMediator _mediator;

    public DetailsModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public BulletinByIdDto Bulletin { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Bulletin = await _mediator.Send(new GetByIdQuery { Id = id });
        if (Bulletin == null)
            return NotFound();

        return Page();
    }
}