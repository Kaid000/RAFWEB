namespace RAFWEB.Data.Models
{
    public class Holiday : BaseEntity
    {
        public DateTime PerformedDate { get; set; }
        public StudentOrganization Organization { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
