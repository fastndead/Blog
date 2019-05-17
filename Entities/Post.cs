using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
namespace Entities
{
    public class Post
    {
        public int Id { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Required]
        public string Text { get; set; }
        public User Author { get; set; }
        public int? Rating { get; set; }
        [Required]
        public string Title { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        [DataType(DataType.Date)] public DateTime CreateDate { get; set; }
    }
}