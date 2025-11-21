using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TodoListApp.Models;

namespace TodoListApp.Services
{
    internal class TaskService
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private readonly string filePath = "Data/task.txt";

        public TaskService() 
        {
            LoadFromFile();
        }

        public List<TaskItem> GetTasks() => tasks;
        
        public void AddTask(string title)
        {
            tasks.Add(new TaskItem { Id = tasks.Count, Title = title, IsDone = false });
            SaveToFile();
        }

        public void DeleteTask(int id)
        {
            tasks.RemoveAll(x => x.Id == id);
            SaveToFile();
        }
        public void SaveToFile()
        {
            Directory.CreateDirectory("Data");
            File.WriteAllLines(filePath, tasks.Select(t => $"{t.Id} |{t.Title}|{t.IsDone}"));
        }

        private void LoadFromFile()
        {
            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                tasks.Add(new TaskItem 
                {
                    Id = int.Parse(parts[0].Trim()),
                    Title = parts[1].Trim(),
                    IsDone = bool.Parse(parts[2].Trim())
                });
            }
        }
    }
}
