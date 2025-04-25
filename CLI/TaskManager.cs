using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_cli.Models;

namespace task_cli.CLI
{
    public class TaskManager
    {
        private LoadData<TaskItem> loadData;
        private int nextId = 1;
        public TaskManager()
        {
            loadData = new LoadData<TaskItem>();
        }
        public async Task<int> InitializeId()
        {
            var taskList = await loadData.GetJsonData();
            if (taskList.Count > 0)
            {
                nextId = taskList.Max(t => t.id) + 1;
            }
            return nextId;
        }
        public async Task AddTask(string description)
        {
            InitializeId();
            var taskList = await loadData.GetJsonData();
            taskList.Add(new TaskItem(nextId, description));
            await loadData.SaveJsonData(taskList);
            Console.WriteLine($"Task with ID {nextId} added.");
        }
        public async Task UpdateTask(int id, string newDescription)
        {
            var taskList = await loadData.GetJsonData();
            var task = taskList.FirstOrDefault(t => t.id == id);
            if(task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }
            task.description = newDescription;
            task.updatedAt = DateTime.Now;
            await loadData.SaveJsonData(taskList);
            Console.WriteLine($"Task with ID {id} updated.");
        }
        public async Task DeleteTask(int id)
        {
            var taskList = await loadData.GetJsonData();
            var task = taskList.FirstOrDefault(t => t.id == id);
            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }
            taskList.Remove(task);
            await loadData.SaveJsonData(taskList);
            Console.WriteLine($"Task with ID {id} deleted.");
        }
        public async Task MarkDoneTask(int id)
        {
            var taskList = await loadData.GetJsonData();
            var task = taskList.FirstOrDefault(t => t.id == id);
            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }
            task.status = "done";
            task.updatedAt = DateTime.Now;
            await loadData.SaveJsonData(taskList);
            Console.WriteLine($"Task with ID {id} marked as done.");
        }
        public async Task MarkInProgressTask(int id)
        {
            var taskList = await loadData.GetJsonData();
            var task = taskList.FirstOrDefault(t => t.id == id);
            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }
            task.status = "in-progress";
            task.updatedAt = DateTime.Now;
            await loadData.SaveJsonData(taskList);
            Console.WriteLine($"Task with ID {id} marked as in-progress.");
        }
        public async Task MarkTodoTask(int id)
        {
            var taskList = await loadData.GetJsonData();
            var task = taskList.FirstOrDefault(t => t.id == id);
            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }
            task.status = "todo";
            task.updatedAt = DateTime.Now;
            await loadData.SaveJsonData(taskList);
            Console.WriteLine($"Task with ID {id} marked as todo.");
        }
        public async Task ListAllTask(string status = null)
        {
            var alltask = await loadData.GetJsonData();
            var filteredtareas = string.IsNullOrEmpty(status)
                ? alltask
                : alltask.Where(t => t.status.Equals(status.ToLower(), StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var task in filteredtareas)
            {
                Console.WriteLine($"{task.TaskToString()}");
            }
        }
    }
}
