using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        private int _count, _test;
        private Random _random;
        private CancellationTokenSource _cancel;
        private TaskStatus _currentTaskStatus;
        public TaskFourWindow()
        {
            InitializeComponent();
            _random = new Random();
            _task = new TaskFour();
            _test = 0;
            _currentTaskStatus = TaskStatus.WaitingForActivation;
        }

        private async void GenerateAndSort_Click(object sender, RoutedEventArgs e)
        {
            Input.Text = "Loading...";
            Output.Text = "Loading...";
            if (int.TryParse(Count.Text, out _count) && _count > 0)
            {
                _cancel = new CancellationTokenSource();
                GenerateAndSort.IsEnabled = false;
                Task currentTask = Task.Run(() =>
                {
                    _currentTaskStatus = TaskStatus.Running;
                    _input = new int[_count];
                    _output = new int[_count];
                    string TempString = "";
                    for (int i = 0; i < _count; i++)
                    {
                        if (_cancel.IsCancellationRequested)
                        {
                            break;
                        }
                        _input[i] = _random.Next(0, 9);
                        TempString += $"{_input[i]} ";
                    }
                    if (!_cancel.IsCancellationRequested)
                    {
                        Input.Dispatcher.Invoke(() =>
                        {
                            Input.Text = TempString;
                            Output.Text = "Calculating...";
                        });
                    }
                    TempString = "";
                    _output = _task.SortArray(_input);
                    foreach (int i in _output)
                    {
                        if (_cancel.IsCancellationRequested)
                        {
                            break;
                        }
                        TempString += $"{i} ";
                    }
                    if (!_cancel.IsCancellationRequested)
                    {
                        Output.Dispatcher.Invoke(() =>
                        {
                            Output.Text = TempString;
                        });
                    }
                }, _cancel.Token);
                await currentTask;
                _currentTaskStatus = currentTask.Status;
                GenerateAndSort.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Amount of numbers isn't number itself or it is below 0", "Ooops...");
            }
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            _test += 1;
            TestCount.Text = _test.ToString();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTaskStatus.Equals(TaskStatus.Running))
            {
                _cancel.Cancel();
                Input.Text = "Cancelled";
                Output.Text = "Cancelled";
                MessageBox.Show("Current task has been cancelled", "Info");
                GenerateAndSort.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("There is nothing to cancel", "Info");
            }
        }

        private void ReturnToTaskWindow_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTaskStatus.Equals(TaskStatus.Running))
            {
                Cancel_Click(sender, e);
            }
            _taskWindow = new TasksWindow();
            _taskWindow.Show();
            Close();
        }
    }
}
