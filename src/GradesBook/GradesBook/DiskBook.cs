using System;
using System.IO;

namespace GradesBook
{
    internal class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using (StreamWriter theFile = File.AppendText($"{Name}.txt"))
                {
                    theFile.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var theFile = File.OpenText($"{Name}.txt"))
            {
                while (!theFile.EndOfStream)
                {
                    result.Add(double.Parse(theFile.ReadLine()));
                }
            }
            return result;
        }
    }
}