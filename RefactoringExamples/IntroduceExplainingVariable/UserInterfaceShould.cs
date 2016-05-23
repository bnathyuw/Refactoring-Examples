using NSubstitute;
using NUnit.Framework;

namespace RefactoringExamples.IntroduceExplainingVariable
{
    [TestFixture]
    public class UserInterfaceShould
    {
        private const string MacPlatform = "MAC";
        private const string IeBrowser = "IE";
        private const int SlightlyEnlarged = 1;
        private ICollaborator _collaborator;
        private UserInterface _userInterface;

        [SetUp]
        public void SetUp()
        {
            _collaborator = Substitute.For<ICollaborator>();
            _userInterface = new UserInterface(_collaborator);
        }

        [Test]
        public void Do_something_when_using_initialised_ie_on_mac_and_enlarged(
            [Values("I am on a mac computer", "I am on a MAC computer", "mac", MacPlatform, "Mac")] string platform,
            [Values("I am using ie to browse", "I am using IE to browse", "ie", IeBrowser, "iE")] string browser,
            [Values(SlightlyEnlarged, 2, 5, 100)] int resize)
        {
            _userInterface.Initialise();

            _userInterface.React(platform, browser, resize);

            _collaborator.Received().DoSomething();
        }

        [Test]
        public void Not_do_something_when_not_initialised()
        {
            _userInterface.React(MacPlatform, IeBrowser, SlightlyEnlarged);

            _collaborator.DidNotReceive().DoSomething();
        }

        [Test]
        public void Not_do_something_when_not_on_mac()
        {
            _userInterface.Initialise();

            _userInterface.React("WINDOWS", IeBrowser, SlightlyEnlarged);

            _collaborator.DidNotReceive().DoSomething();
        }

        [Test]
        public void Not_do_something_when_not_on_ie()
        {
            _userInterface.Initialise();

            _userInterface.React(MacPlatform, "chrome", SlightlyEnlarged);

            _collaborator.DidNotReceive().DoSomething();
        }


        [Test]
        public void Not_do_something_when_resized_smaller(
            [Values(0, -1, -2, -5, -100)] int resize)
        {
            _userInterface.Initialise();

            _userInterface.React(MacPlatform, "chrome", resize);

            _collaborator.DidNotReceive().DoSomething();
        }

    }
}