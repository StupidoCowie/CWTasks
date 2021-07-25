using System;
using System.ComponentModel;
using System.Text;
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

        //public event PropertyChangedEventHandler PropertyChanged;

        public TaskFourWindow()
        {
            InitializeComponent();
            _random = new Random();
            _task = new TaskFour();
            _test = 0;
            _currentTaskStatus = TaskStatus.WaitingForActivation;
            Cancel.IsEnabled = false;
        }

        private async void GenerateAndSort_Click(object sender, RoutedEventArgs e)
        {
            Input.Text = "Loading...";
            Output.Text = "Loading...";
            if (int.TryParse(Count.Text, out _count) && _count > 0)
            {
                try
                {
                    GenerateAndSort.IsEnabled = false;
                    Cancel.IsEnabled = true;
                    _input = new int[_count];
                    _output = new int[_count];
                    StringBuilder tempSB = new StringBuilder();

                    _cancel = new CancellationTokenSource();
                    _currentTaskStatus = TaskStatus.Running;
                    await Task.Run(() =>
                    {
                        MainJobToDo(Input, _cancel.Token, true);
                        MainJobToDo(Output, _cancel.Token, false);
                    }, _cancel.Token);
                    _currentTaskStatus = TaskStatus.RanToCompletion;

                    GenerateAndSort.IsEnabled = true;
                    Cancel.IsEnabled = false;
                }
                catch
                {
                    Input.Text = "Error...";
                    Output.Text = "Error...";
                    GenerateAndSort.IsEnabled = true;
                    Cancel.IsEnabled = false;
                    MessageBox.Show("The number is too big", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Amount of numbers isn't a number itself or it is below 0", "Ooops...");
            }
        }

        private int[] MainJobToDo(TextBox textBox, CancellationToken token, bool isInput)
        {
            int[] result = new int[_count];
            if (!isInput)
            {
                result = _task.SortArray(_input);
            }
            StringBuilder tempSB = new StringBuilder();
            if (isInput)
            {
                for (int i = 0; i < _count; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    result[i] = _random.Next(0, 9);
                    tempSB.Append(result[i]);
                }
            }
            else
            {
                for (int i = 0; i < _count; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    tempSB.Append(result[i]);
                }
            }
            if (!token.IsCancellationRequested)
            {
                //Need to read about bindings. Maybe try to save result in the file if user wants it. There are several options here.
                textBox.Dispatcher.Invoke(() =>
                {
                    if (tempSB.Length > 100000)
                    {
                        textBox.Text = tempSB.ToString(0, 100000);
                    }
                    else
                    {
                        textBox.Text = tempSB.ToString();
                    }
                });
            }
            if (isInput)
            {
                return _input = result;
            }
            else
            {
                return _output = result;
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
                Cancel.IsEnabled = false;
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
