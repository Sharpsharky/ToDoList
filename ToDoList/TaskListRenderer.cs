using System.Drawing;
using System.Windows.Forms;
using ToDoList.Models;

namespace ToDoList
{
    public static class TaskListRenderer
    {
        private static Color selectedBackground = Color.LightGray;

        public static void DrawTaskItem(DrawItemEventArgs e, ListBox listBox)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            var task = (TaskItem)listBox.Items[e.Index];

            var statusColor = TaskStatusLoader.GetColorForStatus(task.StatusIndex);
            var textColor = Color.Black;

            var taskName = task.Description;
            var statusText = $" ({TaskStatusLoader.Statuses[task.StatusIndex].Name})";

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            if (isSelected)
            {
                using (var backgroundBrush = new SolidBrush(selectedBackground))
                {
                    e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                }
            }
            else
                e.DrawBackground();

            using (Brush textBrush = new SolidBrush(textColor))
            using (Brush statusBrush = new SolidBrush(statusColor))
            using (Font boldFont = new Font(e.Font, FontStyle.Bold))
            {
                var taskSize = e.Graphics.MeasureString(taskName, e.Font);

                e.Graphics.DrawString(taskName, e.Font, textBrush, e.Bounds.Location);

                var statusPosition = new PointF(e.Bounds.Left + taskSize.Width, e.Bounds.Top);
                e.Graphics.DrawString(statusText, boldFont, statusBrush, statusPosition);
            }
        }
    }
}
