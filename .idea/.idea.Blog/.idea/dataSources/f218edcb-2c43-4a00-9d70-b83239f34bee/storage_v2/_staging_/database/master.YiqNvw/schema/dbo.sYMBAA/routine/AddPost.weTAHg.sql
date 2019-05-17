create procedure AddPost @title varchar(50), @text varchar(1500), @idAuthor int
as
    insert into t_post(c_text, c_title, fk_author) output inserted.c_id values (@text, @title, @idAuthor)
go

