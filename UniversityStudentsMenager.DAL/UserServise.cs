using UniversityStudentsMenager.DAL.Entities;

namespace UniversityStudentsMenager.DAL
{
    public class UserServise
    {
        private readonly Repositories.UserRepository _repository;

        public UserServise()
        {
            _repository = new Repositories.UserRepository();
        }

        public User? GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public Order? GetOrderById(int id)
        {
            return _repository.GetOrderById(id);
        }

        public void AddUser(User user)
        {
            _repository.AddUser(user);
        }

        public void AddOrder(User user, Order order)
        {
            _repository.AddUserOrder(user, order);
        }

        public void RemoveUser(User user)
        {
            _repository.RemoveUser(user);
        }

        public void RemoveOrder(Order order)
        {
            _repository.RemoveOrder(order);
        }

        public void UpdateUser(User user)
        {
            _repository.UpdateUser(user);
        }

        public void UpdateOrder(Order order)
        {
            _repository.UpdateOrder(order);
        }

        public void AddOrederById(int userId, Order order)
        {
            User? user = _repository.GetUserById(userId);
            if (user == null)
                return;
            _repository.AddUserOrder(user, order);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAll();
        }
    }
}
