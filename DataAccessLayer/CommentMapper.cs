using System;
using System.Collections;
using Entities;
using System.Collections.Generic;
using System.Data.Common;

namespace DataAccessLayer
{
    public class CommentMapper
    {
        private BaseDataAccess Db;

        public CommentMapper()
        {
            this.Db = new BaseDataAccess();
        }

        public IEnumerable<Comment> GetPostComments(int postId)
        {
            var um = new UserMapper();
            var reader = Db.GetDataReader("GetPostComments", Db.GetParameter("id", postId));
            var comments = new List<Comment>();
            while (reader.Read())
            {
                var comment = new Comment();

                comment.Text = (string) reader["text"];
                var authorId = (int) reader["authorId"];
                comment.CreateDate = (DateTime) reader["createDate"];


                comment.Author = um.GetUserById(authorId);
                comments.Add(comment);
            }

            return comments;
        }


        public void AddComment(int postId, string text, int userId)
        {
            
            var parameters = new List<DbParameter>();
                parameters.Add(Db.GetParameter("id", postId));
                parameters.Add(Db.GetParameter("text", text));
                parameters.Add(Db.GetParameter("authorId", userId));

                try
                {
                    Db.ExecuteNonQuery("AddComment", parameters);
                }
                catch(Exception e)
                {
                    throw new Exception("CommentMapper: AddComment() |", e);
                }

                
        }

    }


}