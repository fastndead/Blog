using System.Web.Mvc;
using System.Web.Security;
using BusinessLogicLayer;
using Entities;

namespace Blog.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View() ;
        }
        [HttpPost]
        public ActionResult Login(Entities.User user, string ReturnUrl)
        {
            if (IsValid(user))
            {
                GetIdByLogin(user.Name);
                FormsAuthentication.SetAuthCookie(GetIdByLogin(user.Name).ToString(), false);
                return Redirect(ReturnUrl);
            }
            else
            {
                return View(user);
            }
        }
        
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        private int GetIdByLogin(string login)
        {
            var bl = new BusinessLogic();
            return bl.GetIdByLogin(login);
        }

        private bool IsValid(Entities.User user)
        {
            var bl = new BusinessLogic();
            if (TryValidateModel(user) && bl.LogIn(user) != null)
            {
                return true;
            }
            else
            {
                ViewBag.WrongPassword = "The username or password is incorrect";
                return false;
            }
        }
    }
}