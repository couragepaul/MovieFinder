using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.IO;

namespace A3V1
{
    public partial class EditForm : BaseFormLibrary.Form1
    {
        Movie currentMovie = GlobalData.selectedMovie;
        Movie editedMovie = new Movie();

        public EditForm()
        {
            InitializeComponent();
            
            populateForm(currentMovie);

            // Register events for the error checking of textboxes
            this.directorTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.directorTextBox_Validator);
            this.directorTextBox.Validating += new CancelEventHandler(this.directorTextBox_Validating);
            this.titleTextBox.Validating += new CancelEventHandler(this.titleTextBox_Validating);
            this.actorTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.actorTextBox_Validator);
            this.actorTextBox.Validating += new CancelEventHandler(this.actorTextBox_Validating);
            this.yearTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.yearTextBox_Validator);
            this.yearTextBox.Validating += new CancelEventHandler(this.yearTextBox_Validating);
            this.genreComboBox.Validating += new CancelEventHandler(this.genreComboBox_Validating);
            this.ratingComboBox.Validating += new CancelEventHandler(this.ratingComboBox_Validating);
            this.lengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lengthTextBox_Validator);
            this.lengthTextBox.Validating += new CancelEventHandler(this.lengthTextBox_Validating);

            this.directorTextBox.TextChanged += new EventHandler(this.nameField_Pastings);
            this.actorTextBox.TextChanged += new EventHandler(this.nameField_Pastings);
            this.yearTextBox.TextChanged += new EventHandler(this.numberField_Pastings);
            this.lengthTextBox.TextChanged += new EventHandler(this.numberField_Pastings);
        }

        // Fill in all textboxes with the values of the to be edited Movie
        private void populateForm(Movie currentMovie)
        {
            directorTextBox.Text = currentMovie.getDirector();
            titleTextBox.Text = currentMovie.getTitle();
            actorTextBox.Text = currentMovie.getActors()[0];
            yearTextBox.Text = "" + currentMovie.getYear();
            lengthTextBox.Text = "" + currentMovie.getLength();

            Boolean found = false;
            int i = 0;
            String currentGenre = null;
            String targetGenre = null;
            while (!found && i < 14)
            {
                genreComboBox.SelectedIndex = i;
                currentGenre = genreComboBox.SelectedItem.ToString().ToLower();
                targetGenre = currentMovie.getGenres()[0].ToLower();
                if (currentGenre == "" + targetGenre)
                    found = true;
                else
                    i++;
            }

            found = false;
            i = 0;
            while (!found && i < 11)
            {
                ratingComboBox.SelectedIndex = i;
                if (ratingComboBox.SelectedItem.ToString() == "" + currentMovie.getRating())
                    found = true;
                else
                    i++;
            }
        }

        // If any of the field are empty, return false
        private Boolean checkAllFields()
        {
            Boolean result = true;

            if (directorTextBox.TextLength == 0)
                result = false;
            else if (titleTextBox.TextLength == 0)
                result = false;
            else if (actorTextBox.TextLength == 0)
                result = false;
            else if (yearTextBox.TextLength == 0)
                result = false;
            else if (lengthTextBox.TextLength == 0)
                result = false;
            else if (ratingComboBox.SelectedIndex < 0)
                result = false;
            else if (genreComboBox.SelectedIndex < 0)
                result = false;
            else { }

            return result;
        }

        // Store the values of the edited textboxes to a new Movie variable
        private void storeEditedResult(Movie editedMovie)
        {
            editedMovie.setDirector(directorTextBox.Text);
            editedMovie.setTitle(titleTextBox.Text);
            List<String> actors = new List<String> { actorTextBox.Text };
            editedMovie.setActors(actors);
            editedMovie.setYear(Convert.ToInt16(yearTextBox.Text));
            List<String> genres = new List<String> { genreComboBox.SelectedItem.ToString() };
            editedMovie.setGenres(genres);
            editedMovie.setRating(Convert.ToInt16(ratingComboBox.SelectedItem.ToString()));
            editedMovie.setLength(Convert.ToInt16(lengthTextBox.Text));
        }
        
        private void confirmButton_Click(object sender, EventArgs e)
        {
            Boolean allFieldsNotEmpty = checkAllFields();

            if (allFieldsNotEmpty)
            {
                // Validate all controls (textboxes) in the form
                foreach (Control control in GetAllControls())
                {
                    // Valide this control
                    control.Focus();
                    if (this.Validate() == false)
                    {
                        this.DialogResult = DialogResult.None;
                        break;
                    }
                }

                // Store the values of the edited textboxes to a new Movie variable
                storeEditedResult(editedMovie);

                // Save the changes to the Movie the the entry in GlobalData's movie list
                updateToGlobalData(editedMovie);

                // Save the changes to the xml file
                saveToXml();

                this.Close();
            }
        }

        private void updateToGlobalData(Movie movie)
        {
            GlobalData.movieList[GlobalData.selectedIndex] = movie;
        }

        // Save by calling delete then add
        private void saveToXml()
        {
            // Delete the current Movie node from the xml file
            deleteFromXml(currentMovie);

            // Add the edited Movie node to the xml file
            addToXml(editedMovie.getDirector(), editedMovie.getTitle(), editedMovie.getActors()[0],
                editedMovie.getYear() + "", editedMovie.getGenres()[0], editedMovie.getRating() + "",
                editedMovie.getLength() + "", editedMovie.getComment(), editedMovie.getUserRating() + "");
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
                foreach(XmlNode node in listMovies)
                {
                    // Within a Movie, create a list of its children
                    XmlNodeList listChildren = node.ChildNodes;

                    // Visit each child node
                    foreach(XmlNode dir in listChildren)
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

        // Add a new movie to the xml file
        private void addToXml(String director, String title, String actor, String year,
            String genre, String rating, String length, String comment, String userRating)
        {
            String fileName = GlobalData.fileName;
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            // Create the elements of the xml node
            XmlElement movie = doc.CreateElement("movie");
            XmlElement xmlDirector = doc.CreateElement("director");
            XmlElement xmlTitle = doc.CreateElement("title");
            XmlElement xmlActor = doc.CreateElement("actor");
            XmlElement xmlYear = doc.CreateElement("year");
            XmlElement xmlGenre = doc.CreateElement("genre");
            XmlElement xmlRating = doc.CreateElement("rating");
            XmlElement xmlLength = doc.CreateElement("length");
            XmlElement xmlComment = doc.CreateElement("comment");
            XmlElement xmlUserRating = doc.CreateElement("user_rating");

            // Fill in the values of the elements in the node
            xmlDirector.InnerText = director;
            xmlTitle.InnerText = title;
            xmlActor.InnerText = actor;
            xmlYear.InnerText = year;
            xmlGenre.InnerText = genre;
            xmlRating.InnerText = rating;
            xmlLength.InnerText = length;
            xmlComment.InnerText = comment;
            xmlUserRating.InnerText = userRating;

            // Set the parent-child relationship between the elements in the node
            movie.AppendChild(xmlTitle);
            movie.AppendChild(xmlYear);
            movie.AppendChild(xmlLength);
            movie.AppendChild(xmlDirector);
            movie.AppendChild(xmlRating);
            movie.AppendChild(xmlGenre);
            movie.AppendChild(xmlActor);
            movie.AppendChild(xmlComment);
            movie.AppendChild(xmlUserRating);

            doc.DocumentElement.AppendChild(movie);
            doc.Save(fileName);
        }

        Control[] GetAllControls()
        {
            ArrayList list = new ArrayList();
            GetAllControls(Controls, list);
            return (Control[])list.ToArray(typeof(Control));
        }

        void GetAllControls(Control.ControlCollection controls, ArrayList list)
        {
            foreach (Control control in controls)
            {
                if (control.HasChildren)
                    GetAllControls(control.Controls, list);
                list.Add(control);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void directorTextBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            if (directorTextBox.Text.Length == 0)
            {
                error = "Please enter a name";
                e.Cancel = true;
            }

            char[] whiteSpace = { ' ' };
            if (directorTextBox.Text.Trim(whiteSpace).Length == 0)
            {
                error = "Please enter a name";
                e.Cancel = true;
            }

            if (error != null)
                errorProvider1.SetError((Control)sender, error);
            else
                errorProvider1.Clear();
        }

        private void titleTextBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            if (titleTextBox.Text.Length == 0)
            {
                error = "Please enter the title";
                e.Cancel = true;
            }

            char[] whiteSpace = { ' ' };
            if (titleTextBox.Text.Trim(whiteSpace).Length == 0)
            {
                error = "Please enter a title";
                e.Cancel = true;
            }

            if (error != null)
                errorProvider1.SetError((Control)sender, error);
            else
                errorProvider1.Clear();
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

        private void actorTextBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            if (actorTextBox.Text.Length == 0)
            {
                error = "Please enter a name";
                e.Cancel = true;
            }

            char[] whiteSpace = { ' ' };
            if (directorTextBox.Text.Trim(whiteSpace).Length == 0)
            {
                error = "Please enter a name";
                e.Cancel = true;
            }

            if (error != null)
                errorProvider1.SetError((Control)sender, error);
            else
                errorProvider1.Clear();
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

        private void genreComboBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            int index = genreComboBox.SelectedIndex;
            if (genreComboBox.SelectedIndex < 0)
            {
                error = "Please select a genre";
                e.Cancel = true;
            }

            if (error != null)
                errorProvider1.SetError((Control)sender, error);
            else
                errorProvider1.Clear();
        }

        private void ratingComboBox_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            if (ratingComboBox.SelectedIndex < 0)
            {
                error = "Please select a genre";
                e.Cancel = true;
            }

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
            if (lengthTextBox.Text.Length == 0)
            {
                error = "Please enter a length";
                e.Cancel = true;
            }
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
    }
}
