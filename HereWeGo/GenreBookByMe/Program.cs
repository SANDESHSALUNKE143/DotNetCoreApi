// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

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

class BookManager
{
    private Dictionary<string, SortedDictionary<BookKey, string>> generToBook;
    private Dictionary<string, (string, double)> bookToGenreAndRating;
    public BookManager(string[] books, string[] genres, double[] ratings)
    {
        generToBook = new Dictionary<string, SortedDictionary<BookKey, string>>();
        bookToGenreAndRating = new Dictionary<string, (string, double)>();
        
        for (int i = 0; i < books.Length; i++)
        {
            string bookName = books[i];
            string genre = genres[i];
            double rating = ratings[i];

            BookKey bookKey = new BookKey(bookName, rating);

            if (!generToBook.ContainsKey(genre))
            {
                generToBook.Add(genre, new SortedDictionary<BookKey, string>());
            }

            generToBook[genre][bookKey] = bookName;
            bookToGenreAndRating[bookName] = (genre, rating);
        }
        
    }
    
    public string GetHighestRatingBookByGenre(string genreName)
    {
        if (generToBook.ContainsKey(genreName) && generToBook[genreName].Count() > 0)
        {
            return generToBook[genreName].First().Value;
        }

        return null;
    }

    public void UpdateBookRatingByBookName(string bookName, double newRating)
    {
        if (bookToGenreAndRating.ContainsKey(bookName))
        {
            (string genreName, double oldRating) = bookToGenreAndRating[bookName];

            BookKey oldKey = new BookKey(bookName, oldRating);
            generToBook[genreName].Remove(oldKey);
            BookKey newKey = new BookKey(bookName, newRating);

            generToBook[genreName][newKey] = bookName;
            bookToGenreAndRating[bookName] = (genreName, newRating);
        }
    }
}

class BookKey:IComparable<BookKey>
{
    public string BookName { get; set; }
    public  double Rating { get; set; }

    public BookKey(string bookName, double ratings)
    {
        BookName = bookName;
        Rating = ratings;
    }

    public int CompareTo(BookKey other)
    {
        if (other.Rating.CompareTo(Rating) == 0)
        {
            return string.Compare(BookName, other.BookName, StringComparison.Ordinal);
        }

        return other.Rating.CompareTo(Rating);
    }
}

