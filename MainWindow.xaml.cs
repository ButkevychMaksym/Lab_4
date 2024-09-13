using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CoordinateQuarter
{
    /// <summary>
    /// The MainWindow class that handles the user interface and drawing of points on the coordinate plane.
    /// </summary>
    public partial class MainWindow : Window
    {
        private ButtonHandler _buttonHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Sets up the button handler and prepares the window for user interaction.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _buttonHandler = new ButtonHandler(this);
        }

        /// <summary>
        /// Handles the event when the calculate button is clicked.
        /// Delegates the event to the <see cref="ButtonHandler"/>.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button.</param>
        /// <param name="e">Event data related to the button click event.</param>
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            _buttonHandler.OnButtonClick(sender, e);
        }

        /// <summary>
        /// Draws the point and coordinate axes on the canvas.
        /// </summary>
        /// <param name="point">The point data containing X and Y coordinates to be drawn on the graph.</param>
        public void DrawPoint(PointData point)
        {
            // Set the center of the canvas
            double centerX = canvasGraph.Width / 2;
            double centerY = canvasGraph.Height / 2;

            // Drawing the X axis
            Line xAxis = new Line
            {
                X1 = 0,
                Y1 = centerY,
                X2 = canvasGraph.Width,
                Y2 = centerY,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            // Drawing the Y axis
            Line yAxis = new Line
            {
                X1 = centerX,
                Y1 = 0,
                X2 = centerX,
                Y2 = canvasGraph.Height,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            // Adding the axes to the canvas
            canvasGraph.Children.Add(xAxis);
            canvasGraph.Children.Add(yAxis);

            // Scaling the point for visualization
            int scale = 20;
            double pointX = centerX + point.X * scale;
            double pointY = centerY - point.Y * scale; // Inverted Y axis for correct orientation

            // Drawing the point as a red ellipse
            Ellipse ellipse = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Red
            };

            // Centering the ellipse at the correct coordinates
            Canvas.SetLeft(ellipse, pointX - 5);
            Canvas.SetTop(ellipse, pointY - 5);

            // Adding the point to the canvas
            canvasGraph.Children.Add(ellipse);
        }
    }

    /// <summary>
    /// A class to store the coordinates of a point.
    /// </summary>
    public class PointData
    {
        /// <summary>
        /// Gets or sets the X coordinate of the point.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the point.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointData"/> class with the specified X and Y coordinates.
        /// </summary>
        /// <param name="x">The X coordinate of the point.</param>
        /// <param name="y">The Y coordinate of the point.</param>
        public PointData(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
