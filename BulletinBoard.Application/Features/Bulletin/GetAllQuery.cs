using BulletinBoard.Application.Common.Interfaces;
using BulletinBoard.Application.DTO.Bulletin;
using MediatR;

namespace BulletinBoard.Application.Features.Bulletin
{
    public class GetAllQuery : IRequest<IList<BulletinGetAllDto>>
    {
    }

    public class GetAllQueryHandler(IBulletin bulletinService) : IRequestHandler<GetAllQuery, IList<BulletinGetAllDto>>
    {
        private readonly IBulletin _bulletinService = bulletinService;
        public async Task<IList<BulletinGetAllDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var result = await _bulletinService.GetAll();
            return result.ToList();
        }
    }
}
