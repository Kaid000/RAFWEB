namespace RAFWEB.Data.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserRole Role { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
    }
}
