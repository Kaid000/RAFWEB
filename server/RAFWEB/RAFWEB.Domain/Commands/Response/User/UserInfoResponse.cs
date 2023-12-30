using System.ComponentModel.DataAnnotations;

namespace RAFWEB.Domain.Commands.Response.User
{
    public class UserInfoResponse
    {
        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Required] 
        public string UserName { get; set; }

        public IList<string>? Roles { get; set; }
    }
}
