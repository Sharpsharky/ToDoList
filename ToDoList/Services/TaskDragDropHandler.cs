using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ToDoList.Models;

namespace Services.ToDoList
{
    public class TaskDragDropHandler
    {
        private ListBox _listBox;
        private List<TaskItem> _tasks;
        private Action _updateTaskList;
        private Action _updateButtonState;

        public TaskDragDropHandler(ListBox listBox, List<TaskItem> tasks, Action updateTaskList, Action updateButtonState)
        {
            _listBox = listBox;
            _tasks = tasks;
            _updateTaskList = updateTaskList;
            _updateButtonState = updateButtonState;

            _listBox.MouseDown += ListBox_MouseDown;
            _listBox.DragDrop += ListBox_DragDrop;
            _listBox.DragOver += ListBox_DragOver;
        }

        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_listBox.IndexFromPoint(e.Location) == ListBox.NoMatches)
                _listBox.ClearSelected();

            int index = _listBox.IndexFromPoint(e.Location);
            _updateButtonState?.Invoke();

            if (index >= 0)
            {
                _listBox.SelectedIndex = index;
                _listBox.DoDragDrop(_listBox.SelectedItem, DragDropEffects.Move);
            }
        }

        private void ListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ListBox_DragDrop(object sender, DragEventArgs e)
        {
            var point = _listBox.PointToClient(new Point(e.X, e.Y));
            var targetIndex = _listBox.IndexFromPoint(point);

            var draggedItem = (TaskItem)e.Data.GetData(typeof(TaskItem));
            var sourceIndex = _listBox.SelectedIndex;

            if (targetIndex < 0)
                targetIndex = _tasks.Count - 1;

            if (sourceIndex != targetIndex)
            {
                _tasks.RemoveAt(sourceIndex);
                _tasks.Insert(targetIndex, draggedItem);

                _updateTaskList?.Invoke();
                _listBox.SelectedIndex = targetIndex;
            }
        }
    }
}
