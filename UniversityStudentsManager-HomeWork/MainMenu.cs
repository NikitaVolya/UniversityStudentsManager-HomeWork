
using UniversityStudentsManager;
using UniversityStudentsMenager.DAL.Repositories;

namespace UniversityStudentsMenager.ConsoleApp
{
    internal class MainMenu
    {
        private StudentRepository _repository;
        private List<string> _captions;
        private List<Action<StudentRepository>> _handlers;
        private bool _cycle;

        public MainMenu()
        {
            _repository = new StudentRepository();

            _captions = new List<string>();
            _handlers = new List<Action<StudentRepository>>();
        }

        private void ClearMenuOptions()
        {
            _captions.Clear();
            _handlers.Clear();
        }

        private void AddMenuOption(string text, Action<StudentRepository> handler)
        {
            _captions.Add(text);
            _handlers.Add(handler);
        }

        private void MenuInit()
        {
            ClearMenuOptions();
            AddMenuOption("Add new student", AplicationHandlers.AddNewStudent);
            AddMenuOption("Show all students", AplicationHandlers.ShowAllStudents);
            AddMenuOption("Modify student", AplicationHandlers.ModifyStudent);
            AddMenuOption("Delete student", AplicationHandlers.DeleteStudent);
            AddMenuOption("Show student info by id", AplicationHandlers.ShowInfo);
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

            _handlers[index](_repository);
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
