using Microsoft.EntityFrameworkCore;
using UniversityStudentsMenager.DAL.Entities;

namespace UniversityStudentsMenager.DAL.Repositories
{

    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository()
        {
            _context = new AppDbContext();
        }

        public void AddUser(User student)
        {
            _context.Users.Add(student);
            _context.SaveChanges();
        }

        public void UpdateUser(User student)
        {
            _context.Users.Update(student);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void RemoveUser(User student)
        {
            _context.Users.Remove(student);
            _context.SaveChanges();
        }

        public void AddUserRange(List<User> users)
        {
            _context.AddRange(users);
            _context.SaveChanges();
        }

        public void AddUserOrder(User user, Order order)
        {
            order.User = user;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }


        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }


        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(u => u.Orders).ToList();
        }
    }

}
