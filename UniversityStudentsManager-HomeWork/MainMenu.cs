
using UniversityStudentsMenager.DAL;

namespace UniversityStudentsMenager.ConsoleApp
{
    internal class MainMenu
    {
        private UserServise _servise;
        private List<string> _captions;
        private List<Action<UserServise>> _handlers;
        private bool _cycle;

        public MainMenu()
        {
            _servise = new UserServise();

            _captions = new List<string>();
            _handlers = new List<Action<UserServise>>();
        }

        private void ClearMenuOptions()
        {
            _captions.Clear();
            _handlers.Clear();
        }

        private void AddMenuOption(string text, Action<UserServise> handler)
        {
            _captions.Add(text);
            _handlers.Add(handler);
        }

        private void MenuInit()
        {
            ClearMenuOptions();

            AddMenuOption("Add new user", x => UserAplicationHandlers.AddNewUser(_servise));
            AddMenuOption("Add new order", x => UserAplicationHandlers.AddNewOrder(_servise));
            AddMenuOption("Remove user", x => UserAplicationHandlers.RemoveUser(_servise));
            AddMenuOption("Remove order", x => UserAplicationHandlers.RemoveOrder(_servise));
            AddMenuOption("Update user", x => UserAplicationHandlers.UpdateUser(_servise));
            AddMenuOption("Update order", x => UserAplicationHandlers.UpdateOrder(_servise));
            AddMenuOption("Show all users", x => UserAplicationHandlers.ShowAllUsers(_servise));
            AddMenuOption("Show all orders", x => UserAplicationHandlers.ShowAllOrders(_servise));
            AddMenuOption("Exit", x => Stop());
        }

        private void DrawMenu()
        {
            for (int i = 0; i < _handlers.Count; i++)
                Console.WriteLine($"{i + 1} | {_captions[i]}");
        }

        private void ExecuteEvent(int index)
        {
            if (index < 0 || index >= _handlers.Count)
                return;

            _handlers[index](_servise);
        }

        private void MainLoop()
        {
            while (_cycle)
            {
                Console.Clear();
                DrawMenu();
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                ExecuteEvent(index);
            }
        }

        public void Stop() => _cycle = false;
        public void Run()
        {
            MenuInit();
            _cycle = true;
            MainLoop();
        }
    }
}
