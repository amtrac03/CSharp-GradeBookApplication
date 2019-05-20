using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int above=0;
            int below =0;
            foreach (var student in Students)
            {
                if (averageGrade > student.AverageGrade)
                {
                    above++;
                }
                else
                {
                    below++;
                }
            }
            Console.WriteLine("above: " + above + " below: " + below);
            if ((double)above / (double)(above + below) <= 0.2)
            {
                return 'A';
            }else if ((double)above / (double)(above + below) <= 0.4)
            {
                return 'B';
            }
            else if ((double)above / (double)(above + below) <= 0.6)
            {
                return 'C';
            }
            else if ((double)above / (double)(above + below) <= 0.8)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
