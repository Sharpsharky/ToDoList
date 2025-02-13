using Services.ToDoList;
using System;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class TaskManager
    {
        private readonly List<TaskItem> _tasks;
        private readonly Action OnUpdateTaskListRequested;
        private readonly Action OnUpdateButtonStateRequested;

        public TaskManager(List<TaskItem> tasks, Action OnUpdateTaskListRequested, Action OnUpdateButtonStateRequested)
        {
            _tasks = tasks;
            this.OnUpdateTaskListRequested = OnUpdateTaskListRequested;
            this.OnUpdateButtonStateRequested = OnUpdateButtonStateRequested;
        }

        public void AddTask(string description, int statusIndex)
        {
            var newTask = new TaskItem
            {
                Description = description,
                StatusIndex = statusIndex
            };

            _tasks.Add(newTask);
            OnUpdateTaskListRequested?.Invoke();
        }

        public void RemoveTask(TaskItem selectedTask)
        {
            if (selectedTask == null) return;

            _tasks.Remove(selectedTask);
            OnUpdateTaskListRequested?.Invoke();
            OnUpdateButtonStateRequested?.Invoke();
        }

        public void UpdateTaskStatus(TaskItem selectedTask, int selectedIndex)
        {
            if (selectedTask == null) return;

            var nextIndex = (selectedTask.StatusIndex + 1) % TaskStatusLoader.Statuses.Count;
            selectedTask.StatusIndex = nextIndex;

            OnUpdateTaskListRequested?.Invoke();
        }

        public void SortTasks()
        {
            _tasks.Sort((a, b) =>
            {
                var statusComparison = a.StatusIndex.CompareTo(b.StatusIndex);
                return statusComparison != 0 ? statusComparison : string.Compare(a.Description, b.Description, StringComparison.Ordinal);
            });

            OnUpdateTaskListRequested?.Invoke();
        }
    }
}
