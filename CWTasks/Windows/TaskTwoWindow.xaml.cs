using System;
using System.Windows;
using CWTasks.TasksClasses;

namespace CWTasks.Windows
{
    /// <summary>
    /// Interaction logic for TaskTwoWindow.xaml
    /// </summary>
    public partial class TaskTwoWindow : Window
    {
        private TaskTwo _task;
        private string _word;
        public TaskTwoWindow()
        {
            InitializeComponent();
            _task = new TaskTwo();
            _word = "Testing...";
            Input.Text = _word;
            Output.Text = _task.DuplicateEncode(_word);
        }

        public void Encode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _word = Input.Text;
                Output.Text = _task.DuplicateEncode(_word);
            }
            catch (Exception exp)
            {
                Input.Text = "Type something here!";
                Output.Text = "Type something on top!";
                MessageBox.Show(exp.Message, "Ooops...");
            }
        }

        public void ReturnToTaskWindow_Click(object sender, RoutedEventArgs e)
        {
            var NewWindow = new TasksWindow();
            NewWindow.Show();
            Close();
        }
    }
}
