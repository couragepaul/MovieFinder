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
    public partial class writeCommentForm : Form
    {
        Movie currentMovie = GlobalData.selectedMovie;
        Movie editedMovie = null;

        public writeCommentForm()
        {
            InitializeComponent();
            commentTextBox.Text = GlobalData.selectedMovie.getComment();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String comment = commentTextBox.Text;

            // Save the comment to global data
            GlobalData.selectedMovie.setComment(comment);
            editedMovie = GlobalData.selectedMovie;

            // Save the movie in xml
            saveToXml();
            
            this.Close();
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
                foreach (XmlNode node in listMovies)
                {
                    // Within a Movie, create a list of its children
                    XmlNodeList listChildren = node.ChildNodes;

                    // Visit each child node
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
    }
}
