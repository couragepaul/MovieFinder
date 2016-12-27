using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace A3V1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1040, 510);
            GlobalData globalData = new GlobalData();
            XmlParser xmlParser = new XmlParser();
            xmlParser.readData();
            clearSearchFields();
            search();
            this.MouseClick += new MouseEventHandler(this.displayMovieResult);
            pictureBox1.Paint += new PaintEventHandler(this.drawPoints);

            // Register events for the error checking of textboxes
            this.directorTextBox.KeyPress += new KeyPressEventHandler(this.directorTextBox_Validator);
            this.directorTextBox.TextChanged += new EventHandler(this.nameField_Pastings);
            this.actorTextBox.KeyPress += new KeyPressEventHandler(this.actorTextBox_Validator);
            this.actorTextBox.TextChanged += new EventHandler(this.nameField_Pastings);
            this.yearTextBox.KeyPress += new KeyPressEventHandler(this.yearTextBox_Validator);
            this.yearTextBox.Validating += new CancelEventHandler(this.yearTextBox_Validating);
            this.yearTextBox.TextChanged += new EventHandler(this.numberField_Pastings);
            this.lengthTextBox.KeyPress += new KeyPressEventHandler(this.lengthTextBox_Validator);
            this.lengthTextBox.Validating += new CancelEventHandler(this.lengthTextBox_Validating);
            this.lengthTextBox.TextChanged += new EventHandler(this.numberField_Pastings);

            // Register events for drag and drop
            this.directorTextBox.DragEnter += new DragEventHandler(this.textBox_DragEnter);
            this.directorTextBox.DragDrop += new DragEventHandler(this.textBox_DragDrop);
            this.directorResultLabel.MouseDown += new MouseEventHandler(this.resultLabel_MouseDown);
            this.titleTextBox.DragEnter += new DragEventHandler(this.textBox_DragEnter);
            this.titleTextBox.DragDrop += new DragEventHandler(this.textBox_DragDrop);
            this.titleResultLabel.MouseDown += new MouseEventHandler(this.resultLabel_MouseDown);
            this.actorTextBox.DragEnter += new DragEventHandler(this.textBox_DragEnter);
            this.actorTextBox.DragDrop += new DragEventHandler(this.textBox_DragDrop);
            this.actorsResultLabel.MouseDown += new MouseEventHandler(this.resultLabel_MouseDown);
            this.yearTextBox.DragEnter += new DragEventHandler(this.textBox_DragEnter);
            this.yearTextBox.DragDrop += new DragEventHandler(this.textBox_DragDrop);
            this.yearResultLabel.MouseDown += new MouseEventHandler(this.resultLabel_MouseDown);
            this.lengthTextBox.DragEnter += new DragEventHandler(this.textBox_DragEnter);
            this.lengthTextBox.DragDrop += new DragEventHandler(this.textBox_DragDrop);
            this.lengthResultLabel.MouseDown += new MouseEventHandler(this.resultLabel_MouseDown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Paint += new PaintEventHandler(this.drawAxes);
            pictureBox1.MouseClick += new MouseEventHandler(this.displayMovieResult);
            trackBar1.ValueChanged += new EventHandler(this.trackBarValueChanged);

            // Create the tooltips
            ToolTip toolTip1 = new ToolTip();
            ToolTip toolTip2 = new ToolTip();
            ToolTip toolTip3 = new ToolTip();
            ToolTip toolTip4 = new ToolTip();
            ToolTip toolTip5 = new ToolTip();

            // Set up the delays for the tooltips
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 1000;
            toolTip2.ReshowDelay = 500;
            toolTip3.AutoPopDelay = 5000;
            toolTip3.InitialDelay = 1000;
            toolTip3.ReshowDelay = 500;
            toolTip4.AutoPopDelay = 5000;
            toolTip4.InitialDelay = 1000;
            toolTip4.ReshowDelay = 500;
            toolTip5.AutoPopDelay = 5000;
            toolTip5.InitialDelay = 1000;
            toolTip5.ReshowDelay = 500;

            // Force the tooltip to always be displayed
            toolTip1.ShowAlways = true;
            toolTip2.ShowAlways = true;
            toolTip3.ShowAlways = true;
            toolTip4.ShowAlways = true;
            toolTip5.ShowAlways = true;

            // Set up the tooltips
            toolTip1.SetToolTip(this.directorTextBox, "Enter the director's name.");
            toolTip2.SetToolTip(this.titleTextBox, "Enter the movie's title.");
            toolTip3.SetToolTip(this.actorTextBox, "Enter the actor's name.");
            toolTip4.SetToolTip(this.yearTextBox, "Enter the movie's publishing year.");
            toolTip5.SetToolTip(this.lengthTextBox, "Enter the movie's length in minutes.");

            trackBarValue.Text = trackBar1.Maximum.ToString();
            trackBar1.Value = Convert.ToInt32(trackBar1.Maximum.ToString());
        }

        // Draws the axes of the graph
        private void drawAxes(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Create pen
            Pen blackPen = new Pen(Color.Black, 2);

            // Draw line to screen
            g.DrawLine(blackPen, GlobalData.topLeftCorner, GlobalData.bottomLeftCorner);
            g.DrawLine(blackPen, GlobalData.bottomLeftCorner, GlobalData.bottomRightCorner);

            // Re-center the y axis rating labels
            int xLabelsLocation = rating10Label.Location.X;
            int yLabelsOffset = (rating0Label.Location.Y - rating10Label.Location.Y) / 10;
            rating9Label.Location = new Point(xLabelsLocation, yLabelsOffset + rating10Label.Location.Y);
            rating8Label.Location = new Point(xLabelsLocation, yLabelsOffset + rating9Label.Location.Y);
            rating7Label.Location = new Point(xLabelsLocation, yLabelsOffset + rating8Label.Location.Y);
            rating6Label.Location = new Point(xLabelsLocation, yLabelsOffset + rating7Label.Location.Y);
            rating5Label.Location = new Point(xLabelsLocation, yLabelsOffset + rating6Label.Location.Y);
            rating4Label.Location = new Point(xLabelsLocation, yLabelsOffset + rating5Label.Location.Y);
            rating3Label.Location = new Point(xLabelsLocation, yLabelsOffset + rating4Label.Location.Y);
            rating2Label.Location = new Point(xLabelsLocation, yLabelsOffset + rating3Label.Location.Y);
            rating1Label.Location = new Point(xLabelsLocation, yLabelsOffset + rating2Label.Location.Y);
            rating0Label.Location = new Point(rating10Label.Location.X, rating0Label.Location.Y);

            // Re-center the x axis year labels
            int yLabelsLocation = year2020Label.Location.Y;
            int xLabelsOffset = (year2020Label.Location.X - year1940Label.Location.X) / 8;
            year1950Label.Location = new Point(year1940Label.Location.X + xLabelsOffset, yLabelsLocation);
            year1960Label.Location = new Point(year1950Label.Location.X + xLabelsOffset, yLabelsLocation);
            year1970Label.Location = new Point(year1960Label.Location.X + xLabelsOffset, yLabelsLocation);
            year1980Label.Location = new Point(year1970Label.Location.X + xLabelsOffset, yLabelsLocation);
            year1990Label.Location = new Point(year1980Label.Location.X + xLabelsOffset, yLabelsLocation);
            year2000Label.Location = new Point(year1990Label.Location.X + xLabelsOffset, yLabelsLocation);
            year2010Label.Location = new Point(year2000Label.Location.X + xLabelsOffset, yLabelsLocation);
            year2020Label.Location = new Point(year2010Label.Location.X + xLabelsOffset, yLabelsLocation);

            // Re-center the axis labels
            ratingAxisLabel.Location = new Point(GlobalData.topLeftCorner.X - ratingAxisLabel.Width / 2,
                GlobalData.topLeftCorner.Y - ratingAxisLabel.Height / 2);
            yearAxisLabel.Location = new Point(year1980Label.Location.X, GlobalData.bottomLeftCorner.Y + yearLabel.Height + 5);

            // Dispose objects
            blackPen.Dispose();
        }

        // Draw the data points of the graph, Y axis is rating, X axis is year
        private void drawPoints(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GlobalData.xPosOfDot = new List<int>();
            GlobalData.yPosOfDot = new List<int>();

            // Variables related to the points
            short rating = 0;
            short year = 0;
            int xLocation = 0;
            int yLocation = 0;
            Point currentPoint = new Point(0, 0);
            int diameter = GlobalData.ellipseDiameter;

            // Get the length of the axes
            int xLength = GlobalData.bottomRightCorner.X - GlobalData.bottomLeftCorner.X;
            int yLength = GlobalData.bottomLeftCorner.Y - GlobalData.topLeftCorner.Y;
            int xAxisPixelsPerYear = (year1980Label.Location.X - year1970Label.Location.X) / 10;

            // Check to make sure there are Movie objects in the result of the search
            if (GlobalData.currentResult != null)
            {
                // Clear the currently drawn points on the form
                pictureBox1.Invalidate();

                int count = GlobalData.currentResult.Count();

                // If result is not empty, draw the points
                for (int i = 0; i < count; i++)
                {
                    // Get the rating and year parameters
                    rating = GlobalData.currentResult[i].getRating();
                    year = GlobalData.currentResult[i].getYear();

                    // Calculate where to draw the point
                    xLocation = year1940Label.Location.X + (xAxisPixelsPerYear * (year - 1940)) + 3;
                    yLocation = getYLocation(rating) - 8;

                    // Add the information about the point to the list in the global data
                    int counttttt = GlobalData.xPosOfDot.Count();
                    GlobalData.xPosOfDot.Add(xLocation);
                    GlobalData.yPosOfDot.Add(yLocation);

                    // Draw the point
                    currentPoint = new Point(xLocation, yLocation);
                    changeBrushColour(GlobalData.currentResult[i].getGenres()[0]);
                    g.FillEllipse(GlobalData.blackBrush, xLocation, yLocation, diameter, diameter);
                }
            }
        }

        private void changeBrushColour(String genre)
        {
            genre = genre.ToLower();

            switch (genre)
            {
                case ("action"):
                    GlobalData.blackBrush = (Brush)Brushes.MediumSpringGreen;
                    break;
                case ("adventure"):
                    GlobalData.blackBrush = (Brush)Brushes.Violet;
                    break;
                case ("animation"):
                    GlobalData.blackBrush = (Brush)Brushes.Yellow;
                    break;
                case ("comedy"):
                    GlobalData.blackBrush = (Brush)Brushes.Orange;
                    break;
                case ("crime"):
                    GlobalData.blackBrush = (Brush)Brushes.Thistle;
                    break;
                case ("drama"):
                    GlobalData.blackBrush = (Brush)Brushes.Firebrick;
                    break;
                case ("history"):
                    GlobalData.blackBrush = (Brush)Brushes.PeachPuff;
                    break;
                case ("mystery"):
                    GlobalData.blackBrush = (Brush)Brushes.MediumTurquoise;
                    break;
                case ("romance"):
                    GlobalData.blackBrush = (Brush)Brushes.LightSalmon;
                    break;
                case ("sci-fi"):
                    GlobalData.blackBrush = (Brush)Brushes.GreenYellow;
                    break;
                case ("short"):
                    GlobalData.blackBrush = (Brush)Brushes.Olive;
                    break;
                case ("thriller"):
                    GlobalData.blackBrush = (Brush)Brushes.Orange;
                    break;
                case ("war"):
                    GlobalData.blackBrush = (Brush)Brushes.MediumPurple;
                    break;
                case ("western"):
                    GlobalData.blackBrush = (Brush)Brushes.DarkKhaki;
                    break;
            }
        }

        // Given the rating, returns the corresponding Y location on the form's graph
        private int getYLocation(short rating)
        {
            int yLocation = 0;

            switch (rating)
            {
                case (10):
                    yLocation = rating10Label.Location.Y;
                    break;
                case (9):
                    yLocation = rating9Label.Location.Y;
                    break;
                case (8):
                    yLocation = rating8Label.Location.Y;
                    break;
                case (7):
                    yLocation = rating7Label.Location.Y;
                    break;
                case (6):
                    yLocation = rating6Label.Location.Y;
                    break;
                case (5):
                    yLocation = rating5Label.Location.Y;
                    break;
                case (4):
                    yLocation = rating4Label.Location.Y;
                    break;
                case (3):
                    yLocation = rating3Label.Location.Y;
                    break;
                case (2):
                    yLocation = rating2Label.Location.Y;
                    break;
                case (1):
                    yLocation = rating1Label.Location.Y;
                    break;
                case (0):
                    yLocation = rating0Label.Location.Y;
                    break;
            }

            yLocation -= rating10Label.Height;  // Have to do this due to some weird offset
            return yLocation;
        }

        // Display tooltip information about the Movie currently hovering on
        public void displayMovieResult(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point point = e.Location;
            Point currentPoint = new Point(0, 0);
            List<Movie> currResult = GlobalData.currentResult;
            List<int> xPos = GlobalData.xPosOfDot;
            List<int> yPos = GlobalData.yPosOfDot;
            int indexOfResult = -1;
            int diameter = GlobalData.ellipseDiameter;

            // If there are Movies from the result of the search, do the point scanning
            if (currResult != null && currResult.Count() > 0)
            {
                int i = 0;
                Boolean found = false;

                // Loop through the list of positions of the dots on the graph to find which one is being clicked on
                while (i < currResult.Count() && !found)
                {
                    currentPoint = new Point(xPos[i], yPos[i]);
                    if (currentPoint.X - diameter <= point.X && point.X <= currentPoint.X + diameter &&
                        currentPoint.Y - diameter <= point.Y && point.Y <= currentPoint.Y + diameter)
                    {
                        indexOfResult = i;
                        found = true;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            // Display information about the movie
            if (indexOfResult > -1)
            {
                // Re-center the result labels
                recenterResultLabels();

                // Add the currently selected movie to the global variable
                GlobalData.selectedMovie = currResult[indexOfResult];
                GlobalData.selectedIndex = indexOfResult;

                // Enable the edit, delete, share, rate buttons
                editButton.Enabled = true;
                deleteButton.Enabled = true;
                writeCommentButton.Enabled = true;
                rateButton.Enabled = true;
                getCommentButton.Enabled = true;

                // Update the labels
                directorResultLabel.Text = currResult[indexOfResult].getDirector();
                titleResultLabel.Text = currResult[indexOfResult].getTitle();
                yearResultLabel.Text = "" + currResult[indexOfResult].getYear();
                ratingResultLabel.Text = "" + currResult[indexOfResult].getRating();
                lengthResultLabel.Text = "" + currResult[indexOfResult].getLength();

                // Display the user rating
                int userRating = currResult[indexOfResult].getUserRating();
                userRatingResult.Text = "" + userRating;

                // Calculate and display the actors on the result
                String actorsString = "";
                List<String> actors = currResult[indexOfResult].getActors();

                for (int i = 0; i < actors.Count(); i++)
                {
                    actorsString += actors[i];
                    if (i != actors.Count() - 1)
                        actorsString += "\n";
                }

                actorsResultLabel.Text = actorsString;

                if (actors.Count() > 1)
                    shiftLabelsBeloWActors(actors.Count());

                // Calculate and display the genres on the result
                String genresString = "";
                List<String> genres = currResult[indexOfResult].getGenres();

                for (int i = 0; i < genres.Count(); i++)
                {
                    genresString += genres[i];
                    if (i != genres.Count() - 1)
                        genresString += "\n";
                }

                genresResultLabel.Text = genresString;

                if (genres.Count() > 1)
                    shiftLabelsBeloWGenres(genres.Count());
            }
        }

        // Re-center the labels in the result
        private void recenterResultLabels()
        {
            int xLocation = resultLabel1.Location.X;

            resultLabel1.Location = new Point(xLocation, directorLabel.Location.Y);
            resultLabel2.Location = new Point(xLocation, titleLabel.Location.Y);
            resultLabel3.Location = new Point(xLocation, actorLabel.Location.Y);
            resultLabel4.Location = new Point(xLocation, yearLabel.Location.Y);
            resultLabel5.Location = new Point(xLocation, genreLabel.Location.Y);
            resultLabel6.Location = new Point(xLocation, ratingLabel.Location.Y);
            resultLabel7.Location = new Point(xLocation, lengthLabel.Location.Y);

            directorResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel1.Location.Y);
            titleResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel2.Location.Y);
            actorsResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel3.Location.Y);
            yearResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel4.Location.Y);
            genresResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel5.Location.Y);
            ratingResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel6.Location.Y);
            lengthResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel7.Location.Y);
        }

        private void shiftLabelsBeloWActors(int numLines)
        {
            int charHeight = 13;
            int spaceBetweenLines = 23;
            int pixelsToShift = charHeight * numLines;

            int actorsResultEndYPos = actorsResultLabel.Location.Y;
            int xLocation = resultLabel1.Location.X;

            resultLabel4.Location = new Point(xLocation, actorsResultEndYPos + pixelsToShift + spaceBetweenLines / 2);
            resultLabel5.Location = new Point(xLocation, resultLabel4.Location.Y + spaceBetweenLines);
            resultLabel6.Location = new Point(xLocation, resultLabel5.Location.Y + spaceBetweenLines);
            resultLabel7.Location = new Point(xLocation, resultLabel6.Location.Y + spaceBetweenLines);

            yearResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel4.Location.Y);
            genresResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel5.Location.Y);
            ratingResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel6.Location.Y);
            lengthResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel7.Location.Y);
        }

        private void shiftLabelsBeloWGenres(int numLines)
        {
            int charHeight = 13;
            int spaceBetweenLines = 23;
            int pixelsToShift = charHeight * numLines;

            int genresResultEndYPos = genresResultLabel.Location.Y;
            int xLocation = resultLabel1.Location.X;

            resultLabel6.Location = new Point(xLocation, genresResultEndYPos + pixelsToShift + spaceBetweenLines / 2);
            resultLabel7.Location = new Point(xLocation, resultLabel6.Location.Y + spaceBetweenLines);

            ratingResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel6.Location.Y);
            lengthResultLabel.Location = new Point(directorResultLabel.Location.X, resultLabel7.Location.Y);
        }

        private void directorTextBox_Validator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender.GetType().Name.ToLower() == "textbox")
            {
                t = (TextBox)sender;
                if (t.Name == directorTextBox.Name)
                {
                    // Disallow any non letter or space characters
                    if (Char.IsSymbol(e.KeyChar) || Char.IsNumber(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void actorTextBox_Validator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender.GetType().Name.ToLower() == "textbox")
            {
                t = (TextBox)sender;
                if (t.Name == actorTextBox.Name)
                {
                    // Disallow any non letter or space characters
                    if (Char.IsSymbol(e.KeyChar) || Char.IsNumber(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void yearTextBox_Validator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender.GetType().Name.ToLower() == "textbox")
            {
                t = (TextBox)sender;
                if (t.Name == yearTextBox.Name)
                {
                    // Disallow any non numbers
                    if (Char.IsNumber(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void yearTextBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            if (yearTextBox.Text.Length > 4)
            {
                error = "Too many digits entered";
                e.Cancel = true;
            }
            else if (yearTextBox.Text.Length < 4 && yearTextBox.Text.Length > 0)
            {
                error = "Not enough digits entered";
                e.Cancel = true;
            }
            else if (yearTextBox.Text.Length == 4)
            {
                if (Convert.ToInt32(yearTextBox.Text) > 2020)
                {
                    error = "The year is too high";
                    e.Cancel = true;
                }
            }
            else
            { }

            if (error != null)
                errorProvider1.SetError((Control)sender, error);
            else
                errorProvider1.Clear();
        }

        private void lengthTextBox_Validator(object sender, KeyPressEventArgs e)
        {
            TextBox t;
            if (sender.GetType().Name.ToLower() == "textbox")
            {
                t = (TextBox)sender;
                if (t.Name == lengthTextBox.Name)
                {
                    // Disallow any non digits
                    if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void lengthTextBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            if (lengthTextBox.Text.Length > 3)
            {
                error = "Too many digits";
                e.Cancel = true;
            }

            if (error != null)
                errorProvider1.SetError((Control)sender, error);
            else
                errorProvider1.Clear();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            //pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPoints);
            initializeGlobalData();

            // Update status label
            searchStatusLabel.Text = "Status: Searching...";

            // Get the values from the textboxes
            String title = titleTextBox.Text;
            String year = yearTextBox.Text;
            String length = lengthTextBox.Text;
            String director = directorTextBox.Text;
            String rating = ratingComboBox.SelectedItem.ToString();
            String actor = actorTextBox.Text;

            // Check if rating is "All"
            if (String.Compare(rating.ToLower(), "all") == 0)
            {
                rating = "";
            }

            List<String> genres = new List<String>();

            if (GlobalData.toggledGenres.Count() == 0 && genreComboBox.SelectedIndex == 15)
                genreComboBox.SelectedIndex = 0;
            if (GlobalData.toggledGenres.Count() > 0)
                genreComboBox.SelectedIndex = 15;

            String genre = genreComboBox.SelectedItem.ToString();

            // Check which genre is selected in the combo box
            if (String.Compare(genre.ToLower(), "all") == 0)
            {
                genres = new List<String>();
            }
            else
            {
                genres.Add(genre);
            }

            // Check which genres are toggled in the toggles
            if (GlobalData.toggledGenres.Count() > 0)
            {
                genres = GlobalData.toggledGenres;
                genreComboBox.SelectedIndex = 15;
            }
            else if (GlobalData.toggledGenres.Count() == 0)
            {
                if (genreComboBox.SelectedIndex == 15)
                {
                    genreComboBox.SelectedIndex = 0;
                }
            }
            else
            {
            }

            // Send the value to a search function
            GlobalData.currentResult = searchMovies(title, year, length, director, rating, genres, actor);

            // Update status label to show result
            if (GlobalData.currentResult == null)
                searchStatusLabel.Text = "Status: Found 0 movie.";
            else if (GlobalData.currentResult.Count() == 1)
                searchStatusLabel.Text = "Status: Found " + GlobalData.currentResult.Count() + " movie.";
            else
                searchStatusLabel.Text = "Status: Found " + GlobalData.currentResult.Count() + " movies.";

            // Calls the function to draw the data points on the graph
            pictureBox1.Refresh();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearSearchFields();
            initializeGlobalData();
        }

        private void clearSearchFields()
        {
            // Clear the textboxes
            directorTextBox.Text = "";
            titleTextBox.Text = "";
            actorTextBox.Text = "";
            yearTextBox.Text = "";
            genreComboBox.SelectedIndex = 0;
            ratingComboBox.SelectedIndex = 0;
            lengthTextBox.Text = "";

            // Clear the toggle buttons
            actionToggle.Checked = false;
            adventureToggle.Checked = false;
            animationToggle.Checked = false;
            comedyToggle.Checked = false;
            crimeToggle.Checked = false;
            dramaToggle.Checked = false;
            historyToggle.Checked = false;
            mysteryToggle.Checked = false;
            romanceToggle.Checked = false;
            scifiToggle.Checked = false;
            shortToggle.Checked = false;
            thrillerToggle.Checked = false;
            warToggle.Checked = false;
            westernToggle.Checked = false;

            // Clear the results
            directorResultLabel.Text = "";
            titleResultLabel.Text = "";
            actorsResultLabel.Text = "";
            yearResultLabel.Text = "";
            genresResultLabel.Text = "";
            ratingResultLabel.Text = "";
            lengthResultLabel.Text = "";
            userRatingResult.Text = "n/a";
            recenterResultLabels();

            // Disable the edit and delete button
            editButton.Enabled = false;
            deleteButton.Enabled = false;
            writeCommentButton.Enabled = false;
            rateButton.Enabled = false;
            getCommentButton.Enabled = false;

            initializeGlobalData();
        }

        private void initializeGlobalData()
        {
            GlobalData.currentResult = null;
            GlobalData.selectedMovie = null;
            GlobalData.selectedIndex = -1;
            GlobalData.xPosOfDot = new List<int>();
            GlobalData.yPosOfDot = new List<int>();
            searchStatusLabel.Text = "Status: Ready to search.";
        }

        /*Search the list of movies by all of the fields in the parameter.  If a field is empty or null, then 
         that field will be skipped.  The search filters the result after each parameter until all of them
         have been searched, or until the result is empty (no match).
         PARAMETERS:    Takes in all the possible searchable fields as Strings.
         RETURN VAL:    Returns a list of Movies that qualifies the search.  The list is null if no result found.*/
        public List<Movie> searchMovies(String title, String year, String length, String director, String rating,
            List<String> genres, String actor)
        {
            GlobalData.currentResult = new List<Movie>();   // Initialize the list storing the result of the current search
            List<Movie> result = null;

            // If the list is not empty, start searching by title
            if (GlobalData.movieList.Count() > 0)
            {
                if (String.Compare(title, "") != 0)     // If title is not empty
                    result = searchByTitle(GlobalData.movieList, title);
                else
                    result = GlobalData.movieList;
            }

            // If after searching by title, the result still contains Movies, search by year
            if (result != null && result.Count() > 0)
            {
                if (String.Compare(year, "") != 0)      // If year field is not empty
                    result = searchByYear(result, Convert.ToInt16(year));
            }

            // If after searching by year, the result still contains Movies, search by length
            if (result != null && result.Count() > 0)
            {
                if (String.Compare(length, "") != 0)    // If length field is not empty
                    result = searchByLength(result, Convert.ToInt16(length));
            }

            // If after searching by length, the result still contains Movies, search by director
            if (result != null && result.Count() > 0)
            {
                if (String.Compare(director, "") != 0)    // If director field is not empty
                    result = searchByDirector(result, director);
            }

            // If after searching by director, the result still contains Movies, search by rating
            if (result != null && result.Count() > 0)
            {
                if (String.Compare(rating, "") != 0)    // If rating field is not empty
                    result = searchByRating(result, Convert.ToInt16(rating));
            }

            // If after searching by rating, the result still contains Movies, search by genre
            if (result != null && result.Count() > 0 && genres != null)
            {
                // Filter the search and retain all the Movie containing any of the genre found in the genres list
                result = searchByGenre(result, genres);
            }

            // If after searching by genre, the result still contains Movies, search by actor
            if (result != null && result.Count() > 0)
            {
                if (String.Compare(actor, "") != 0)    // If actor field is not empty
                    result = searchByActor(result, actor);
            }

            if (result != null)
            {
                if (result.Count() == 0)    // If the list is empty
                    result = null;
            }

            return result;
        }

        // Search the input list and return a list of movies with the same title
        public List<Movie> searchByTitle(List<Movie> inputList, String title)
        {
            List<Movie> result = null;
            int listLength = inputList.Count();

            if (listLength > 0)
            {
                result = new List<Movie>();

                // Loop through the list to check if the title is the same one
                for (int i = 0; i < listLength; i++)
                {
                    if (inputList[i].getTitle().ToLower().Contains(title.ToLower()))
                    {
                        result.Add(inputList[i]);
                    }
                }
            }

            return result;
        }

        // Search the input list and return a list of movies with the same year
        public List<Movie> searchByYear(List<Movie> inputList, short year)
        {
            List<Movie> result = null;
            int listLength = inputList.Count();

            if (listLength > 0)
            {
                result = new List<Movie>();

                // Loop through the list to check if the year is the same one
                for (int i = 0; i < listLength; i++)
                {
                    if (inputList[i].getYear() == year)
                    {
                        result.Add(inputList[i]);
                    }
                }
            }

            return result;
        }

        // Search the input list and return a list of movies with shorter length than length
        public List<Movie> searchByLength(List<Movie> inputList, short length)
        {
            List<Movie> result = null;
            int listLength = inputList.Count();

            if (listLength > 0)
            {
                result = new List<Movie>();
                // Loop through the list to check if the length is the same one
                for (int i = 0; i < listLength; i++)
                {
                    if (inputList[i].getLength() <= length)
                    {
                        result.Add(inputList[i]);
                    }
                }
            }

            return result;
        }

        // Search the input list and return a list of movies with the same director
        public List<Movie> searchByDirector(List<Movie> inputList, String director)
        {
            List<Movie> result = null;
            int listLength = inputList.Count();

            if (listLength > 0)
            {
                result = new List<Movie>();
                // Loop through the list to check if the director is the same one
                for (int i = 0; i < listLength; i++)
                {
                    if (inputList[i].getDirector().ToLower().Contains(director.ToLower()))
                    {
                        result.Add(inputList[i]);
                    }
                }
            }

            return result;
        }

        // Search the input list and return a list of movies with the same rating
        public List<Movie> searchByRating(List<Movie> inputList, short rating)
        {
            List<Movie> result = null;
            int listLength = inputList.Count();

            if (listLength > 0)
            {
                result = new List<Movie>();
                // Loop through the list to check if the rating is the same one
                for (int i = 0; i < listLength; i++)
                {
                    if (inputList[i].getRating() == rating)
                    {
                        result.Add(inputList[i]);
                    }
                }
            }

            return result;
        }

        // Search the input list and return a list of movies with the same genre
        public List<Movie> searchByGenre(List<Movie> inputList, List<String> genres)
        {
            Movie currentMovie = null;
            List<Movie> result = null;
            List<String> currentGenres = null;
            int numPassed = 0;

            if (inputList.Count() > 0)
            {
                result = new List<Movie>();

                // Loop through the list of Movies
                for (int i = 0; i < inputList.Count(); i++)
                {
                    currentMovie = inputList[i];
                    currentGenres = currentMovie.getGenres();
                    numPassed = 0;

                    // Loop through the list of genres in the toggled genre list
                    for (int j = 0; j < genres.Count(); j++)
                    {
                        if (findStrInList(genres[j], currentGenres))
                            numPassed++;
                    }

                    // Check if all of the genre in genres passed
                    if (numPassed == genres.Count())
                    {
                        result.Add(currentMovie);
                    }
                }
            }

            return result;
        }

        private Boolean findStrInList(String target, List<String> list)
        {
            Boolean found = false;
            target = target.ToLower();

            for (int i = 0; i < list.Count() && !found; i++)
            {
                if (String.Compare(target, list[i].ToLower()) == 0)   // If found
                    found = true;
            }

            return found;
        }

        // Search the input list and return a list of movies with the same actor
        public List<Movie> searchByActor(List<Movie> inputList, String actor)
        {
            List<Movie> result = null;
            int listLength = inputList.Count();

            if (listLength > 0)
            {
                result = new List<Movie>();
                // Loop through the list to check if the actor is the same one
                for (int i = 0; i < listLength; i++)
                {
                    int actorListLength = inputList[i].getActors().Count();
                    int j = 0;
                    Boolean found = false;

                    // Loop through the list containing genres of a movie
                    while (j < actorListLength && !found)
                    {
                        // If the target genre is found in the list of genres
                        if (inputList[i].getActors()[j].ToLower().Contains(actor.ToLower()))
                        {
                            result.Add(inputList[i]);
                            found = true;
                        }
                        // If not found
                        else
                        {
                            j++;
                        }
                    }
                }
            }

            return result;
        }

        private void actionToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (actionToggle.Checked)
            {
                GlobalData.toggledGenres.Add("action");
            }
            else
            {
                GlobalData.toggledGenres.Remove("action");
            }
            search();
        }

        private void adventureToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (adventureToggle.Checked)
            {
                GlobalData.toggledGenres.Add("adventure");
            }
            else
            {
                GlobalData.toggledGenres.Remove("adventure");
            }
            search();
        }

        private void animationToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (animationToggle.Checked)
            {
                GlobalData.toggledGenres.Add("animation");
            }
            else
            {
                GlobalData.toggledGenres.Remove("animation");
            }
            search();
        }

        private void comedyToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (comedyToggle.Checked)
            {
                GlobalData.toggledGenres.Add("comedy");
            }
            else
            {
                GlobalData.toggledGenres.Remove("comedy");
            }
            search();
        }

        private void crimeToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (crimeToggle.Checked)
            {
                GlobalData.toggledGenres.Add("crime");
            }
            else
            {
                GlobalData.toggledGenres.Remove("crime");
            }
            search();
        }

        private void dramaToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (dramaToggle.Checked)
            {
                GlobalData.toggledGenres.Add("drama");
            }
            else
            {
                GlobalData.toggledGenres.Remove("drama");
            }
            search();
        }

        private void historyToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (historyToggle.Checked)
            {
                GlobalData.toggledGenres.Add("history");
            }
            else
            {
                GlobalData.toggledGenres.Remove("history");
            }
            search();
        }

        private void mysteryToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (mysteryToggle.Checked)
            {
                GlobalData.toggledGenres.Add("mystery");
            }
            else
            {
                GlobalData.toggledGenres.Remove("mystery");
            }
            search();
        }

        private void romanceToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (romanceToggle.Checked)
            {
                GlobalData.toggledGenres.Add("romance");
            }
            else
            {
                GlobalData.toggledGenres.Remove("romance");
            }
            search();
        }

        private void scifiToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (scifiToggle.Checked)
            {
                GlobalData.toggledGenres.Add("scifi");
            }
            else
            {
                GlobalData.toggledGenres.Remove("scifi");
            }
            search();
        }

        private void shortToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (shortToggle.Checked)
            {
                GlobalData.toggledGenres.Add("short");
            }
            else
            {
                GlobalData.toggledGenres.Remove("short");
            }
            search();
        }

        private void thrillerToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (thrillerToggle.Checked)
            {
                GlobalData.toggledGenres.Add("thriller");
            }
            else
            {
                GlobalData.toggledGenres.Remove("thriller");
            }
            search();
        }

        private void warToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (warToggle.Checked)
            {
                GlobalData.toggledGenres.Add("war");
            }
            else
            {
                GlobalData.toggledGenres.Remove("war");
            }
            search();
        }

        private void westernToggle_CheckedChanged(object sender, EventArgs e)
        {
            // If the toggle is checked
            if (westernToggle.Checked)
            {
                GlobalData.toggledGenres.Add("western");
            }
            else
            {
                GlobalData.toggledGenres.Remove("western");
            }
            search();
        }

        private void addMovieButton_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm();
            form.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditForm form = new EditForm();
            form.ShowDialog();
        }

        // Delete from xml the movie that matches the title of the currentMovie parameter
        private void deleteFromXml(Movie currentMovie)
        {
            String fileName = GlobalData.fileName;
            XmlDocument xmlDoc = new XmlDocument();

            if (File.Exists(fileName))
            {
                xmlDoc.Load(fileName);

                // Get a reference to the root node
                XmlElement root = xmlDoc.DocumentElement;

                // Create a list of Movies
                XmlNodeList listMovies = xmlDoc.GetElementsByTagName("movie");

                // Visit each Movie
                foreach (XmlNode node in listMovies)
                {
                    // Within a Movie, create a list of its children
                    XmlNodeList listChildren = node.ChildNodes;

                    // Visit each child node5
                    foreach (XmlNode dir in listChildren)
                    {
                        // If the child node matches the title of the movie
                        if (dir.InnerText.ToLower() == currentMovie.getTitle().ToLower())
                        {
                            node.RemoveAll();

                            // Save the file
                            xmlDoc.Save(fileName);

                            // Stop
                            break;
                        }
                    }
                }
            }
        }

        private void deleteFromGlobalData(int index)
        {
            GlobalData.movieList.RemoveAt(index);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteFromXml(GlobalData.selectedMovie);
            deleteFromGlobalData(GlobalData.selectedIndex);
            clearSearchFields();
            pictureBox1.Invalidate();
            search();
        }

        private void shareButton_Click(object sender, EventArgs e)
        {
            if (GlobalData.selectedMovie != null)
            {
                Form form = new writeCommentForm();
                form.Show();
            }
        }

        private void rateButton_Click(object sender, EventArgs e)
        {
            RateForm form = new RateForm();
            form.ShowDialog();

            // Update the my rating label
            if (GlobalData.selectedMovie != null)
                userRatingResult.Text = GlobalData.selectedMovie.getUserRating() + "";
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            System.Windows.Forms.MessageBox.Show("Here are the actions you could do with the program:\n" +
                "1. Perform advanced search for movies.\n" +
                "2. Click on the data points in the scatter plot to view more info.\n" +
                "3. Add a new movie to the database.\n" +
                "4. Edit or delete the current movie in the result.\n" +
                "5. Share the current movie in the result.\n" +
                "6. Rate the current movie in the result.", "Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            // Check to see whether it's acceptable data
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                // Set the effect of the drag-and-drop to a copy
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.Text = (String)e.Data.GetData(DataFormats.Text);
        }

        private void resultLabel_MouseDown(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            // Start a drag-and-drop operation
            DoDragDrop(l.Text, DragDropEffects.Copy);
        }

        private void nameField_Pastings(object sender, EventArgs e)
        {
            TextBox t;
            if (sender.GetType().Name.ToLower() == "textbox")
            {
                t = (TextBox)sender;
                if (t.Name == directorTextBox.Name || t.Name == actorTextBox.Name)
                {
                    // Disallow any non letters
                    for (int i = 0; i < t.TextLength; i++)
                    {
                        if (Char.IsLetter(t.Text, i) == false)
                        {
                            t.Text = "";
                            break;
                        }
                    }
                }
            }
        }

        private void numberField_Pastings(object sender, EventArgs e)
        {
            TextBox t;
            if (sender.GetType().Name.ToLower() == "textbox")
            {
                t = (TextBox)sender;
                if (t.Name == yearTextBox.Name || t.Name == lengthTextBox.Name)
                {
                    // Disallow any non digits
                    for (int i = 0; i < t.TextLength; i++)
                    {
                        if (Char.IsDigit(t.Text, i) == false)
                        {
                            t.Text = "";
                            break;
                        }
                    }
                }
            }
        }

        // When the trackbar value changed
        private void trackBarValueChanged(object sender, EventArgs e)
        {
            String length = trackBar1.Value.ToString();

            // Update the value of the label
            trackBarValue.Text = length;

            // Perform a new search to filter the result
            lengthTextBox.Text = length;
            search();
        }

        private void getReviewsButton_Click(object sender, EventArgs e)
        {
            if (GlobalData.selectedMovie != null)
            {
                Form form = new getCommentForm();
                form.Show();
            }
        }
    }
}
