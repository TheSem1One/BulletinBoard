using BulletinBoard.Application.DTO.Bulletin;
using BulletinBoard.Application.Features.Bulletin;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly IMediator _mediator;

    public IndexModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IList<BulletinGetAllDto> Bulletins { get; set; } = new List<BulletinGetAllDto>();

    public async Task OnGetAsync()
    {
        Bulletins = await _mediator.Send(new GetAllQuery());
    }
}