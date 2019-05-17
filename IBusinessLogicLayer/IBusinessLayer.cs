using Entities;
using System.Collections.Generic;

namespace IBusinessLogicLayer
{
    public interface IBusinessLogicLayer
    {
        User LogIn(User logInUser);

        int GetIdByLogin(string login);

        string GetRoleById(int id);

        void AddComment(int postId, string text, int userId);

        IEnumerable<Comment> GetPostComments(int postId);

        IEnumerable<Post> GetPosts();

        Post GetPostById(int id);

        int AddPost(string text, string title, int userId);

        List<User> GetUsers();

        void Subscribe(int authorId, int subscriberId);

        void Unsubscribe(int authorId, int subscriberId);

        bool CheckSubscription(int authorId, int subscriberId);

        IEnumerable<Post> GetUserPosts(User user);

        IEnumerable<User> GetSubscriptions(int id);
        
    }
}