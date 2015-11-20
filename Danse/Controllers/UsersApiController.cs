

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
using System.Web.Http.Description;

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
       [Route("api/v1/user/create")]
        public HttpResponseMessage PostUserCreate([FromBody] User u
             )
        {
            IUserRepository user = new UserRepository();
            var result = user.Add(u);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
       [HttpPost]
       [Route("api/v1/user/update")]
        public HttpResponseMessage PostUserUpdate([FromBody] User u
             )
        {
            IUserRepository user = new UserRepository();
            var result = user.Update(u);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        

        [HttpPost]
        [Route("api/v1/user/delete")]
        public HttpResponseMessage PostUserDelete([FromBody] User u)
        {
            IUserRepository user = new UserRepository();
            var result = user.Remove(u.UserId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/create")]
        public HttpResponseMessage PostLessonCreate([FromBody] Lesson l
             )
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Add(l);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/update")]
        public HttpResponseMessage PostLessonUpdate([FromBody] Lesson l
           
             )
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Update(l);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/user/connect")]
        public HttpResponseMessage PostUserConnect([FromBody] User u
            )
        {
            IUserRepository user = new UserRepository();
            var result = user.GetId(u.Email,u.Password);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/delete")]
        public HttpResponseMessage PostLessonDelete([FromBody] Lesson l)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Remove(l.LessonId);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">id,user_id,subject,message</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/messenger/send")]
        public HttpResponseMessage PostMessengerSend([FromBody] Messenger message
            )
        {
            MessengerRepository messenger = new MessengerRepository();
            var result = messenger.Add(message);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/category/create")]
        public HttpResponseMessage PostCategoryCreate(
           [FromBody] Categorie categorie
            )
        {

            ICategorieRepository cat = new CategorieRepository();
            var result = cat.Add(categorie.Name);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }

}

