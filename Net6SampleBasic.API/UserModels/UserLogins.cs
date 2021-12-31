using System.ComponentModel.DataAnnotations;

namespace Net6SampleBasic.API.UserModels
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public UserLogins() { }
    }
}
