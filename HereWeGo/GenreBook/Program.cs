// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

public class BookManager
{
    private Dictionary<string, SortedDictionary<BookKey, string>> genreToBooks;
    private Dictionary<string, (string Genre, double Rating)> bookToGenreAndRating;

    public BookManager(string[] books, string[] genres, double[] ratings)
    {
        genreToBooks = new Dictionary<string, SortedDictionary<BookKey, string>>();
        bookToGenreAndRating = new Dictionary<string, (string Genre, double Rating)>();

        for (int i = 0; i < books.Length; i++)
        {
            string book = books[i];
            string genre = genres[i];
            double rating = ratings[i];

            if (!genreToBooks.ContainsKey(genre))
            {
                genreToBooks[genre] = new SortedDictionary<BookKey, string>();
            }

            var bookKey = new BookKey(rating, book);
            genreToBooks[genre][bookKey] = book;
            bookToGenreAndRating[book] = (genre, rating);
        }
    }

    public string GetHighestRatingBookByGenre(string genreName)
    {
        if (genreToBooks.ContainsKey(genreName) && genreToBooks[genreName].Count > 0)
        {
            var highestRatedBookKey = genreToBooks[genreName].Keys.First();
            return genreToBooks[genreName][highestRatedBookKey];
        }
        return null;
    }

    public void UpdateBookRatingByBookName(string bookName, double newRating)
    {
        if (bookToGenreAndRating.ContainsKey(bookName))
        {
            var (genre, oldRating) = bookToGenreAndRating[bookName];
            var oldBookKey = new BookKey(oldRating, bookName);
            var newBookKey = new BookKey(newRating, bookName);

            // Remove the old entry and add the new entry in the sorted dictionary
            genreToBooks[genre].Remove(oldBookKey);
            genreToBooks[genre][newBookKey] = bookName;

            // Update the rating in the bookToGenreAndRating dictionary
            bookToGenreAndRating[bookName] = (genre, newRating);

            Console.WriteLine($"Rating of '{bookName}' updated to {newRating}");
        }
        else
        {
            Console.WriteLine($"'{bookName}' not found in the book list");
        }
    }

    private class BookKey : System.IComparable<BookKey>
    {
        public double Rating { get; }
        public string Name { get; }

        public BookKey(double rating, string name)
        {
            Rating = rating;
            Name = name;
        }

        public int CompareTo(BookKey other)
        {
            // First compare by rating in descending order
            int ratingComparison = other.Rating.CompareTo(Rating);
            if (ratingComparison == 0)
            {
                // If ratings are equal, compare by name in ascending order
                return string.Compare(Name, other.Name, StringComparison.Ordinal);
            }
            return ratingComparison;
        }
    }

    public static void Main(string[] args)
    {
        string[] books = { "Book A", "Book B", "Book C", "Book D", "Book E" };
        string[] genres = { "Fiction", "Fantasy", "Fiction", "Fantasy", "Non-Fiction" };
        double[] ratings = { 4.5, 4.0, 4.8, 4.2, 3.9 };

        BookManager manager = new BookManager(books, genres, ratings);

        // Find the highest rated book in the "Fantasy" genre
        string highestRatedFantasy = manager.GetHighestRatingBookByGenre("Fantasy");
        Console.WriteLine($"Highest rated book in Fantasy genre: {highestRatedFantasy}");

        // Update the rating of "Book B"
        manager.UpdateBookRatingByBookName("Book B", 4.2);

        // Find the highest rated book in the "Fantasy" genre again
        string updatedHighestRatedFantasy = manager.GetHighestRatingBookByGenre("Fantasy");
        Console.WriteLine($"Updated highest rated book in Fantasy genre: {updatedHighestRatedFantasy}");
    }
}
