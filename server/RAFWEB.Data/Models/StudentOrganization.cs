namespace RAFWEB.Data.Models
{
    public class StudentOrganization : BaseEntity
    {
        public string Name { get; set; }
        public string Leader { get; set; }
        public string? About { get; set; }
        public ContactInfo Contact { get; set; }
    }
}
