namespace StudentEnrollment.Data
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public String CreatedBy { get; set; } = "Agus Kianto";
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public String ModifiedBy { get; set; } = "Agus Kianto";
    }
}
