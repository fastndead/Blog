create procedure GetIdByLogin @login varchar(300)
  as 
  select c_id from t_author where c_name = @login;
go

