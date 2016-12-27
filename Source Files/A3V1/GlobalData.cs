using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3V1
{
    public class GlobalData
    {
        public static String fileName = "movies.xml";

        // currentResult, xPostOfDot, yPostOfDot are parallel arrays storing the result of the search, as well as the x-y location of the dot
        public static List<Movie> movieList = new List<Movie>();    // List containing Movie objects
        public static List<Movie> currentResult = null;             // List containing Movies that satisfy the current search
        public static Movie selectedMovie = null;                   // The current Movie selected from the graph
        public static int selectedIndex = -1;                       // The index of the currently selected Movie in the list of Movies
        public static List<int> xPosOfDot = new List<int>();        // List containing the x position of the dot of the movie in the graph
        public static List<int> yPosOfDot = new List<int>();        // List containing the y position of the dot of the movie in the graph
        public static List<String> toggledGenres = new List<String>();

        // Points that define the four corners of the scatter plot
        public static Point topLeftCorner = new Point(35, 35);
        public static Point bottomLeftCorner = new Point(35, 335);
        public static Point bottomRightCorner = new Point(625, 335);

        // The bounds of the values for the two axes
        public static int xUpperBound = 2020;
        public static int xLowerBound = 1940;
        public static int yUpperBound = 10;
        public static int yLowerBound = 0;

        // Variables pertaining to the drawing of the graph
        public static Brush blackBrush = (Brush)Brushes.Black;
        public static int ellipseDiameter = 10;
    }
}
