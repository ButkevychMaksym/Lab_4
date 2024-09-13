using System;
using System.Windows;

namespace CoordinateQuarter
{
    /// <summary>
    /// Class responsible for handling button click events in the MainWindow.
    /// </summary>
    public class ButtonHandler
    {
        private MainWindow _window;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonHandler"/> class.
        /// </summary>
        /// <param name="window">The instance of the MainWindow where the handler is applied.</param>
        public ButtonHandler(MainWindow window)
        {
            _window = window;
        }

        /// <summary>
        /// Handles the button click event to process the point coordinates and determine the quarter.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button.</param>
        /// <param name="e">Event data associated with the button click event.</param>
        public void OnButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // Parse the X and Y coordinates from text fields
                float x = float.Parse(_window.txtX.Text);
                float y = float.Parse(_window.txtY.Text);

                // Create a PointData object with the parsed coordinates
                PointData point = new PointData(x, y);

                // Get the quarter where the point is located
                string quarter = QuarterCalculator.GetQuarter(point);

                // Display the result in the label
                _window.lblResult.Content = "Точка знаходиться " + quarter;

                // Clear the canvas before drawing
                _window.canvasGraph.Children.Clear();

                // Draw the point on the canvas
                _window.DrawPoint(point);
            }
            catch (Exception ex)
            {
                // Show an error message if input is invalid
                MessageBox.Show("Invalid input");
            }
        }
    }
}
