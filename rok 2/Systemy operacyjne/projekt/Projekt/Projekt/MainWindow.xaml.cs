using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Shapes.Rectangle rect1;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModel.MainViewModel();

            AddCar();

            var t = new System.Threading.Thread(new System.Threading.ThreadStart(MoveCarThread));
            t.Start();
        }

        private void AddCar()
        {
            rect1 = new System.Windows.Shapes.Rectangle();
            rect1.Stroke = new SolidColorBrush(Colors.BlueViolet);
            rect1.Fill = new SolidColorBrush(Colors.BlueViolet);
            rect1.Width = 35;
            rect1.Height = 35;
            rect1.Name = "rect1";
            Canvas.SetLeft(rect1, 0);
            Canvas.SetTop(rect1, 230);
            FrontCanvas.Children.Add(rect1);
        }

        private void MoveCarThread()
        {
            for (int i = 0; i < 500; i++)
            {
                MoveCar();
            }
        }

        private void MoveCar()
        {
            Thread.Sleep(5);
            this.Dispatcher.Invoke(() =>
            {
                    Canvas.SetLeft(rect1, Canvas.GetLeft(rect1) + 1);
            });
        }
    }
}
