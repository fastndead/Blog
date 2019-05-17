create PROCEDURE GetUsers
AS
  SELECT ta.c_id, ta.c_name
  FROM t_author ta
go

