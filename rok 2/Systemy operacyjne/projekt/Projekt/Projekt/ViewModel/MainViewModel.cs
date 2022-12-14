using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System;
using System.Windows.Input;
using Projekt.Command;
using System.Windows.Media.Media3D;

namespace Projekt.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _BGImage = @"C:\Users\petit\Desktop\repos\UO\rok 2\Systemy operacyjne\projekt\Projekt\Projekt\Assets\Image\mapa_v3.png";
        private readonly MainWindow _mainWindow;
        
        //Canvas canvas = new Canvas();
        Rectangle _carRect;
        

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
            _carRect.Width = 100;
            _carRect.Height = 50;
            _carRect.Fill = Brushes.Red;

            // Create TranslateTransform and RotateTransform objects for the car
            TranslateTransform carPos = new TranslateTransform();
            RotateTransform carRot = new RotateTransform();

            // Set the car's initial position and orientation
            carPos.X = 100;
            carPos.Y = 100;
            carRot.Angle = 0;

            // Apply the transforms to the car Rectangle
            _carRect.RenderTransform = carPos;
            _carRect.RenderTransformOrigin = new Point(0.5, 0.5);
            _carRect.RenderTransform = carRot;

            // Add the car Rectangle to the Canvas
            _mainWindow.FrontCanvas.Children.Add(_carRect);

            // Create a DoubleAnimation to move the car
            DoubleAnimation moveCar = new DoubleAnimation();
            moveCar.From = 0;
            moveCar.To = 500;
            moveCar.Duration = new Duration(TimeSpan.FromSeconds(1));

            _carRect.BeginAnimation(Canvas.LeftProperty, moveCar);

            carRot.Angle += 5;
            carPos.X -= 10;


            // Handle user input events to determine the car's movement and rotation
            // and update the car's TranslateTransform and RotateTransform properties accordingly

            // For example, you could use the KeyDown event to handle keyboard input:
        }

        private void MoveCar()
        {

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
