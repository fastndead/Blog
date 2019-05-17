using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{

    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<User> Subscriptions { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}