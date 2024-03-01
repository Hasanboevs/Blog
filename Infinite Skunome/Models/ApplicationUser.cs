using Microsoft.AspNetCore.Identity;

namespace Infinite_Skunome.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        //Relation
        public List<Post> Posts { get; set; }

    }
}
