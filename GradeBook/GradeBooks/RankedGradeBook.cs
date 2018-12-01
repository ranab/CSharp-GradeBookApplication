﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            var threshold = (int)Math.Ceiling(Students.Count * .2);

            var grades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(threshold * 4) - 1] <= averageGrade)
                return 'D';
            else if (grades[(threshold * 5) - 1] <= averageGrade)
                return 'E';
            else
                return 'F';
            
        }

        private void GetPerOfStudentsWithGradeGreaterThan(char g)
        {
            var higherGradeStudents = this.Students.Where(s => s.LetterGrade < g).Count();
            decimal highPerStudents = higherGradeStudents / Students.Count;

            
                    

              
        }
    }
}
