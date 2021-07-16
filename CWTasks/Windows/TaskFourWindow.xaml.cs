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
        public TaskFourWindow()
        {
            InitializeComponent();
            _random = new Random();
            _task = new TaskFour();
            _test = 0;
            _cancel = new CancellationTokenSource();
        }

        private async void GenerateAndSort_Click(object sender, RoutedEventArgs e)
        {
            Input.Text = "Loading...";
            Output.Text = "Loading...";
            if (int.TryParse(Count.Text, out _count) && _count > 0)
            {
                GenerateAndSort.IsEnabled = false;
                await Task.Run(() =>
                {
                    _input = new int[_count];
                    _output = new int[_count];
                    string TempString = "";
                    for (int i = 0; i < _count; i++)
                    {
                        //try
                        //{
                        //    _cancel.Token.ThrowIfCancellationRequested();
                        //}
                        //catch (Exception exp)
                        //{
                        //    MessageBox.Show(exp.Message, "Warning");
                        //}
                        _input[i] = _random.Next(0, 9);
                        TempString += $"{_input[i]} ";
                    }
                    Input.Dispatcher.Invoke(() =>
                    {
                        Input.Text = TempString;
                        Output.Text = "Calculating...";
                    });
                    TempString = "";
                    _output = _task.SortArray(_input);
                    foreach (int i in _output)
                    {
                        //try
                        //{
                        //    _cancel.Token.ThrowIfCancellationRequested();
                        //}
                        //catch (Exception exp)
                        //{
                        //    MessageBox.Show(exp.Message, "Warning");
                        //}
                        TempString += $"{i} ";
                    }
                    Output.Dispatcher.Invoke(() =>
                    {
                        Output.Text = TempString;
                    });
                }, _cancel.Token);
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

        private void ReturnToTaskWindow_Click(object sender, RoutedEventArgs e)
        {
            _taskWindow = new TasksWindow();
            _taskWindow.Show();
            _cancel.Cancel();
            Close();
        }
    }
}
