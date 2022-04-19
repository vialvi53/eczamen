using System;
using System.Collections.Generic;

namespace ezx
{
    public class TaskList
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }

        public TaskList(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

       
        public List<Task> GetTasks()
        {
            return Tasks;
        }

       
        public void Remove(Task task)
        {
            if (Tasks.Contains(task))
            {
                Tasks.Remove(task);
            }
        }

       
        public List<Task> GetTasksByToday()
        {
            List<Task> tasksByToday = new List<Task>();

            foreach (Task task in Tasks)
            {
                if (task.Due.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    tasksByToday.Add(task);
                }
            }

            return tasksByToday;
        }

        
        public List<Task> GetTasksByFuture()
        {
            List<Task> tasksByFuture = new List<Task>();

            foreach (Task task in Tasks)
            {
                if (task.Due > DateTime.Now)
                {
                    tasksByFuture.Add(task);
                }
            }

            return tasksByFuture;
        }
    }
}
