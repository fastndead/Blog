using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogicLayer;
using Entities;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles="user")]
        public ActionResult Index()
        {
           var bl = new BusinessLogic();
           return View(bl.GetPosts());
        }
        
        [Authorize(Roles="user")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        [Authorize(Roles="user")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        [Authorize(Roles="user")]
        public ActionResult MyPosts()
        {

            return Redirect("/User/User?id="+ User.Identity.Name);
        }

        [ChildActionOnly]
        [Authorize(Roles="user")]
        public PartialViewResult GetNavbar()
        {
            if (User.IsInRole("user"))
            {
                var buttons = new List<Button>();
                buttons.Add(new Button("/","All Posts"));
                buttons.Add(new Button("/Home/MyPosts","Your Posts"));
                buttons.Add(new Button("/User/Subscriptions?id=" + User.Identity.Name,"Your Subscriptions"));
                buttons.Add(new Button("/Post/NewPost","New Post"));
                buttons.Add(new Button("/Login/Logout","Log Out"));
                
                ViewBag.Buttons = buttons;
                
                return PartialView("_Navbar", ViewBag);
            }
            if (User.IsInRole("admin"))
            {
                var buttons = new List<Button>();
                buttons.Add(new Button("/","All Posts"));
                buttons.Add(new Button("/User/Subscriptions?id=" + User.Identity.Name,"Your Subscriptions"));
                buttons.Add(new Button("/Login/Logout","Log Out"));
                
                ViewBag.Buttons = buttons;
                
                return PartialView("_Navbar", ViewBag);
            }

            return null;
        }
    }
}