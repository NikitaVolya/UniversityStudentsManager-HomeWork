

namespace UniversityStudentsMenager.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
