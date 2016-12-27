using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

namespace A3V1
{
    public partial class AddForm : BaseFormLibrary.Form1
    {
        public AddForm()
        {
            InitializeComponent();

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
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
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

                // Add the data to the list of movies, and also the xml file
                addToGlobalData();

                this.Close();
            }
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
            if (yearTextBox.Text.Length == 0)
            {
                error = "Please enter the year";
                e.Cancel = true;
            }
            else if (yearTextBox.Text.Length > 4)
            {
                error = "Too many digits entered";
                e.Cancel = true;
            }
            else if (yearTextBox.Text.Length < 4)
            {
                error = "Not enough digits entered";
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToInt32(yearTextBox.Text) > 2020)
                {
                    error = "The year is too high";
                    e.Cancel = true;
                }
            }
            

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

        private void addToGlobalData()
        {
            char[] whiteSpace = { ' ' };

            // Get the values from the textboxes
            String director = directorTextBox.Text.Trim(whiteSpace);
            String title = titleTextBox.Text.Trim(whiteSpace);
            String actor = actorTextBox.Text.Trim(whiteSpace);
            List<String> actors = new List<String>();
            actors.Add(actor);
            short year = Convert.ToInt16(yearTextBox.Text.Trim(whiteSpace));
            String genre = genreComboBox.SelectedItem.ToString().Trim(whiteSpace);
            List<String> genres = new List<String>();
            genres.Add(genre);
            short rating = Convert.ToInt16(ratingComboBox.SelectedItem.ToString());
            short length = Convert.ToInt16(lengthTextBox.Text.Trim(whiteSpace));

            // Save the values to the Movie list
            Movie newMovie = new Movie(title, year, length, "", director, rating, genres, actors);
            GlobalData.movieList.Add(newMovie);

            // Add the values to XML file
            addToXml(director, title, actor, "" + year, genre, "" + rating , "" + length + " min");
        }

        private void addToXml(String director, String title, String actor, String year, 
            String genre, String rating, String length)
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

            // Fill in the values of the elements in the node
            xmlDirector.InnerText = director;
            xmlTitle.InnerText = title;
            xmlActor.InnerText = actor;
            xmlYear.InnerText = year;
            xmlGenre.InnerText = genre;
            xmlRating.InnerText = rating;
            xmlLength.InnerText = length;

            // Set the parent-child relationship between the elements in the node
            movie.AppendChild(xmlTitle);
            movie.AppendChild(xmlYear);
            movie.AppendChild(xmlLength);
            movie.AppendChild(xmlDirector);
            movie.AppendChild(xmlRating);
            movie.AppendChild(xmlGenre);
            movie.AppendChild(xmlActor);

            doc.DocumentElement.AppendChild(movie);
            doc.Save(fileName);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
