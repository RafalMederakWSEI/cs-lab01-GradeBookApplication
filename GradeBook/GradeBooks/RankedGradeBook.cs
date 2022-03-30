using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int studentsHigherThanInputAverage = 0;
            int numberOfStudents = Students.Count;

            if(numberOfStudents < 5)
            {
                throw new InvalidOperationException();
            }

            foreach(var student in Students)
            {
                if(student.AverageGrade >= averageGrade)
                {
                    studentsHigherThanInputAverage++;
                }
            }

            if (studentsHigherThanInputAverage <= numberOfStudents * 0.2) return 'A';
            else if (studentsHigherThanInputAverage <= numberOfStudents * 0.4) return 'B';
            else if (studentsHigherThanInputAverage <= numberOfStudents * 0.6) return 'C';
            else if (studentsHigherThanInputAverage <= numberOfStudents * 0.8) return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5) Console.Write("Ranked grading requires at least 5 students.");
            else if(Students.Count >= 5) base.CalculateStatistics();
        }

    }
}
