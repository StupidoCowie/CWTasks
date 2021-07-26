using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CWTasks.TasksClasses;

namespace CWTasks.Windows
{
    /// <summary>
    /// Interaction logic for TaskFiveWindow.xaml
    /// </summary>
    public partial class TaskFiveWindow : Window
    {
        private TasksWindow _taskWindow;
        public TaskFiveWindow()
        {
            InitializeComponent();
        }

        private void ReturnToTaskWindow_Click(object sender, RoutedEventArgs e)
        {
            _taskWindow = new TasksWindow();
            _taskWindow.Show();
            Close();
        }
    }
}
