using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3V1
{
    public class Movie
    {
        // Class variables
        String title;
        short year;
        short length;           // In minutes
        String certification;
        String director;
        short rating;
        List<String> genres;
        List<String> actors;
        String comment;
        short userRating;

        // Constructor
        public Movie(String title, short year, short length, String certification, String director,
            short rating, List<String> genres, List<String> actors, String comment, short userRating)
        {
            this.title = title;
            this.year = year;
            this.length = length;
            this.certification = certification;
            this.director = director;
            this.rating = rating;
            this.genres = genres;
            this.actors = actors;
            this.comment = comment;
            this.userRating = userRating;
        }

        public Movie(String title, short year, short length, String certification, String director,
            short rating, List<String> genres, List<String> actors)
        {
            this.title = title;
            this.year = year;
            this.length = length;
            this.certification = certification;
            this.director = director;
            this.rating = rating;
            this.genres = genres;
            this.actors = actors;
            this.comment = "";
            this.userRating = -1;
        }

        public Movie()
        {
            this.title = null;
            this.year = -1;
            this.length = -1;
            this.certification = null;
            this.director = null;
            this.rating = -1;
            this.genres = new List<string>();
            this.actors = new List<String>();
            this.comment = "";
            this.userRating = -1;
        }

        // Class methods
        public String getTitle()
        {
            return title;
        }

        public void setTitle(String title)
        {
            this.title = title;
        }

        public short getYear()
        {
            return year;
        }

        public void setYear(short year)
        {
            this.year = year;
        }

        public short getLength()
        {
            return length;
        }

        public void setLength(short length)
        {
            this.length = length;
        }

        public void setGenres(List<String> genres)
        {
            this.genres = genres;
        }

        public void setActors(List<String> actors)
        {
            this.actors = actors;
        }

        public String getCertifacation()
        {
            return certification;
        }

        public void setCertification(String certification)
        {
            this.certification = certification;
        }

        public String getDirector()
        {
            return director;
        }

        public void setDirector(String director)
        {
            this.director = director;
        }

        public short getRating()
        {
            return rating;
        }

        public void setRating(short rating)
        {
            this.rating = rating;
        }

        public List<String> getGenres()
        {
            return genres;
        }

        public void addGenre(String genre)
        {
            this.genres.Add(genre);
        }

        public List<String> getActors()
        {
            return actors;
        }

        public void addActor(String actor)
        {
            this.actors.Add(actor);
        }

        public String getComment()
        {
            return comment;
        }

        public void setComment(String comment)
        {
            this.comment = comment;
        }

        public int getUserRating()
        {
            return userRating;
        }

        public void setUserRating(short userRating)
        {
            this.userRating = userRating;
        }
    }
}
