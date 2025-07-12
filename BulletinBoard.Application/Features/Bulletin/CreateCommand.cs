using AutoMapper;
using BulletinBoard.Application.Common.Interfaces;
using BulletinBoard.Application.DTO.Bulletin;
using BulletinBoard.Application.Mappers;
using MediatR;

namespace BulletinBoard.Application.Features.Bulletin
{
    public class CreateCommand : IRequest<bool>
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string SubCategory { get; set; } = null!;
    }

    public class CreateCommandHandler(IBulletin bulletinService, IMapper mapper) : IRequestHandler<CreateCommand, bool>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBulletin _bulletinService = bulletinService;
        public async Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var mapper = _mapper.Map<CreateCommand, BulletinDto>(request);
            var result = await _bulletinService.Create(mapper);
            return result;
        }
    }
}
