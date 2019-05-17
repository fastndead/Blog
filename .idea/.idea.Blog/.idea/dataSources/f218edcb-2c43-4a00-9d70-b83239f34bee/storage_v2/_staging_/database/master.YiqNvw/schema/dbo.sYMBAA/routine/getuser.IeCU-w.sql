alter PROCEDURE GetUser
  @id int
AS
  SELECT c_id, c_name
  FROM t_author
  where c_id = @id;
go

