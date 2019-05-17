using System.ComponentModel.DataAnnotations;
using System;
namespace Entities
{
    public class Comment
    {
        public string Text { get; set; }
        public User Author{ get; set; }
        [DataType(DataType.Date)] 
        public DateTime CreateDate { get; set; }

    }
}