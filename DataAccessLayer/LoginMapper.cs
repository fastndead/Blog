using System;
using System.Collections.Generic;
using System.Data.Common;
using Entities;

namespace DataAccessLayer
{
    public class LoginMapper
    {
        private BaseDataAccess Db;

        public LoginMapper()
        {
            this.Db = new BaseDataAccess();
        }

        public Entities.User LogIn(User logInUser)
        {
            var parameters = new List<DbParameter>();
            parameters.Add(Db.GetParameter("userName", logInUser.Name));
            parameters.Add(Db.GetParameter("password", logInUser.Password));
            var reader = Db.GetDataReader("logIn", parameters);
            if (reader.Read())
            {
                var user = new User();
                user.Id = (int) reader["c_id"];
                return user;
            }
            else
            {
                return null;
            }
        }

        public int GetIdByLogin(string login)
        {
            var parameters = new List<DbParameter>();
            parameters.Add(Db.GetParameter("login", login));
            int id = (int)Db.ExecuteScalar("GetIdByLogin", parameters);
            return id;
        }

        public string GetRoleById(int id)
        {
            var parameters = new List<DbParameter>();
            parameters.Add(Db.GetParameter("id", id));
            var role = (string)Db.ExecuteScalar("GetRoleById", parameters);
            return role;
        }
    }
}