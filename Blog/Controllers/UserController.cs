using System.Web.Mvc;
using BusinessLogicLayer;
using Entities;

namespace Blog.Controllers
{
    public class UserController : Controller
    {
        // GET
        public ActionResult User(int id)
        {
            var bl = new BusinessLogic();

            Entities.User user = bl.GetUserById(id);
            return View(user);
        }

        public ActionResult Subscriptions(int id)
        {
            var bl = new BusinessLogic();
            return View(bl.GetSubscriptions(id));
        }
        
        
        
        public bool CheckSubscription(int id)
        {
            if (id == int.Parse(HttpContext.User.Identity.Name))
            {
                return true;
            }
            var bl = new BusinessLogic();

            return (bl.CheckSubscription(int.Parse(HttpContext.User.Identity.Name), id));
        }
        
        
        public bool ToggleSubscription(int id)
        {
            if (id == int.Parse(HttpContext.User.Identity.Name))
            {
                return true;
            }
            var bl = new BusinessLogic();
            if (bl.CheckSubscription(int.Parse(HttpContext.User.Identity.Name), id))
            {
                bl.Unsubscribe(int.Parse(HttpContext.User.Identity.Name), id);
            }
            else
            {
                bl.Subscribe(int.Parse(HttpContext.User.Identity.Name), id);
            }

            return CheckSubscription(id);
        }
    }
}