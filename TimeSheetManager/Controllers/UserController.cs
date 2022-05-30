using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeSheetManager.Library.DataAccess;
using TimeSheetManager.Library.Models;

namespace TimeSheetManager.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        [Authorize]
        [HttpGet]
        public UserModel Get()
        {
            string id = RequestContext.Principal.Identity.GetUserId();
            UserData data = new UserData();
            return data.GetUserById(id).First();
        }


      
        // POST: api/User
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/User/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/User/5
        //public void Delete(int id)
        //{
        //}
    }
}
