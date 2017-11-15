using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Gaming.Input;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace flightView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        RawGameController _controller;

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer _dispatcherTimer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(10)
            };
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
            _dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            int i = 0;

            while ((i < RawGameController.RawGameControllers.Count) && (i < 3)) 
            {
                // Grab the first controller
                _controller = RawGameController.RawGameControllers.ElementAt(i);

                // Register XAML names
                System.Windows.Shapes.Ellipse _joystickPos = (System.Windows.Shapes.Ellipse)FindName("JoystickPos" + i);
                System.Windows.Shapes.Rectangle _joystickVec = (System.Windows.Shapes.Rectangle)FindName("JoystickVec" + i);

                // fieldTB = (TextBox)this.FindName("Field_CompanyName");

                // Initialize array of readings
                var _buttonReadings = new bool[_controller.ButtonCount];
                var _switchReadings = new GameControllerSwitchPosition[_controller.SwitchCount];
                var _axisReadings = new double[_controller.AxisCount];

                // Get readings from controller
                _controller.GetCurrentReading(_buttonReadings, _switchReadings, _axisReadings);

                // Find transformations
                double _verticalAxisMargin = _axisReadings[1] * 200 + 25;
                double _horizontalAxisMargin = _axisReadings[0] * 200 + 25;
                System.Windows.Media.RotateTransform rotateTransform = new System.Windows.Media.RotateTransform();
                // Check if the axis is related to the pedals and then reverse
                if (i != 2)
                {
                    rotateTransform.Angle = _axisReadings[2] * 90 - 45;
                }
                else
                {
                    rotateTransform.Angle = (_axisReadings[2] * 90 - 45) * (-1);
                }


                // Apply transformation
                _joystickPos.Margin = new System.Windows.Thickness(_horizontalAxisMargin, _verticalAxisMargin, 0, 0);
                if (i != 2)
                {
                    _joystickVec.Margin = new System.Windows.Thickness(_horizontalAxisMargin + 20, _verticalAxisMargin, 0, 0);
                }
                _joystickVec.RenderTransform = rotateTransform;

                // Increase loop control
                i++;
            }
        }
    }
}
