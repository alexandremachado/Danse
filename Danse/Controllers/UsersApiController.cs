

using Danse.Models.AccessBd;
using Danse.Models.Interfaces;
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
        public string Get(int id)
        {
            IUserRepository user = new UserRepository();
            var result = user.GetPublic(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/messenger/list/{id}")]
        public string Get(int id)
        {
            IMessengerRepository messenger = new IMessengerRepository();
            var result = messenger.GetList(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/user/private/{id}")]
        public string Get(int id)
        {
            IUserRepository user = new UserRepository();
            var result = user.GetPrivate(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/user/{id}")]
        public string Get(int id)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetLessonByUser(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/filter/{start}/{end}/{zip}")]
        public string Get(string start, string end, string zip)
        {
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetFilter(startDate, endDate, zip);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/book/{id}/{page}")]
        public string Get(int id, int page)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetAllBookByLesson(id, page);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/messenger/list/{id}")]
        public string Get(int id)
        {
            IMessengerRepository messenger = new MessengerRepository();
            var result = messenger.GetList(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpPost]
        [Route("api/v1/user/create")]
        public HttpResponseMessage Post(
            [FromBody] string first_name,
            [FromBody] string last_name,
            [FromBody] string gender,
            [FromBody] DateTime birth_date,
            [FromBody] string email,
            [FromBody] string phone,
            [FromBody] unknown image,
             )
        {
            IUserRepository user = new UserRepository();
            var result = user.Add(first_name, last_name, gender, birth_date, email, phone, image,);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/user/update")]
        public HttpResponseMessage Post(
            [FromBody] string first_name,
            [FromBody] string last_name,
            [FromBody] string gender,
            [FromBody] DateTime birth_date,
            [FromBody] string email,
            [FromBody] string phone,
            [FromBody] unknown image
             )
        {
            IUserRepository user = new UserRepository();
            var result = user.Modify(first_name, last_name, gender, birth_date, email, phone, image);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/user/delete")]
        public HttpResponseMessage Post([FromBody] int id)
        {
            IUserRepository user = new UserRepository();
            var result = user.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/create")]
        public HttpResponseMessage Post(
            [FromBody] string description,
            [FromBody] DateTime end_date,
            [FromBody] DateTime start_date,
            [FromBody] int nb_free,
            [FromBody] int nb_blocked,
            [FromBody] float price,
            [FromBody] string category,
            [FromBody] string title,
            [FromBody] string address
             )
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Add(description, end_date, start_date, nb_free, nb_blocked, price, category, title, address);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/update")]
        public HttpResponseMessage Post(
            [FromBody] string description,
            [FromBody] DateTime end_date,
            [FromBody] DateTime start_date,
            [FromBody] int nb_free,
            [FromBody] int nb_blocked,
            [FromBody] float price,
            [FromBody] string category,
            [FromBody] string title,
            [FromBody] string address
             )
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Update(description, end_date, start_date, nb_free, nb_blocked, price, category, title, address);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/delete")]
        public HttpResponseMessage Post([FromBody] int id)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/book/create")]
        public HttpResponseMessage Post(
            [FromBody] string description,
            [FromBody] DateTime end_date,
            [FromBody] DateTime start_date,
            [FromBody] int nb_free,
            [FromBody] float price,
            [FromBody] string category,
            [FromBody] string title,
            [FromBody] string address
             )
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Book(description, end_date, start_date, nb_free, price, category, title, address);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/messenger/send")]
        public HttpResponseMessage Post(
            [FromBody] string subject,
            [FromBody] string message
            )
        {
            IMessengerRepository messenger = new MessengerRepository();
            var result = messenger.Add(subject, message);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }

}

