using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace A3V1
{
    class XmlParser
    {
        public string fileName = GlobalData.fileName;

        public void readData()
        {
            String currentElement = "";
            String currentWord = "";
            Movie currentMovie = null;
            int count = 0;

            if (File.Exists(fileName))                              // If the file exsists, read the file
            {
                using (XmlTextReader reader = new XmlTextReader(fileName))  // Create the reader to parse the XML file
                {
                    while (reader.Read())                           // While not at EOF yet
                    {
                        count = GlobalData.movieList.Count();
                        if (reader.IsStartElement())                // If the current node is the start element, "movie"
                        {
                            currentElement = reader.Name.ToString();
                            switch (currentElement)         // Find out what is the attribute name
                            {
                                case "movie":
                                    currentMovie = new Movie();       // Create a Movie object
                                    break;
                                case "title":
                                    currentWord = reader.ReadString();
                                    currentMovie.setTitle(currentWord);
                                    break;
                                case "year":
                                    currentWord = reader.ReadString();
                                    currentMovie.setYear(Convert.ToInt16(currentWord));
                                    break;
                                case "length":
                                    currentWord = reader.ReadString();
                                    currentMovie.setLength(strToMinutes(currentWord));
                                    break;
                                case "certification":
                                    currentWord = reader.ReadString();
                                    currentMovie.setCertification(currentWord);
                                    break;
                                case "director":
                                    currentWord = reader.ReadString();
                                    currentMovie.setDirector(currentWord);
                                    break;
                                case "rating":
                                    currentWord = reader.ReadString();
                                    currentMovie.setRating(Convert.ToInt16(currentWord));
                                    break;
                                case "genre":
                                    currentWord = reader.ReadString();
                                    currentMovie.addGenre(currentWord);
                                    break;
                                case "actor":
                                    currentWord = reader.ReadString();
                                    currentMovie.addActor(currentWord);
                                    break;
                                case "comment":
                                    currentWord = reader.ReadString();
                                    currentMovie.setComment(currentWord);
                                    break;
                                case "user_rating":
                                    currentWord = reader.ReadString();
                                    currentMovie.setUserRating(Convert.ToInt16(currentWord));
                                    break;
                            }
                        }// if (reader.IsStartElement())
                        else
                        {
                            // If we are now reading the </movie> end tag

                            currentElement = reader.Name.ToString();
                            if (String.Compare(currentElement, "movie") == 0)
                            {
                                if (currentMovie.getYear() >= 1940)
                                    GlobalData.movieList.Add(currentMovie);
                            }
                        }
                    }
                }
            }         
        }

        private short strToMinutes(String line)
        {
            short minutes = 0;
            char[] delimiterChars = { ' ' };
            string[] words = line.Split(delimiterChars);
            minutes = Convert.ToInt16(words[0]);

            return minutes;
        }
    }
}
