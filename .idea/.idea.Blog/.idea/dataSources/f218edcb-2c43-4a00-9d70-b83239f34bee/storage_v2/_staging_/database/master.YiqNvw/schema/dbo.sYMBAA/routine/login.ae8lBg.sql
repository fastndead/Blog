ALTER procedure logIn @userName varchar(300), @password varchar(300)
  as 
  select c_id as c_id, c_username as c_name from t_author 
  where c_password = @password and
        c_name = @userName;
go

