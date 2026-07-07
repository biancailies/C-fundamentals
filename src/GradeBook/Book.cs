using Microsoft.VisualBasic;

namespace GradeBook
{
    public delegate void GradeAddDelegate(Object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get; set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        String Name{get;}
        event GradeAddDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public virtual event GradeAddDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
    public class InMemoryBook : Book
    {
        private List<double> grades;
        public const string CATEGORY = "Science";


        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double newGrade)
        {
            if(newGrade <= 100 && newGrade >= 0)
            {
                grades.Add(newGrade);

                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
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

        public override event GradeAddDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var res = new Statistics();

            var index = 0;
            do
            {

                res.Add(grades[index]);

                index += 1;
            }while(index < grades.Count);

            return res;
        }

        public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);

                    if(GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
        }

        public override Statistics GetStatistics()
        {

            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
                {
                    var line = reader.ReadLine();

                    while(line != null)
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }

                }

            return result;
        }
    }

        public List<Double> getGrades()
        {
            return grades;
        }
    }
}