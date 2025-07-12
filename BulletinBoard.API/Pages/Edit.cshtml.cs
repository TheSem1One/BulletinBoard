using BulletinBoard.Application.DTO.Bulletin;
using BulletinBoard.Application.Features.Bulletin;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class EditModel : PageModel
{
    private readonly IMediator _mediator;

    public EditModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty]
    public UpdateCommand UpdateCommand { get; set; }

    public BulletinByIdDto ExistingBulletin { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var bulletin = await _mediator.Send(new GetByIdQuery { Id = id });
        if (bulletin == null)
            return NotFound();

        UpdateCommand = new UpdateCommand
        {
            Id = bulletin.Id,
            Title = bulletin.Title,
            Category = bulletin.Category,
            Description = bulletin.Description,
            SubCategory = bulletin.SubCategory
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        
        var existing = await _mediator.Send(new GetByIdQuery { Id = UpdateCommand.Id });
        if (existing == null)
            return NotFound();

       
        var commandToUpdate = new UpdateCommand
        {
            Id = UpdateCommand.Id,
            Title = string.IsNullOrWhiteSpace(UpdateCommand.Title) ? existing.Title : UpdateCommand.Title,
            Category = string.IsNullOrWhiteSpace(UpdateCommand.Category) ? existing.Category : UpdateCommand.Category,
            Description = string.IsNullOrWhiteSpace(UpdateCommand.Description) ? existing.Description : UpdateCommand.Description,
            SubCategory = string.IsNullOrWhiteSpace(UpdateCommand.SubCategory) ? existing.SubCategory : UpdateCommand.SubCategory
        };

        var result = await _mediator.Send(commandToUpdate);
        if (result)
            return RedirectToPage("Index");

        ModelState.AddModelError("", "Failed to update bulletin.");
        return Page();
    }
}
