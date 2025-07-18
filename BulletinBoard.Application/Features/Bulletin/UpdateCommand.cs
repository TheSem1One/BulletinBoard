using AutoMapper;
using BulletinBoard.Application.Common.Interfaces;
using BulletinBoard.Application.DTO.Bulletin;
using BulletinBoard.Application.Mappers;
using MediatR;

namespace BulletinBoard.Application.Features.Bulletin
{
    public class UpdateCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } 
        public string? Category { get; set; } 
        public string? SubCategory { get; set; } 
    }

    public class UpdateCommandHandler(IBulletin bulletinService,IMapper mapper) : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBulletin _bulletinService = bulletinService;
        public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var mapper = _mapper.Map<UpdateCommand, UpdateBulletinDto>(request);
            return await _bulletinService.Update(mapper);
        }
    }
}
