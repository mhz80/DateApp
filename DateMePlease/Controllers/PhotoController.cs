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
  public class PhotoController : ApiController
  {
    private IDateMePleaseRepository _repository;
    public PhotoController(IDateMePleaseRepository repository)
    {
      _repository = repository;
    }

    public IHttpActionResult Post([FromBody]PhotoViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var profile = _repository.GetProfileByUserName(User.Identity.Name);

      var newPhoto = AutoMapper.Mapper.Map<Photo>(model);
      newPhoto.DateAdded = DateTime.UtcNow;
      profile.Photos.Add(newPhoto);

      if (_repository.SaveAll())
      {
        return Created("", AutoMapper.Mapper.Map<PhotoViewModel>(newPhoto));
      }
      else
      {
        return BadRequest("Failed to create photo.");
      }
    }
  }
}