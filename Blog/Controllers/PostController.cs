using System;
using System.Web.Mvc;
using BusinessLogicLayer;


namespace Blog.Controllers
{
    public class PostController : Controller
    {
        // GET
        public ActionResult Post(int id)
        {
            var bl = new BusinessLogic();
            var post = bl.GetPostById(id);
            return View(post);
        }
        public JsonResult Comments(int id)
        {
            var bl = new BusinessLogic();
            var comments = bl.GetPostComments(id);
            foreach (var com in comments)
            {
                com.Author.Comments = null;
                com.Author.Posts = null;
            }
            return Json(comments, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public void AddComment(int postId, string text)
        {
            var bl = new BusinessLogic();
            bl.AddComment(postId, text, int.Parse(User.Identity.Name));
        }

        [Authorize(Roles="user")]

        public ActionResult NewPost()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize(Roles="user")]

        public ActionResult NewPost(string Title, string Text)
        {
            var bl = new BusinessLogic();
            var newPostId = bl.AddPost(Text, Title, int.Parse(User.Identity.Name));
            return Redirect("/Post/Post?id=" + newPostId);
        }
    }
}