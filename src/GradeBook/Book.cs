using Microsoft.VisualBasic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double newGrade)
        {
            if(newGrade <= 100 && newGrade >= 0)
            {
                grades.Add(newGrade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(newGrade)}");
            }

        }

        public void AddLetter(char grade)
        {
            switch (grade)
            {
                case 'A':
                    grades.Add(90);
                    break;
                case 'B':
                    grades.Add(80);
                    break;
                case 'C':
                    grades.Add(70);
                    break;
                default:
                    grades.Add(0);
                    break;
            }
        }

        public Statistics GetStatistics()
        {
            var res = new Statistics();
            res.Average = 0.0;
            res.highGrade = double.MinValue;
            res.lowGrade = double.MaxValue;

            var index = 0;
            do
            {
                if(grades[index] > res.highGrade)
                {
                    res.highGrade = grades[index];
                }

                res.lowGrade = Math.Min(grades[index], res.lowGrade);

                res.Average += grades[index];

                index += 1;
            }while(index < grades.Count);

            res.Average /= grades.Count;

            switch (res.Average)
            {
                case var d when d >= 90:
                    res.LetterGrade = 'A';
                    break;
                case var d when d >= 80:
                    res.LetterGrade = 'B';
                    break;
                case var d when d >= 70:
                    res.LetterGrade = 'C';
                    break;
                case var d when d >= 60:
                    res.LetterGrade = 'D';
                    break;
                default:
                    res.LetterGrade = 'F';
                    break;
            }

            return res;
        }

        public List<Double> getGrades()
        {
            return grades;
        }
    }
}