using System;
using System.Collections.Generic;
using DateMePlease.Entities;
using DateMePlease.Models;
namespace DateMePlease.Data
{
  public interface IDateMePleaseRepository
  {
    Profile GetProfileByUserName(string username);
    Profile GetProfile(string memberName);
    List<RandomProfileViewModel> GetRandomProfiles(int numberToReturn);
    EditProfileViewModel GetProfileForEdit(string userName);
    List<InterestType> GetInterestTypes();

    bool SaveAll();
  }
}
