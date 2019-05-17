using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using DataAccessLayer;
using Entities;
using IBusinessLogicLayer;

namespace BusinessLogicLayer
{
    public class BusinessLogic : IBusinessLogicLayer.IBusinessLogicLayer
    {
        

        public User LogIn(User logInUser)
        {
            var lm = new LoginMapper();
            return lm.LogIn(logInUser);
        }

        public int GetIdByLogin(string login)
        {
            var lm = new LoginMapper();
            return lm.GetIdByLogin(login);
        }

        public string GetRoleById(int id)
        {
            var lm = new LoginMapper();
            return lm.GetRoleById(id);
        }

        public void AddComment(int postId, string text, int userId)
        {
            var cm = new CommentMapper();
            cm.AddComment(postId,text,userId);
        }

        public IEnumerable<Comment> GetPostComments(int postId)
        {
            var cm = new CommentMapper();
            return cm.GetPostComments(postId);
        }

        public IEnumerable<Post> GetPosts()
        {
            var pm = new PostMapper();
            return pm.GetPosts();
        }

        public Post GetPostById(int id)
        {
            var pm = new PostMapper();
            return pm.GetPostById(id);
        }

        public int AddPost(string text, string title, int userId)
        {
            var pm = new PostMapper();
            return pm.AddPost(text, title, userId);
        }

        public List<User> GetUsers()
        {
            var um = new UserMapper();
            return um.GetUsers();
        }

        public void Subscribe(int authorId, int subscriberId)
        {
            var um = new UserMapper();
            um.Subscribe(authorId, subscriberId);
        }

        public void Unsubscribe(int authorId, int subscriberId)
        {
            var um = new UserMapper();
            um.Unsubscribe(authorId, subscriberId);
        }

        public Entities.User GetUserById(int id)
        {
            var um = new UserMapper();
            return um.GetUserById(id);
        }

        public bool CheckSubscription(int authorId, int subscriberId)
        {
            var um = new UserMapper();
            return um.CheckSubscription(authorId, subscriberId);
        }

        public IEnumerable<Post> GetUserPosts(User user)
        {
            var um = new UserMapper();
            return um.GetUserPosts(user);
        }

        public IEnumerable<User> GetSubscriptions(int id)
        {
            var um = new UserMapper();
            return um.GetSubscriptions(id);
        }
    }
}