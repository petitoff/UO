using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

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

            DataContext = new ViewModel.MainViewModel(this);

        }

        private void AddCar()
        {
            rect1 = new System.Windows.Shapes.Rectangle();
            rect1.Stroke = new SolidColorBrush(Colors.BlueViolet);
            rect1.Fill = new SolidColorBrush(Colors.BlueViolet);
            rect1.Width = 20;
            rect1.Height = 20;
            rect1.Name = "rect1";
            Canvas.SetLeft(rect1, 0);
            Canvas.SetTop(rect1, 240);
            FrontCanvas.Children.Add(rect1);
        }

        private void MoveCarThread()
        {
            for (int i = 0; i < 700; i++)
            {
                Thread.Sleep(5);
                this.Dispatcher.Invoke(() =>
                {
                    Canvas.SetLeft(rect1, Canvas.GetLeft(rect1) + 1);
                });
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
