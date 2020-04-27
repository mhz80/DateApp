using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DateMePlease.Data;
using DateMePlease.Entities;
using DateMePlease.Models;

namespace DateMePlease.Controllers
{
  [Authorize]
  public class ProfileController : ApiController
  {
    private IDateMePleaseRepository _repository;
    public ProfileController(IDateMePleaseRepository repository)
    {
      _repository = repository;
    }

    public EditProfileViewModel Get()
    {
      return _repository.GetProfileForEdit(User.Identity.Name);
    }

    public IHttpActionResult Put([FromBody]EditProfileViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var oldProfile = _repository.GetProfileByUserName(User.Identity.Name);

      if (model.MemberName != oldProfile.Member.MemberName)
      {
        return BadRequest("You can only update your own profile.");
      }

      AutoMapper.Mapper.Map(model, oldProfile);

      if (_repository.SaveAll())
      {
        return Ok(AutoMapper.Mapper.Map<EditProfileViewModel>(oldProfile)); // Copy back in case any business rules are executed
      }
      else
      {
        return BadRequest("Couldn't Save the profile.");
      }

    }
  }
}