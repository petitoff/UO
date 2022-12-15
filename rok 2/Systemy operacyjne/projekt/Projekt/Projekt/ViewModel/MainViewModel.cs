using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System;
using System.Windows.Input;
using Projekt.Command;
using System.Windows.Media.Media3D;
using System.Threading;

namespace Projekt.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _BGImage = @"C:\Users\petit\Desktop\repos\UO\rok 2\Systemy operacyjne\projekt\Projekt\Projekt\Assets\Image\mapa_v3.png";
        private readonly MainWindow _mainWindow;

        //Canvas canvas = new Canvas();
        Rectangle _carRect;
        TranslateTransform carPos = new TranslateTransform();
        RotateTransform carRot = new RotateTransform();


        public MainViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            _carRect = new Rectangle();

            StartAnimation = new StartAnimationCommand(this);
        }

        public StartAnimationCommand StartAnimation { get; set; }

        public void CreateCar()
        {

            // Create a Rectangle to represent the car
            _carRect.Width = 50;
            _carRect.Height = 25;
            _carRect.Fill = Brushes.Red;
            Canvas.SetLeft(_carRect, 0);
            Canvas.SetTop(_carRect, 215);
            _mainWindow.FrontCanvas.Children.Add(_carRect);



            // Create a TranslateTransform and a RotateTransform to adjust the car's position and orientation


            // Set the car's position and orientation using the TranslateTransform and RotateTransform
            // Set the car's initial position and orientation
            carRot.Angle = 0;

            // Apply the transforms to the car Rectangle
            _carRect.RenderTransformOrigin = new Point(0.5, 0.5);
            _carRect.RenderTransform = carRot;

            // Change the direction of the moving car
            //carPos.X += 10; // move the car to the right
            //carRot.Angle += 10; // rotate the car 90 degrees to the right

            Thread t1 = new Thread(MoveCar);
            t1.Start();
        }

        private void MoveCar()
        {
            for (int i = 0; i < 838; i++)
            {
                Thread.Sleep(5);
                _mainWindow.Dispatcher.Invoke(() =>
                {
                    Canvas.SetLeft(_carRect, Canvas.GetLeft(_carRect) + 1);
                });
            }

            TurningCarRight();
            MoveCarLeft();
            TurningCarLeft();
        }

        private void TurningCarRight()
        {
            for (int i = 0; i < 300; i++)
            {
                Thread.Sleep(5);
                _mainWindow.Dispatcher.Invoke(() =>
                {
                    if (Canvas.GetTop(_carRect) < 363)
                    {
                        Canvas.SetTop(_carRect, Canvas.GetTop(_carRect) + 0.8);

                    }
                    
                    if (carRot.Angle > 90)
                    {
                        Canvas.SetLeft(_carRect, Canvas.GetLeft(_carRect) - 0.8);

                    }
                    else
                    {
                        Canvas.SetLeft(_carRect, Canvas.GetLeft(_carRect) + 0.4);
                    }

                    if (carRot.Angle < 180)
                    {
                        carRot.Angle += 1;

                    }
                });
            }
        }

        private void MoveCarLeft()
        {
            for (int i = 0; i < 480; i++)
            {
                Thread.Sleep(5);
                _mainWindow.Dispatcher.Invoke(() =>
                {
                    Canvas.SetLeft(_carRect, Canvas.GetLeft(_carRect) - 1);
                });
            }
        }

        private void TurningCarLeft()
        {
            for (int i = 0; i < 300; i++)
            {
                Thread.Sleep(5);
                _mainWindow.Dispatcher.Invoke(() =>
                {
                    if (Canvas.GetTop(_carRect) < 593)
                    {
                        Canvas.SetTop(_carRect, Canvas.GetTop(_carRect) + 0.8);

                    }

                    if (carRot.Angle > 90)
                    {
                        Canvas.SetLeft(_carRect, Canvas.GetLeft(_carRect) - 0.4);

                    }
                    else
                    {
                        Canvas.SetLeft(_carRect, Canvas.GetLeft(_carRect) + 0.8);
                    }

                    if (carRot.Angle > 0)
                    {
                        carRot.Angle -= 1;

                    }
                });
            }
        }

        public void CreateAnimation()
        {
            // Create a rectangle to represent the car
            Rectangle carRectangle = new Rectangle();
            carRectangle.Width = 100;
            carRectangle.Height = 50;
            carRectangle.Fill = Brushes.Red;
            Canvas.SetTop(carRectangle, 240);

            // Add the rectangle to the canvas
            _mainWindow.FrontCanvas.Children.Add(carRectangle);

            // Create a double animation to move the car across the screen
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 500;
            animation.Duration = new Duration(TimeSpan.FromSeconds(2));

            // Set the car's position to be the target of the animation
            Canvas.SetLeft(carRectangle, animation.From.Value);

            // Start the animation
            carRectangle.BeginAnimation(Canvas.LeftProperty, animation);
        }


        public string BGImage
        {
            get => this._BGImage;
            set
            {
                _BGImage = value;
                OnPropertyChanged();
            }
        }
    }
}
