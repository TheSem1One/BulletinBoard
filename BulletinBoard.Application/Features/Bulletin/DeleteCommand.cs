using BulletinBoard.Application.Common.Interfaces;
using MediatR;

namespace BulletinBoard.Application.Features.Bulletin
{
    public class DeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteQueryHandler(IBulletin bulletinService) : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IBulletin _bulletinService = bulletinService;
        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var result = await _bulletinService.Delete(request.Id);
            return result;
        }
    }
}
