using BulletinBoard.Application.DTO.Bulletin;

namespace BulletinBoard.Application.Common.Interfaces
{
    public interface IBulletin
    {
        Task<bool> Create(BulletinDto dto);
        Task<BulletinByIdDto> GetById(int id);
        Task<IEnumerable<BulletinGetAllDto>> GetAll();
        Task<bool> Update(UpdateBulletinDto dto);
        Task<bool> Delete(int id);
    }
}
