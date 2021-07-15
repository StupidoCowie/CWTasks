using System.Windows;
using System.Windows.Media;
using CWTasks.TasksClasses;

namespace CWTasks.Windows
{
    /// <summary>
    /// Interaction logic for TaskThreeWindow.xaml
    /// </summary>
    public partial class TaskThreeWindow : Window
    {
        private TasksWindow _taskWindow;
        private TaskThree _task;
        private int _red, _green, _blue;
        private string _color;
        private Brush _brush;
        private BrushConverter _bc;
        public TaskThreeWindow()
        {
            InitializeComponent();
            _task = new TaskThree();
            _bc = new BrushConverter();
        }

        public void Convert_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Red.Text, out _red) && int.TryParse(Green.Text, out _green) && int.TryParse(Blue.Text, out _blue))
            {
                _color = _task.ConvertRGB(_red, _green, _blue);
                Output.Text = _color;
                _brush = (Brush)_bc.ConvertFrom($"#{_color}");
                BorderBrush = _brush;
            }
            else
            {
                MessageBox.Show("Invalid color value", "Ooops...");
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
