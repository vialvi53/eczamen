using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ezx
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "Список задач";

            InitializeApplication();
        }

        public Library.Application Application = new Library.Application();
        public List<string> taskListNames;

        public void InitializeApplication()
        {
            InitializeTaskLists();
            InitializeTaskListNames();
            InitializeTaskListName();

            Application.application = Application.GetApplication();
        }

        public void InitializeTaskLists()
        {
            TaskLists.Items.Clear();

            if (Application.taskLists == null || Application.taskLists.Count == 0)
                Application.taskLists = new List<TaskList>()
                {
                    new TaskList("Входящие"), new TaskList("Сегодня"), new TaskList("Предстоящие")
                };

            foreach (TaskList taskList in Application.taskLists)
            {
                TaskLists.Items.Add(taskList.Name);
            }

            if (Application.taskLists.Count == 3)
                TaskLists.SelectedItem = "Входящие";

            else
                TaskLists.SelectedItem = Application.taskLists.FindLast(tl => tl.Name != null).Name;
        }

        public void InitializeTaskListNames()
        {
            taskListNames = Application.GetTaskListNames();
        }

        private void InitializeTaskListName()
        {
            var name = TaskLists.SelectedItem;
            TaskListNameLabel.Content = name;
        }

        private void TaskLists_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            InitializeTaskListName();
        }
    }
}
