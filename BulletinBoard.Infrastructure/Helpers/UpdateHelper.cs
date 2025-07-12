using BulletinBoard.Domain.Entity;
using System.Globalization;
using BulletinBoard.Application.DTO.Bulletin;

namespace BulletinBoard.Infrastructure.Helpers
{
    public class UpdateHelper
    {
        public Announcements Update(Announcements announcements, UpdateBulletinDto dto)
        {
            if (!string.IsNullOrEmpty(dto.Category)) announcements.Category = dto.Category;
            if (!string.IsNullOrEmpty(dto.Description)) announcements.Description = dto.Description;
            if (!string.IsNullOrEmpty(dto.SubCategory)) announcements.SubCategory = dto.SubCategory;
            if (!string.IsNullOrEmpty(dto.Title)) announcements.Title = dto.Title;
            return announcements;
        }
    }
}
