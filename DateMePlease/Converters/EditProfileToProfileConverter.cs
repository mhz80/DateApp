using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DateMePlease.Entities;
using DateMePlease.Models;

namespace DateMePlease.Converters
{
  public class EditProfileToProfileConverter : AutoMapper.ITypeConverter<EditProfileViewModel, Profile>
  {
    public Profile Convert(AutoMapper.ResolutionContext context)
    {
      // Only support in=place conversion
      if (context.IsSourceValueNull || context.DestinationValue == null) return null;

      var src = (EditProfileViewModel)context.SourceValue;
      var dest = (Profile)context.DestinationValue;

      // Update 
      dest.Introduction = src.Introduction;
      dest.LookingFor = src.LookingFor;
      dest.Pitch = src.Pitch;
      dest.Demographics.Birthdate = src.Birthdate;
      dest.Demographics.Gender = src.Gender;
      dest.Demographics.Orientation = src.Orientation;

      // Update or Create
      foreach (var vm in src.Photos)
      {
        var toUpdate = dest.Photos.SingleOrDefault(p => p.Id == vm.Id); //overwrite Equals or replace comparison with an Id comparison
        if (toUpdate == null)
        {
          var newPhoto = AutoMapper.Mapper.Map<Photo>(vm);
          newPhoto.DateAdded = DateTime.UtcNow;
          dest.Photos.Add(newPhoto);
        }
        else
        {
          AutoMapper.Mapper.Map(vm, toUpdate);
        }
      }

      // Delete
      foreach (var photo in dest.Photos)
      {
        if (!src.Photos.Any(p => p.Id == photo.Id))
        {
          dest.Photos.Remove(photo);
        }
      }

      return dest;

    }
  }
}