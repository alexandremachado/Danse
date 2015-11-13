using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Danse.Controllers
{
    public class UsersApiController : ApiController
    {
        [HttpGet]
        [Route("api/v1/user/public/{id}")]
        public string getPublicUser(int id)
        {
            IUserRepository user = new UserRepository();
            result = user.GetPublic(id);

            var json = new JavaScriptSerializer().Serialize(result);

            return json;
        }

        [HttpGet]
        [Route("api/v1/user/private/{id}")]
        public string getPrivateUser(int id)
        {
            IUserRepository user = new UserRepository();
            result = user.GetPrivate(id);

            var json = new JavaScriptSerializer().Serialize(result);

            return json;
        }















    }
}
