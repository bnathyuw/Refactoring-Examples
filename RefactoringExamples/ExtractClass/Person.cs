namespace RefactoringExamples.ExtractClass
{
    public class Person
    {
        private readonly string _name;
        private string _officeAreaCode;
        private string _officeNumber;

        public Person(string name, string officeAreaCode, string officeNumber)
        {
            _name = name;
            OfficeAreaCode = officeAreaCode;
            OfficeNumber = officeNumber;
        }

        public string Name { get { return _name; } }
        public string TelephoneNumber { get { return "(" + _officeAreaCode + ") " + _officeNumber; } }

        private string OfficeAreaCode
        {
            get { return _officeAreaCode; }
            set { _officeAreaCode = value; }
        }

        string OfficeNumber
        {
            get { return _officeNumber; }
            set { _officeNumber = value; }
        }
    }
}