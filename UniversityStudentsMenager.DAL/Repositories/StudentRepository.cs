namespace UniversityStudentsMenager.DAL.Repositories
{

    public class StudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(Entities.Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Entities.Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(Entities.Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public void AddRange(List<Stream> streams)
        {
            _context.AddRange(streams);
            _context.SaveChanges();
        }
        

        public Entities.Student? GetById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Entities.Student> GetAll()
        {
            return _context.Students.ToList();
        }
    }

}
