using AutoMapper;
using BulletinBoard.Application.Common.Interfaces;
using BulletinBoard.Application.DTO.Bulletin;
using BulletinBoard.Application.Mappers;
using BulletinBoard.Domain.Entity;
using BulletinBoard.Infrastructure.Helpers;
using BulletinBoard.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Infrastructure.Services
{
    public class BulletinService(DatabaseContext context, UpdateHelper update,
    IMapper mapper) : IBulletin
    {
        private readonly IMapper _mapper = mapper;
        private readonly UpdateHelper _update = update;
        private readonly DatabaseContext _context = context;

        public async Task<bool> Create(BulletinDto dto)
        {
            var bulletin = _mapper.Map<BulletinDto, Announcements>(dto);
            await _context.Announcements.AddAsync(bulletin);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<BulletinByIdDto> GetById(int id)
        {
            var buletin = await _context.Announcements
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var map = _mapper.Map<Announcements, BulletinByIdDto>(buletin);
            return map;
        }

        public async Task<IEnumerable<BulletinGetAllDto>> GetAll()
        {
            var announcements = _context.Announcements.Where(x => x.Status == true).ToListAsync();
            var map =
                _mapper.Map<IList<Announcements>, IList<BulletinGetAllDto>>(announcements.Result
                    .ToArray());
            return map;
        }

        public async Task<bool> Update(UpdateBulletinDto dto)
        {
            var bulletin = await _context.Announcements
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            var updateBulletin = _update.Update(bulletin, dto);

            _context.Announcements.Update(updateBulletin);
            var update = await _context.SaveChangesAsync();

            if (update > 0) return true;
            else throw new Exception("Update failed");
        }

        public async Task<bool> Delete(int id)
        {
            var operation = await _context.Announcements.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (operation > 0) return true;
            else throw new Exception("Delete failed");
        }
    }
}
