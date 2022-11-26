using ClassLibrary;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(User user)
        {

            if (user.isim==null)
                { return View(new User()); }
            else 
            {             
                _user.Add(user);
                return RedirectToAction("GetAll");
                
            }
        }
        
        public IActionResult Delete()
        {
            var _id = Int32.Parse(RouteData.Values["id"].ToString());
            _user.Delete(_id);
            return RedirectToAction("GetAll");
        }

        public IActionResult Update(User user)
        {

            if (user.isim == null)
            {
                return View(new User());
            }
            else
            {
                var id = Int32.Parse(RouteData.Values["id"].ToString());
                User u = _user.GetById(id);
                u.isim = user.isim;
                u.puan = user.puan;
                _user.Update(u);
                return RedirectToAction("GetAll");
            }
        }
        public IActionResult Profil()
        {
            var id = Int32.Parse(RouteData.Values["id"].ToString());
            User u = _user.GetById(id);
            return View(u);
        }

        public IActionResult GetAll()
        {
            return View(_user.GetAll());
        }
    }
}
