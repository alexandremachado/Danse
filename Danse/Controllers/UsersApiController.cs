

using Danse.Models.AccessBd;
using Danse.Models.Interfaces;
using Danse.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web;

namespace Danse.Controllers
{

    public class APIController : ApiController
    {

        [HttpGet]
        [Route("api/v1/user/public/{id}")]
        public string GetUserPublic(int id)
        {
            IUserRepository user = new UserRepository();
            var result = user.GetPublic(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/messenger/list/{id}")]
        public string GetMessengerListId(int id)
        {
            MessengerRepository messenger = new MessengerRepository();
            var result = messenger.Get(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }
        
        [HttpGet]
        [Route("api/v1/user/private/{id}")]
        public string GetUserPrivate(int id)
        {
            IUserRepository user = new UserRepository();
            var result = user.GetPrivate(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/user/{id}")]
        public string GetLessonUser(int id)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetLessonByUser(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/filter/{start}/{end}/{zip}")]
        public string GetLessonFilter(string start, string end, string zip)
        {
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetFilter(startDate, endDate, zip);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }
        
        [HttpGet]
        [Route("api/v1/lesson/book/{id}")]
        public string GetLessonBook(int id)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetAllBookByLesson(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/messenger/list/{id}")]
        public string GetMessengerList(int id)
        {
            MessengerRepository messenger = new MessengerRepository();
            var result = messenger.GetAllByLesson(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/category/list")]
        public string GetAllCategory()
        {
            ICategorieRepository category = new CategorieRepository();
            var result = category.GetAll();
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

       [HttpPost]
       // [Route("api/v1/user/create")]
        public HttpResponseMessage PostUserCreate(
            [FromBody] string first_name,
            [FromBody] string last_name,
            [FromBody] bool gender,
            [FromBody] DateTime birth_date,
            [FromBody] string email,
            [FromBody] string phone,
            [FromBody] string password,
            [FromBody] string image
             )
        {
            IUserRepository user = new UserRepository();
            var result = user.Add(new User(first_name, last_name, gender, birth_date, email, phone, password, image));
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
       [HttpPost]
      //  [Route("api/v1/user/update")]
        public HttpResponseMessage PostUserUpdate(
            [FromBody] string first_name,
            [FromBody] string last_name,
            [FromBody] bool gender,
            [FromBody] DateTime birth_date,
            [FromBody] string email,
            [FromBody] string phone,
            [FromBody] string password,
            [FromBody] string image
             )
        {
            IUserRepository user = new UserRepository();
            var result = user.Update(new User(first_name, last_name, gender, birth_date, email, phone, password, image));
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        

        [HttpPost]
        [Route("api/v1/user/delete")]
        public HttpResponseMessage PostUserDelete([FromBody] int id)
        {
            IUserRepository user = new UserRepository();
            var result = user.Remove(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/create")]
        public HttpResponseMessage PostLessonCreate(
            [FromBody] int idUser,
            [FromBody] string description,
            [FromBody] DateTime end_date,
            [FromBody] DateTime start_date,
            [FromBody] int nb_free,
            [FromBody] int nb_blocked,
            [FromBody] float price,
            [FromBody] int category,
            [FromBody] string title,
            [FromBody] string zip,
            [FromBody] string address
             )
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Add(new Lesson(description, start_date, end_date, nb_free, nb_blocked, price, title, address, zip, category, idUser));
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/update")]
        public HttpResponseMessage PostLessonUpdate(
            [FromBody] int idUser,
            [FromBody] string description,
            [FromBody] DateTime end_date,
            [FromBody] DateTime start_date,
            [FromBody] int nb_free,
            [FromBody] int nb_blocked,
            [FromBody] float price,
            [FromBody] int category,
            [FromBody] string title,
            [FromBody] string zip,
            [FromBody] string address
             )
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Update(new Lesson( description, start_date, end_date, nb_free, nb_blocked, price, title, address, zip, category, idUser));
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/delete")]
        public HttpResponseMessage PostLessonDelete([FromBody] int id)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Remove(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/book/create")]
        public HttpResponseMessage PostLessonBookCreate(
            [FromBody] int idUser,
            [FromBody] int idLesson
             )
        {

            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Book(idUser, idLesson);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/messenger/send")]
        public HttpResponseMessage PostMessengerSend(
            [FromBody] int id,
            [FromBody] int user_id,
            [FromBody] string subject,
            [FromBody] string message
            )
        {
            Messenger userMessenge = new Messenger(subject,  message, id, user_id);
            MessengerRepository messenger = new MessengerRepository();
            var result = messenger.Add(userMessenge);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/category/create")]
        public HttpResponseMessage PostCategoryCreate(
           [FromBody] string name
            )
        {
            ICategorieRepository cat = new CategorieRepository();
            var result = cat.Add(new Categorie(name));
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }

}

