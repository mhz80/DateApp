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

      return dest;

    }
  }
}