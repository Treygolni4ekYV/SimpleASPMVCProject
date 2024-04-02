using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Model;
using project.Model.ViewModel;

namespace MyApp.Namespace
{
    public class UserController : Controller
    {
        DataContext db;

        public UserController(DataContext dataContext){
            db = dataContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateDataView userData){
            
            //проверка на валидность данных
            if(!ModelState.IsValid){
                return View("CreateError", "Полученные данные невалидные");
            }

            //проверка на логин
            if(db.Users.Any(user => user.login == userData.login)){
                return View("CreateError", "Уже существует пользователь с данным логином");
            }
            
            //проверка на ник
            if(db.Users.Any(user => user.name == userData.userName)){
                return View("CreateError", "Уже существует пользователь с данным логином");
            }

            db.Users.Add(
                new project.Model.User{
                    name = userData.userName,
                    login = userData.login,
                    password = userData.password
                }
            );

            db.SaveChanges();

            return Redirect("~/Main/Index");
        }

    }
}
