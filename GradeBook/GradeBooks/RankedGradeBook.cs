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
                throw new InvalidOperationException("A minimum of 5 students is required for ranked grading to work.");

            var gradeThreshold = (int)Math.Ceiling(Students.Count * 0.2);
            var gradesList = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            if (gradesList[gradeThreshold - 1] <= averageGrade)
                return 'A';
            else if (gradesList[(gradeThreshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (gradesList[(gradeThreshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (gradesList[(gradeThreshold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
