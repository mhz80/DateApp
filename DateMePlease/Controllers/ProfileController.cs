using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DateMePlease.Data;

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

    public object Get()
    {
      return null;
    }

    public void Put(object model)
    {

    }
  }
}