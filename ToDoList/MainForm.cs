using Services.ToDoList;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToDoList.Models;
using UI.ToDoList;

namespace ToDoListApp
{
    public partial class MainForm : Form
    {
        private List<TaskItem> tasks = new List<TaskItem>();

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
            new TaskDragDropHandler(lstTasks, tasks, UpdateTaskList, UpdateButtonState);
        }

        private void UpdateAddButtonState()
        {
            btnAddTask.Enabled = !string.IsNullOrWhiteSpace(txtTask.Text);
        }

        private void UpdateTaskList()
        {
            lstTasks.DataSource = null;
            lstTasks.DataSource = tasks;
            lstTasks.Refresh();
        }

        private void UpdateButtonState()
        {
            var hasSelection = lstTasks.SelectedItem != null;
            btnUpdateStatus.Enabled = hasSelection;
            btnRemoveTask.Enabled = hasSelection;
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

        private void lstTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            TaskListRenderer.DrawTaskItem(e, lstTasks);
        }

        private void lstTasks_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            tasks.Sort((a, b) =>
            {
                int statusComparison = a.StatusIndex.CompareTo(b.StatusIndex);
                return statusComparison != 0 ? statusComparison : string.Compare(a.Description, b.Description, StringComparison.Ordinal);
            });

            UpdateTaskList();
        }
    }
}
