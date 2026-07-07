namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double lowGrade;
        public double highGrade;

        public char LetterGrade
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';
                    case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;

            lowGrade = Math.Min(number, lowGrade);
            highGrade = Math.Max(number, highGrade);
        }

        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            highGrade = double.MinValue;
            lowGrade = double.MaxValue;
        }
    }
}