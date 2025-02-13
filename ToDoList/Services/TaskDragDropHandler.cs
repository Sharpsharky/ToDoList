using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ToDoList.Models;

namespace Services.ToDoList
{
    public class TaskDragDropHandler
    {
        private readonly ListBox listBox;
        private readonly List<TaskItem> tasks;
        private readonly Action OnUpdateTaskListRequested;
        private readonly Action OnUpdateButtonStateRequested;

        public TaskDragDropHandler(ListBox listBox, List<TaskItem> tasks, Action OnUpdateTaskListRequested, 
            Action OnUpdateButtonStateRequested)
        {
            this.listBox = listBox;
            this.tasks = tasks;
            this.OnUpdateTaskListRequested = OnUpdateTaskListRequested;
            this.OnUpdateButtonStateRequested = OnUpdateButtonStateRequested;

            this.listBox.MouseDown += ListBox_MouseDown;
            this.listBox.DragDrop += ListBox_DragDrop;
            this.listBox.DragOver += ListBox_DragOver;
        }

        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox.IndexFromPoint(e.Location) == ListBox.NoMatches)
                listBox.ClearSelected();

            int index = listBox.IndexFromPoint(e.Location);
            OnUpdateButtonStateRequested?.Invoke();

            if (index >= 0)
            {
                listBox.SelectedIndex = index;
                listBox.DoDragDrop(listBox.SelectedItem, DragDropEffects.Move);
            }
        }

        private void ListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ListBox_DragDrop(object sender, DragEventArgs e)
        {
            var point = listBox.PointToClient(new Point(e.X, e.Y));
            var targetIndex = listBox.IndexFromPoint(point);

            var draggedItem = (TaskItem)e.Data.GetData(typeof(TaskItem));
            var sourceIndex = listBox.SelectedIndex;

            if (targetIndex < 0)
                targetIndex = tasks.Count - 1;

            if (sourceIndex != targetIndex)
            {
                tasks.RemoveAt(sourceIndex);
                tasks.Insert(targetIndex, draggedItem);

                OnUpdateTaskListRequested?.Invoke();
                listBox.SelectedIndex = targetIndex;
            }
        }
    }
}
