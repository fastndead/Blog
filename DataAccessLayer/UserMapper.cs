using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Entities;
namespace DataAccessLayer
{
    public class UserMapper
    {
        private BaseDataAccess Db;

        public UserMapper()
        {
            this.Db = new BaseDataAccess();
        }

        public List<Entities.User> GetUsers()
        {
            
            var reader = Db.GetDataReader("GetUsers");
            var users = new List<User>();
            while (reader.Read()) {
                var user = new User();

                user.Id = (int) reader["c_id"];
                user.Name = (string) reader["c_name"];
                users.Add(user);
            }
            return users;
        }
        public void Subscribe(int authorId, int subscriberId)
        {
            var parameters = new List<DbParameter>();
            parameters.Add(Db.GetParameter("authorId", authorId));
            parameters.Add(Db.GetParameter("subscriberId", subscriberId));
            var res = Db.ExecuteNonQuery("Subscribe", parameters );
        }
        public void Unsubscribe(int authorId, int subscriberId)
        {
            var parameters = new List<DbParameter>();
            parameters.Add(Db.GetParameter("authorId", authorId));
            parameters.Add(Db.GetParameter("subscriberId", subscriberId));
            Db.ExecuteNonQuery("Unsubscribe", parameters );
        }
        
        public bool CheckSubscription(int authorId, int subscriberId)
        {
            var parameters = new List<DbParameter>();
            parameters.Add(Db.GetParameter("authorId", authorId));
            parameters.Add(Db.GetParameter("subscriberId", subscriberId));
            try
            {
                int result = (int) Db.ExecuteScalar("CheckSubscription", parameters);
            }
            catch//todo костыль
            {
                return false;
            }

            return true;

        }
        
        public Entities.User GetUserById(int id)
        {
            var reader = Db.GetDataReader("GetUser", Db.GetParameter("id", id));
            if (reader.Read())
            {
                var user = new User();

                user.Id = (int) reader["c_id"];
                user.Name = (string) reader["c_name"];
                user.Posts = GetUserPosts(user);
                return user;
            }
            else
            {
                throw new Exception("UserMapper: GetUserById() error");
            }
        }

        public IEnumerable<Post> GetUserPosts(User user)
        {
            var reader = Db.GetDataReader("GetUserPosts", Db.GetParameter("id",user.Id));
            var posts = new List<Post>();
            while (reader.Read()) {
                var post = new Post();

                post.Id= (int)reader["id"];
                post.Text = (string)reader["text"];
                post.Title = (string) reader["title"];
                post.Rating= (int?) reader["rating"];
                post.CreateDate= (DateTime) reader["createDate"];
                post.Author = user;

                posts.Add(post);
            }
            return posts;
        }

        public IEnumerable<User> GetSubscriptions(int id)
        {
            var reader = Db.GetDataReader("GetSubscriptions", Db.GetParameter("id", id));
            var users = new List<User>();
            while (reader.Read())
            {
                var user = new User();

                user.Id = (int) reader["id"];
                user = GetUserById(user.Id);
                users.Add(user);
            }
           

            return users;
        }



    }
}