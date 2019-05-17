ALTER procedure GetAllPosts 
  as 
  select  posts.fk_author as author_id, posts.c_text as post  from t_post as posts;
go

execute GetAllPosts