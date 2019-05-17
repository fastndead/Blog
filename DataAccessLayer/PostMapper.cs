using System.Collections.Generic;
using System.Data.Common;
using Entities;

namespace DataAccessLayer
{
    public class PostMapper
    {
        private BaseDataAccess Db;

        public PostMapper()
        {
            this.Db = new BaseDataAccess();
        }

        public IEnumerable<Entities.Post> GetPosts()
        {
            var um = new UserMapper();
            var reader = Db.GetDataReader("GetAllPosts");
            var posts = new List<Post>();
            while (reader.Read()) {
                var post = new Post();

                var id = (int)reader["authorId"];
                post.Text = (string) reader["text"];
                post.Title = (string) reader["title"];
                post.Id = (int) reader["id"];


                post.Author = um.GetUserById(id);
                posts.Add(post);
            }

            return posts;
        }

        public Post GetPostById(int id)
        {
            var cm = new CommentMapper();
            var um = new UserMapper();
            var reader = Db.GetDataReader("GetPostById", Db.GetParameter("id", id));
            var post = new Post();
            while (reader.Read()) {
                post.Id = (int) reader["id"];
                post.Title = (string) reader["title"];
                post.Text = (string) reader["text"];
                post.Comments = cm.GetPostComments(post.Id);

                var userId = (int) reader["userId"];
                post.Author = um.GetUserById(userId);
            }
            return post;
        }

        public int AddPost(string text, string title, int userId)
        {
            var parameters = new List<DbParameter>();
            parameters.Add(Db.GetParameter("title", title));
            parameters.Add(Db.GetParameter("text", text));
            parameters.Add(Db.GetParameter("idAuthor", userId));
            int postId = (int)Db.ExecuteScalar("AddPost", parameters);
            return postId;
        }
    }
}