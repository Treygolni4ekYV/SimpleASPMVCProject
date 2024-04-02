using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Model;
using project.Model.ViewModel;
using SQLitePCL;

namespace project.Controllers
{
    public class MainController : Controller
    {
        private DataContext db;
        private const int commentsInPage = 5;

        public MainController(DataContext dataContext){
            db = dataContext;
        }


        [HttpGet]
        public IActionResult Index(int? page)
        {
            if(page == null){
                page = 1;
            }

            OpenCommentsView respData = new OpenCommentsView();
            respData.pageNumber = (int)page;

            int totalCommentsCount = 0;
            if((totalCommentsCount = db.Comments.Count()) >= commentsInPage){
                int pagesCount = Convert.ToInt32(Math.Ceiling((double)totalCommentsCount/commentsInPage));

                respData.pastPagesNumber = (int)page - 1;
                respData.nextPagesNumber = pagesCount - (int)page;
            }

            int startCommentIndex = ((int)page-1) * commentsInPage + 1;
            int endCommentIndex = (int)page * commentsInPage;

            List<Comment> findComments = db.Comments.Where(
                com => com.id >=  startCommentIndex & com.id <= endCommentIndex).ToList();

            foreach (Comment findComment in findComments)
            {
                string name = db.Users.Where(u => u.id == findComment.userid).First().name;

                respData.commentsToView.Add(new CommentView{
                    userName = name,
                    message = findComment.message
                });
            }

            return View(respData);
        }

        //создание постов
        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewCommentView commentData)
        {
            if(!ModelState.IsValid){
                return View("CreateError", "Невалидные данные");
            }    

            User currentUser = db.Users.FirstOrDefault(user => user.login == commentData.login)!;

            if(currentUser == null){
                return View("CreateError", "Данного пользователя не существует");
            }

            if (currentUser.password != commentData.password){
                return View("CreateError", "Пароль не подходит");
            }

            db.Comments.Add(
                new Comment{
                    user = currentUser,
                    message = commentData.comment,
                    data = DateTime.Now.ToShortTimeString()
                }
            );

            db.SaveChanges();

            return Redirect("~/Main/Index");

        }

    }
}
