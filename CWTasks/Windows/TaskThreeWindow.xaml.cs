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
    /// Interaction logic for TaskThreeWindow.xaml
    /// </summary>
    public partial class TaskThreeWindow : Window
    {
        private TaskThree _task;
        private int _red, _green, _blue;
        private string _color;
        private Border _border;
        private Brush _brush;
        private BrushConverter _bc;
        public TaskThreeWindow()
        {
            InitializeComponent();
            _task = new TaskThree();
            _bc = new BrushConverter();
            _border = new Border();
            _color = _task.ConvertRGB(Int32.Parse(Red.Text), Int32.Parse(Green.Text), Int32.Parse(Blue.Text));
            _brush = (Brush)_bc.ConvertFrom($"#{_color}");
            BorderBrush = _brush;
        }

        public void Convert_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void ReturnToTaskWindow_Click(object sender, RoutedEventArgs e)
        {
            var NewWindow = new TasksWindow();
            NewWindow.Show();
            Close();
        }
    }
}
