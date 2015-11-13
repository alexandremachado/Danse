﻿using System;
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


        [HttpGet]
        [Route("api/v1/lesson/user/{id}")]
        public string getLessonUser(int id)
        {
            ILessonRepository user = new LessonRepository();
            result = user.GetLessonByUser(id);

            var json = new JavaScriptSerializer().Serialize(result);

            return json;
        }



        [HttpGet]
        [Route("api/v1/lesson/filter/{start}/{end}/{zip}")]
        public string getLessonFilter(string start, string end, string zip)
        {
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);

            ILessonRepository user = new LessonRepository();
            result = user.GetFilter(startDate, endDate, zip);

            var json = new JavaScriptSerializer().Serialize(result);

            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/book/list/{id}/{page}")]
        public string getLessonBookListbyUser(int id, int page)
        {
            ILessonRepository user = new LessonRepository();
            result = user.GetAllLessonByUser(id, page);

            var json = new JavaScriptSerializer().Serialize(result);

            return json;
        }











    }
}
