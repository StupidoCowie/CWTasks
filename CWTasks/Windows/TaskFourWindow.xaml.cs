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
    /// Interaction logic for TaskFourWindow.xaml
    /// </summary>
    public partial class TaskFourWindow : Window
    {
        private TasksWindow _taskWindow;
        private TaskFour _task;
        private int[] _input, _output;
        private int _count;
        private Random _random;
        public TaskFourWindow()
        {
            InitializeComponent();
            _random = new Random();
        }

        public void GenerateAndSort_Click(object sender, RoutedEventArgs e)
        {
            Input.Clear();
            Output.Clear();
            if (int.TryParse(Count.Text, out _count) && _count > 0)
            {
                _input = new int[_count];
                _output = new int[_count];
                for (int i = 0; i < _count; i++)
                {
                    _input[i] = _random.Next(0, 9);
                    Input.Text += _input[i] + " ";
                }
                _output = _task.SortArray(_input);
                foreach (int i in _output)
                {
                    Output.Text += i + " ";
                }
            }
            else
            {
                MessageBox.Show("Amount of numbers isn't number itself or it is below 0", "Ooops...");
            }
        }

        public void ReturnToTaskWindow_Click(object sender, RoutedEventArgs e)
        {
            _taskWindow = new TasksWindow();
            _taskWindow.Show();
            Close();
        }
    }
}
