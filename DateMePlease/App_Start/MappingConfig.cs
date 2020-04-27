using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DateMePlease.Converters;
using DateMePlease.Entities;
using DateMePlease.Models;

namespace DateMePlease
{
  public static class MappingConfig
  {
    public static void RegisterMaps()
    {
      AutoMapper.Mapper.Initialize(config =>
      {
        config.CreateMap<Profile, RandomProfileViewModel>()
          .ForMember(dest => dest.MemberName,
                     opt => opt.MapFrom(src => src.Member.MemberName))
          .ForMember(dest => dest.PhotoUrl,
                     opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));

        config.CreateMap<Profile, EditProfileViewModel>()
          .ForMember(dest => dest.Birthdate,
                     opt => opt.MapFrom(src => src.Demographics.Birthdate))
          .ForMember(dest => dest.Gender,
                     opt => opt.MapFrom(src => src.Demographics.Gender))
          .ForMember(dest => dest.Orientation,
                     opt => opt.MapFrom(src => src.Demographics.Orientation))
          .ForMember(dest => dest.MemberName,
                     opt => opt.MapFrom(src => src.Member.MemberName));

        config.CreateMap<EditProfileViewModel, Profile>()
          .ConvertUsing<EditProfileToProfileConverter>();


      });
    }
  }
}