using Microsoft.AspNetCore.Identity;

namespace Infinite_Skunome.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        //Relation
        public List<Post> Posts { get; set; }

    }
}
