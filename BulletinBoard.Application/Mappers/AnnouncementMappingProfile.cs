using AutoMapper;
using BulletinBoard.Application.Common.Interfaces;
using BulletinBoard.Application.DTO.Bulletin;
using BulletinBoard.Application.Features.Bulletin;
using BulletinBoard.Domain.Entity;
using System.Collections.Generic;

namespace BulletinBoard.Application.Mappers
{
    public class AnnouncementMappingProfile : Profile
    {
        public AnnouncementMappingProfile()
        {
            CreateMap<Announcements, BulletinDto>().ReverseMap();
            CreateMap<UpdateBulletinDto, UpdateCommand>().ReverseMap();
            CreateMap<BulletinDto, CreateCommand>().ReverseMap();
            CreateMap<BulletinByIdDto, Announcements>().ReverseMap();
            CreateMap<BulletinGetAllDto, Announcements>().ReverseMap();
        }
    }
}
