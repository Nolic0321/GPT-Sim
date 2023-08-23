using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GPTSim.Tasks
{
    public class TaskManager
    {
        private static TaskManager _instance;
        private List<ITask> tasks = new List<ITask>();

        public static TaskManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TaskManager();
                }

                return _instance;
            }
        }

        private TaskManager()
        { }

        public void AddTask(ITask task)
        {
            if(tasks.Contains(task)) return;
            tasks.Add(task);
            tasks.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }

        public ITask GetNextTask()
        {
            if (tasks.Count == 0) return null;
            
            ITask nextTask = tasks.First();
            tasks.RemoveAt(0);
            return nextTask;
        }

        public void RemoveTask(ITask task)
        {
            tasks.Remove(task);
        }
    }
}