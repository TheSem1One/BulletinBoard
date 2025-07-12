using BulletinBoard.Application.Common.Interfaces;
using MediatR;

namespace BulletinBoard.Application.Features.Bulletin
{
    public class DeleteQuery : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteQueryHandler(IBulletin bulletinService) : IRequestHandler<DeleteQuery, bool>
    {
        private readonly IBulletin _bulletinService = bulletinService;
        public async Task<bool> Handle(DeleteQuery request, CancellationToken cancellationToken)
        {
            var result = await _bulletinService.Delete(request.Id);
            return result;
        }
    }
}
