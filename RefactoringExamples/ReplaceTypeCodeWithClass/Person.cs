namespace RefactoringExamples.ReplaceTypeCodeWithClass
{
    public class Person
    {
        public const int O = 0;
        public const int A = 1;
        public const int B = 2;
        public const int AB = 3;

        private int _bloodGroup;

        public Person(int bloodGroup)
        {
            _bloodGroup = bloodGroup;
        }

        public int BloodGroup
        {
            get { return _bloodGroup; }
            set { _bloodGroup = value; }
        }
    }
}