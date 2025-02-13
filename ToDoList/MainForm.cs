using Services.ToDoList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ToDoList.Models;
using ToDoList.Services;
using UI.ToDoList;

namespace ToDoListApp
{
    public partial class MainForm : Form
    {
        private readonly List<TaskItem> tasks = new List<TaskItem>();
        private TaskManager taskManager;

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
            taskManager = new TaskManager(tasks, UpdateTaskList, UpdateButtonState);

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
            var selectedTask = (TaskItem)lstTasks.SelectedItem;

            lstTasks.DataSource = null;
            lstTasks.DataSource = tasks;
            lstTasks.DisplayMember = "Description";

            if (selectedTask != null)
            {
                lstTasks.SelectedItem = tasks.FirstOrDefault(t => t.Description == selectedTask.Description && t.StatusIndex == selectedTask.StatusIndex);
            }

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
            taskManager.AddTask(txtTask.Text.Trim(), cmbStatus.SelectedIndex);
            txtTask.Clear();
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            taskManager.RemoveTask((TaskItem)lstTasks.SelectedItem);
            lstTasks.Focus();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            taskManager.UpdateTaskStatus((TaskItem)lstTasks.SelectedItem, lstTasks.SelectedIndex);
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
            taskManager.SortTasks();
        }
    }
}
