using System;
using System.Windows;
using System.Windows.Documents;
using CWTasks.TasksClasses;

namespace CWTasks.Windows
{
    /// <summary>
    /// Interaction logic for TaskOneWindow.xaml
    /// </summary>
    public partial class TaskOneWindow : Window
    {
        private TaskOne _task;
        private string _text;
        public TaskOneWindow()
        {
            InitializeComponent();
            _task = new TaskOne();
            _text = "This is a test string. And it works as you can see!";
            Input.AppendText(_text);
            Output.AppendText(_task.Maskify(_text));
        }

        public void Change_Click(object sender, RoutedEventArgs e)
        {
            Output.Document.Blocks.Clear();
            _text = new TextRange(Input.Document.ContentStart, Input.Document.ContentEnd).Text.Replace("\n", "").Replace("\r", "");
            try
            {
                _text = _task.Maskify(_text);
                Output.AppendText(_text);
            }
            catch (Exception exp)
            {
                Input.Document.Blocks.Clear();
                Input.AppendText("Type something here!");
                Output.AppendText("Type something on the left!");
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
