

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
        /// <summary>
        /// Retourne le profil public d'un utilisteur
        /// </summary>
        /// <param name="id">id utilisateur</param>
        /// <returns>Utilisateur</returns>
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
        [Route("api/v1/user/all")]
        public string GetAllUser()
        {
            IUserRepository user = new UserRepository();
            var result = user.GetAll();
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
        [Route("api/v1/lesson/{id}")]
        public string GetLesson(int id)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Get(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/all")]
        public string GetAllLesson()
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetAll();
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/Category/{id}")]
        public string GetLessonByCat(int id)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetLessonByCat(id);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/futur/{id}")]
        public string GetLessonFutur(int iduser)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetLessonByUserInFewTime(iduser);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/filter/{start}/{end}/{zip}")]
        public string GetLessonFilter(DateTime start, DateTime end, string zip)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetFilter(start, end, zip);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }

        [HttpGet]
        [Route("api/v1/lesson/filter/cat/{start}/{end}/{cat}")]
        public string GetLessonFilterByCat(DateTime start, DateTime end, int cat)
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.GetFilterByCat(start, end, cat);
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
        public HttpResponseMessage PostUserCreate([FromBody] User user
             )
        {
            IUserRepository manageUser = new UserRepository();
            var result = manageUser.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
       [HttpPost]
       [Route("api/v1/user/update")]
        public HttpResponseMessage PostUserUpdate([FromBody] User user
             )
        {
            IUserRepository manageUser = new UserRepository();
            var result = manageUser.Update(user);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        

        [HttpPost]
        [Route("api/v1/user/delete")]
        public HttpResponseMessage PostUserDelete([FromBody] User user)
        {
            IUserRepository managerUser = new UserRepository();
            var result = managerUser.Remove(user.UserId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/create")]
        public HttpResponseMessage PostLessonCreate([FromBody] Lesson lesson
             )
        {
            ILessonRepository manageLesson = new LessonRepository();
            var result = manageLesson.Add(lesson);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/update")]
        public HttpResponseMessage PostLessonUpdate([FromBody] Lesson lesson
           
             )
        {
            ILessonRepository manageLesson = new LessonRepository();
            var result = manageLesson.Update(lesson);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/user/connect")]
        public HttpResponseMessage PostUserConnect([FromBody] User user
            )
        {
            IUserRepository manageUser = new UserRepository();
            var result = manageUser.GetId(user.Email, user.Password);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/delete")]
        public HttpResponseMessage PostLessonDelete([FromBody] Lesson lesson)
        {
            ILessonRepository manageLesson = new LessonRepository();
            var result = manageLesson.Remove(lesson.LessonId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/lesson/book/create")]
        public HttpResponseMessage PostLessonBookCreate([FromBody] Booking booking
             )
        {
            ILessonRepository lesson = new LessonRepository();
            var result = lesson.Book(booking.user_id, booking.lesson_id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/v1/user/email")]
        public string GetUserByMail([FromBody] User user)
        {
            IUserRepository manageUser = new UserRepository();
            var result = manageUser.GetUserByMail(user.Email);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
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

