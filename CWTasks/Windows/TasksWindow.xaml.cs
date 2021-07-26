using System.Windows;

namespace CWTasks.Windows
{
    /// <summary>
    /// Interaction logic for TasksWindow.xaml
    /// </summary>
    public partial class TasksWindow : Window
    {
        public TasksWindow()
        {
            InitializeComponent();
        }

        private void Task1_Click(object sender, RoutedEventArgs e)
        {
            TaskOneWindow NewWindow = new TaskOneWindow();
            NewWindow.Show();
            Close();
        }

        private void Task2_Click(object sender, RoutedEventArgs e)
        {
            TaskTwoWindow NewWindow = new TaskTwoWindow();
            NewWindow.Show();
            Close();
        }

        private void Task3_Click(object sender, RoutedEventArgs e)
        {
            TaskThreeWindow NewWindow = new TaskThreeWindow();
            NewWindow.Show();
            Close();
        }

        private void Task4_Click(object sender, RoutedEventArgs e)
        {
            TaskFourWindow NewWindow = new TaskFourWindow();
            NewWindow.Show();
            Close();
        }

        private void Task5_Click(object sender, RoutedEventArgs e)
        {
            TaskFiveWindow NewWindow = new TaskFiveWindow();
            NewWindow.Show();
            Close();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void QMark_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This app has been developed by B.N.Yu.\nCopyright © 2021", "About");
        }
    }
}
