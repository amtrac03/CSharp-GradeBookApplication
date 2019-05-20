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
            int above = 0;
            foreach (var student in Students)
            {
                if (averageGrade > student.AverageGrade)
                {
                    above++;
                }
            }
            if (above / (double)Students.Count < 0.2)
            {
                return 'A';
            }else if (above / (double)Students.Count < 0.4)
            {
                return 'B';
            }
            else if (above / (double)Students.Count < 0.6)
            {
                return 'C';
            }
            else if (above / (double)Students.Count < 0.8)
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
