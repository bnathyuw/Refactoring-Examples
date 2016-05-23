namespace RefactoringExamples.IntroduceExplainingVariable
{
    public class UserInterface
    {
        private readonly ICollaborator _collaborator;
        private bool _initialised;

        public UserInterface(ICollaborator collaborator)
        {
            _collaborator = collaborator;
            _initialised = false;
        }

        public void Initialise()
        {
            _initialised = true;
        }

        public void React(string platform, string browser, int resize)
        {
            if ((platform.ToUpper().IndexOf("MAC") > -1) && (browser.ToUpper().IndexOf("IE") > -1) && WasInitialised() &&
                resize > 0)
            {
                DoSomething();
            }
        }

        private bool WasInitialised()
        {
            return _initialised;
        }

        private void DoSomething()
        {
            _collaborator.DoSomething();
        }
    }

    public interface ICollaborator
    {
        void DoSomething();
    }
}