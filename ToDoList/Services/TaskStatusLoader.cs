using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ToDoList.Models;

namespace Services.ToDoList
{
    public static class TaskStatusLoader
    {
        private static readonly string filePath = "Config/statuses.json";
        public static List<TaskStatus> Statuses { get; private set; } = new List<TaskStatus>();

        public static void LoadStatuses()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No file with statuses! Creating...");
                SaveStatuses(new List<TaskStatus>
                {
                    new TaskStatus { Name = "To do", Color = "#0000FF" },
                    new TaskStatus { Name = "In progress", Color = "#FFA500" },
                    new TaskStatus { Name = "Done", Color = "#008000" }
                });
            }

            var json = File.ReadAllText(filePath);
            Statuses = JsonConvert.DeserializeObject<Dictionary<string, List<TaskStatus>>>(json)["statuses"];
        }

        public static void SaveStatuses(List<TaskStatus> statuses)
        {
            var data = new Dictionary<string, List<TaskStatus>> { { "statuses", statuses } };
            File.WriteAllText(filePath, JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        public static Color GetColorForStatus(int statusIndex)
        {
            if (statusIndex < 0 && statusIndex >= Statuses.Count)
                return Color.Black;
                
            return ColorTranslator.FromHtml(Statuses[statusIndex].Color);
        }
    }
}
