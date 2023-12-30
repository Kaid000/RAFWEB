using System.ComponentModel.DataAnnotations;

namespace RAFWEB.Domain.Commands.Request.User
{
    public class SignInUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
