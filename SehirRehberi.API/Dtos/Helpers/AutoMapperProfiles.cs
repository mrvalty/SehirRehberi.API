using AutoMapper;
using SehirRehberi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Dtos.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityForListDto>().ForMember(
                dest=>dest.PhotoUrl ,
                opt =>{opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url); // Kaynaktakinin yani city nin photo urlsini al
            });

            CreateMap<City, CityForDetailDto>();
            CreateMap<Photo, PhotoForCreationDto>();
            CreateMap<PhotoForReturnDto, Photo>();
        }
    }
}
