using System;

namespace GradesBook
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var book = new DiskBook("a book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            Statistics stats = book.GetStatistics();

            Console.WriteLine($"The name of the book is {book.Name}\n" +
                              $" the min val is {stats.Low}\n," +
                              $" and the max val is {stats.High},\n" +
                              $" and the average is {stats.Average:N2}\n" +
                              $" and the letter is {stats.Letter}\n");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    double grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}