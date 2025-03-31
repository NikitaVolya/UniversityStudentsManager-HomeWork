

using UniversityStudentsMenager.DAL;
using UniversityStudentsMenager.DAL.Entities;

namespace UniversityStudentsMenager.ConsoleApp
{
    public class UserAplicationHandlers
    {
        public static void PauseConsole()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static string UserToString(User user)
        {
            return $"Id: {user.Id}, Name: {user.Name}";
        }
        public static string OrderToString(Order order)
        {
            return $"Id: {order.Id}, Name: {order.Name}, Date: {order.Date}";
        }

        public static User? InputUser()
        {
            try
            {
                Console.WriteLine("Enter name: ");
                string? name = Console.ReadLine();

                if (name == null)
                    return null;

                return new User { Name = name };
            }
            catch
            {
                return null;
            }
        }

        public static Order? InputOrder()
        {
            try
            {
                Console.WriteLine("Enter name: ");
                string? name = Console.ReadLine();

                if (name == null)
                    return null;


                return new Order { Name = name, Date = DateTime.Now };
            }
            catch
            {
                return null;
            }
        }

        public static User? ChoiceUser(UserServise servise)
        {
            string? userId = Console.ReadLine();
            if (userId == null)
            {
                Console.WriteLine("Invalide input");
                PauseConsole();
                return null;
            }
            User? user = servise.GetUserById(Convert.ToInt32(userId));
            if (user == null)
            {
                Console.WriteLine("User not found");
                PauseConsole();
                return null;
            }
            return user;
        }

        public static Order? ChoiceOrder(UserServise servise)
        {
            Console.WriteLine("Enter order id: ");
            string? orderId = Console.ReadLine();
            if (orderId == null)
            {
                Console.WriteLine("Order not found");
                PauseConsole();
                return null;
            }
            Order? order = servise.GetOrderById(Convert.ToInt32(orderId));
            if (order == null)
            {
                Console.WriteLine("Order not found");
                PauseConsole();
                return null;
            }
            return order;
        }

        public static bool ConsoleDialogeYesNo(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Yes - y, No - n");
            string? answer = Console.ReadLine();
            return answer != null && (answer.ToLower() == "yes" || answer.ToLower() == "y");
        }


        public static void AddNewUser(UserServise servise)
        {
            Console.Clear();
            User? user = InputUser();
            if (user is null)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            servise.AddUser(user);
            Console.WriteLine("User added");
            PauseConsole();
        }

        public static void AddNewOrder(UserServise servise)
        {
            Console.Clear();
            Console.WriteLine("Enter user id: ");

            User? user = ChoiceUser(servise);
            if (user == null)
                return;
            Order? new_order = InputOrder();
            if (new_order is null)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            servise.AddOrder(user, new_order);
            Console.WriteLine("Order added");
            PauseConsole();
        }


        public static void ShowAllUsers(UserServise servise)
        {
            Console.Clear();
            var users = servise.GetAllUsers();
            foreach (var user in users)
                Console.WriteLine(UserToString(user));
            PauseConsole();
        }

        public static void ShowAllOrders(UserServise servise)
        {
            Console.Clear();
            var users = servise.GetAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine(UserToString(user));
                foreach (var order in user.Orders)
                    Console.WriteLine("\t" + OrderToString(order));
            }
            PauseConsole();
        }


        public static void RemoveUser(UserServise servise)
        {
            Console.Clear();
            Console.WriteLine("Enter user id: ");
            User? user = ChoiceUser(servise);
            if (user == null)
                return;
            if (!ConsoleDialogeYesNo($"Do you want to delete {UserToString(user)}?"))
                return;
            servise.RemoveUser(user);
            Console.WriteLine("User removed");
            PauseConsole();
        }

        public static void RemoveOrder(UserServise servise)
        {
            Console.Clear();
            Console.WriteLine("Enter order id: ");
            string? orderId = Console.ReadLine();
            if (orderId == null)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Order? order = servise.GetOrderById(Convert.ToInt32(orderId));
            if (order == null)
            {
                Console.WriteLine("Order not found");
                return;
            }
            if (!ConsoleDialogeYesNo($"Do you want to delete {OrderToString(order)}?"))
                return;
            servise.RemoveOrder(order);
            Console.WriteLine("Order removed");
            PauseConsole();
        }

        public static void UpdateUser(UserServise servise)
        {
            Console.Clear();
            Console.WriteLine("Enter user id: ");
            User? user = ChoiceUser(servise);
            if (user == null)
                return;
            Console.WriteLine($"User: {UserToString(user)}");
            Console.WriteLine("Enter new name: ");
            string? name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            user.Name = name;
            servise.UpdateUser(user);
            Console.WriteLine("User updated");
            PauseConsole();
        }

        public static void UpdateOrder(UserServise servise)
        {
            Console.Clear();
            Order? order = ChoiceOrder(servise);
            if (order == null)
                return;
            Console.WriteLine($"Order: {OrderToString(order)}");
            Console.WriteLine("Enter new name: ");
            string? name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter new order date: ");
            DateTime date;
            string? date_string = Console.ReadLine();
            if (date_string == null || !DateTime.TryParse(date_string, out date))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            order.Name = name;
            order.Date = date;
            servise.UpdateOrder(order);
            Console.WriteLine("Order updated");
            PauseConsole();
        }
    }
}
