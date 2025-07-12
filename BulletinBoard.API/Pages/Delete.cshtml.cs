using BulletinBoard.Application.Features.Bulletin;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DeleteModel : PageModel
{
    private readonly IMediator _mediator;

    public DeleteModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty]
    public int Id { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Id = id;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var result = await _mediator.Send(new DeleteQuery { Id = Id });
        if (result)
            return RedirectToPage("Index");

        ModelState.AddModelError("", "Failed to delete bulletin.");
        return Page();
    }
}