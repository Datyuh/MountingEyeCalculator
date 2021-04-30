using System.Windows;
using System.Windows.Input;
using MahApps.Metro.IconPacks;

namespace MountingEyeCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                DragMove();
            
            else
            {
                Point point = PointToScreen(Mouse.GetPosition(this));
                WindodMain.Left = point.X;
                WindodMain.Top = point.Y - WindodMain.Height;
                WindowState = WindowState.Normal;
                WindowMaximize.Kind = PackIconMaterialKind.WindowMaximize;
                DragMove();

            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                WindowMaximize.Kind = PackIconMaterialKind.WindowRestore;
            }

            else
            {
                WindowState = WindowState.Normal;
                WindowMaximize.Kind = PackIconMaterialKind.WindowMaximize;
            }
        }
    }
}
