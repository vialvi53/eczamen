using System.Collections.Generic;


namespace Library
{
    public class Application
    {
        public Application application;
        public List<TaskList> taskLists;

        public Application()
        {
            taskLists = new List<TaskList>();
        }

        
        public Application GetApplication()
        {
            if (application == null)
                return new Application();

            return application;
        }

        /// <summary>
        /// Метод создания списка задач
        /// </summary>
        /// <param name="name">Имя списка задач</param>
        public void CreateTaskList(string name)
        {
            taskLists.Add(new TaskList(name));
        }

       
        public List<string> GetTaskListNames()
        {
            if (taskLists == null)
                return null;

            List<string> taskListNames = new List<string>();

            foreach (TaskList task in taskLists)
            {
                taskListNames.Add(task.Name);
            }

            return taskListNames;
        }

        
        public TaskList GetTaskListByName(string name)
        {
            TaskList taskList = taskLists.Find(t => t.Name == name);
            return taskList;
        }

        
        public List<Task> GetTasksByToday()
        {
            List<Task> tasksByToday = new List<Task>();

            foreach (TaskList taskList in taskLists)
            {
                tasksByToday.AddRange(taskList.GetTasksByToday());
            }

            return tasksByToday;
        }

        public List<Task> GetTasksByFuture()
        {
            List<Task> tasksByFuture = new List<Task>();

            foreach (TaskList taskList in taskLists)
            {
                tasksByFuture.AddRange(taskList.GetTasksByFuture());
            }

            return tasksByFuture;
        }
    }
}
