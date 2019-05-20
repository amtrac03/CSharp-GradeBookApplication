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

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if(grades[threshold-1] <= averageGrade)
            {
                return 'A';
            }else if(grades[threshold*2-1] <= averageGrade)
            {
                return 'B';
            }else if(grades[threshold * 3 - 1] <= averageGrade)
            {
                return 'C';
            }else if(grades[threshold * 4 - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
            //int above = 0;
            //foreach (var student in Students)
            //{
            //    if (averageGrade > student.AverageGrade)
            //    {
            //        above++;
            //    }
            //}
            //if (above / (double)Students.Count < 0.2)
            //{
            //    return 'A';
            //}else if (above / (double)Students.Count < 0.4)
            //{
            //    return 'B';
            //}
            //else if (above / (double)Students.Count < 0.6)
            //{
            //    return 'C';
            //}
            //else if (above / (double)Students.Count < 0.8)
            //{
            //    return 'D';
            //}
            //else
            //{
            //    return 'F';
            //}
        }
    }
}
