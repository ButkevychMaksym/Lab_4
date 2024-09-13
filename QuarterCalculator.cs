namespace CoordinateQuarter
{
    /// <summary>
    /// A static class that provides functionality to determine the quarter of the coordinate plane where a point is located.
    /// </summary>
    public static class QuarterCalculator
    {
        /// <summary>
        /// Determines in which quarter of the coordinate plane the specified point is located.
        /// </summary>
        /// <param name="point">An instance of <see cref="PointData"/> containing the X and Y coordinates of the point.</param>
        /// <returns>
        /// A string indicating the quarter of the coordinate plane where the point is located, 
        /// or if the point lies on one of the axes or at the origin.
        /// </returns>
        public static string GetQuarter(PointData point)
        {
            if (point.X > 0 && point.Y > 0)
                return "в першій четверті"; // First quarter
            else if (point.X < 0 && point.Y > 0)
                return "в другій четверті"; // Second quarter
            else if (point.X < 0 && point.Y < 0)
                return "в третій четверті"; // Third quarter
            else if (point.X > 0 && point.Y < 0)
                return "в четвертій четверті"; // Fourth quarter
            else if (point.X == 0 && point.Y != 0)
                return "на осі Y"; // On the Y-axis
            else if (point.Y == 0 && point.X != 0)
                return "на осі X"; // On the X-axis
            else
                return "на початку координат"; // At the origin
        }
    }
}
