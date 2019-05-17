alter procedure GetRoleById @id int
  as 
  select c_role from t_author where c_id = @id;
go

