using BulletinBoard.Application.Common.Interfaces;
using BulletinBoard.Application.DTO.Bulletin;
using MediatR;

namespace BulletinBoard.Application.Features.Bulletin
{
    public class GetByIdQuery : IRequest<BulletinByIdDto>
    {
        public int Id { get; set; }
    }

    public class GetByIdQueryHandler(IBulletin bulletinService) : IRequestHandler<GetByIdQuery, BulletinByIdDto>
    {
        private readonly IBulletin _bulletinService = bulletinService;
        public async Task<BulletinByIdDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _bulletinService.GetById(request.Id);
            return result;
        }
    }
}
