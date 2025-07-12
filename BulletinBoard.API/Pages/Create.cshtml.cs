using BulletinBoard.Application.Features.Bulletin;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateModel : PageModel
{
    private readonly IMediator _mediator;

    public CreateModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty]
    public CreateCommand CreateCommand { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var result = await _mediator.Send(CreateCommand);
        if (result)
            return RedirectToPage("Index");

        ModelState.AddModelError("", "Failed to create bulletin.");
        return Page();
    }
}