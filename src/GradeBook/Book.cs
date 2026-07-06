using Microsoft.VisualBasic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        private string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double newGrade)
        {
            grades.Add(newGrade);
        }

        public Statistics GetStatistics()
        {
            var res = new Statistics();
            res.Average = 0.0;
            res.highGrade = double.MinValue;
            res.lowGrade = double.MaxValue;

            foreach(var number in grades)
            {
                if(number > res.highGrade)
                {
                    res.highGrade = number;
                }

                res.lowGrade = Math.Min(number, res.lowGrade);

                res.Average += number;
            }

            res.Average /= grades.Count;

            return res;
        }
    }
}