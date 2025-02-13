using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ToDoList;
using ToDoList.Models;

namespace ToDoListApp
{
    public partial class MainForm : Form
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private Point mouseDownLocation;

        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
            UpdateButtonState();
            UpdateAddButtonState();
        }

        private void InitializeControls()
        {
            TaskStatusLoader.LoadStatuses();
            cmbStatus.DataSource = TaskStatusLoader.Statuses;
            cmbStatus.DisplayMember = "Name";

            cmbStatus.SelectedIndex = 0;

            btnAddTask.Click += btnAddTask_Click;
            btnRemoveTask.Click += btnRemoveTask_Click;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            btnSort.Click += btnSort_Click;
            lstTasks.SelectedIndexChanged += (sender, e) => UpdateButtonState();
            txtTask.TextChanged += (sender, e) => UpdateAddButtonState();
            lstTasks.DragOver += lstTasks_DragOver;
            lstTasks.DragDrop += lstTasks_DragDrop;
        }

        private void UpdateAddButtonState()
        {
            btnAddTask.Enabled = !string.IsNullOrWhiteSpace(txtTask.Text);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var description = txtTask.Text.Trim();
            var status = cmbStatus.SelectedItem.ToString();
            var newTask = new TaskItem
            {
                Description = description,
                StatusIndex = cmbStatus.SelectedIndex
            };

            tasks.Add(newTask);
            UpdateTaskList();
            txtTask.Clear();
        }


        private void UpdateTaskList()
        {
            lstTasks.DataSource = null;
            lstTasks.DataSource = tasks;
            lstTasks.Refresh();
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            var selectedTask = (TaskItem)lstTasks.SelectedItem;
            tasks.Remove(selectedTask);
            UpdateTaskList();
            UpdateButtonState();
            lstTasks.Focus();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem == null) return;

            var selectedTask = (TaskItem)lstTasks.SelectedItem;
            var selectedListIndex = lstTasks.SelectedIndex;
            var nextIndex = (selectedTask.StatusIndex + 1) % TaskStatusLoader.Statuses.Count;

            selectedTask.StatusIndex = nextIndex;

            UpdateTaskList();

            lstTasks.SelectedIndex = selectedListIndex;
            lstTasks.Focus();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lstTasks.Left = (groupBoxBottom.Width - lstTasks.Width) / 2;
            lstTasks.Top = (groupBoxBottom.Height - lstTasks.Height) / 2;
        }

        private void UpdateButtonState()
        {
            var hasSelection = lstTasks.SelectedItem != null;
            btnUpdateStatus.Enabled = hasSelection;
            btnRemoveTask.Enabled = hasSelection;
        }

        private void lstTasks_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstTasks.IndexFromPoint(e.Location) == ListBox.NoMatches)
                lstTasks.ClearSelected();

            int index = lstTasks.IndexFromPoint(e.Location);
            UpdateButtonState();
            if (index >= 0)
            {
                lstTasks.SelectedIndex = index;

                lstTasks.DoDragDrop(lstTasks.SelectedItem, DragDropEffects.Move);
            }
        }

        private void lstTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            TaskListRenderer.DrawTaskItem(e, lstTasks);
        }

        private void lstTasks_DragDrop(object sender, DragEventArgs e)
        {
            var point = lstTasks.PointToClient(new Point(e.X, e.Y));
            var targetIndex = lstTasks.IndexFromPoint(point);

            var draggedItem = (TaskItem)e.Data.GetData(typeof(TaskItem));
            var sourceIndex = lstTasks.SelectedIndex;

            if (targetIndex < 0)
                targetIndex = tasks.Count - 1;

            if (sourceIndex != targetIndex)
            {
                tasks.RemoveAt(sourceIndex);
                tasks.Insert(targetIndex, draggedItem);

                UpdateTaskList();

                lstTasks.SelectedIndex = targetIndex;
            }
        }

        private void lstTasks_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            tasks = tasks.OrderBy(task => task.StatusIndex).ThenBy(task => task.Description).ToList();
            UpdateTaskList();
        }
    }
}
