using System.Data;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Model;
using project.Model.ViewModel;


namespace project.Controllers
{
    public class AdminController : Controller
    {
        DataContext db;

        public AdminController(DataContext dataContext)
        {
            db = dataContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult deletePost(int id)
        {

            try{
                db.Comments.Remove(
                    db.Comments.Where(com => com.id == id).First()
                );
                db.SaveChanges();
                return Ok();
            }
            catch(Exception){
                return StatusCode(400);
            }
        }
    }
}
