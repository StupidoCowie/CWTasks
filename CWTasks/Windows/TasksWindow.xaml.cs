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

        public void Task1_Click(object sender, RoutedEventArgs e)
        {
            var NewWindow = new TaskOneWindow();
            NewWindow.Show();
            Close();
        }

        public void Task2_Click(object sender, RoutedEventArgs e)
        {
            var NewWindow = new TaskTwoWindow();
            NewWindow.Show();
            Close();
        }
        public void Task3_Click(object sender, RoutedEventArgs e)
        {
            var NewWindow = new TaskThreeWindow();
            NewWindow.Show();
            Close();
        }
        public void Task4_Click(object sender, RoutedEventArgs e)
        {
            var NewWindow = new TaskFourWindow();
            NewWindow.Show();
            Close();
        }

        public void QMark_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This app has been developed by BNYu\nCopyright © 2021", "About");
        }
    }
}
