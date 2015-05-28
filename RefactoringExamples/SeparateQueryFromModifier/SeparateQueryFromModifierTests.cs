using NUnit.Framework;

namespace RefactoringExamples.SeparateQueryFromModifier
{
    [TestFixture]
    public class SeparateQueryFromModifierTests:ISendAlerts, IMiscreantBlocker
    {
        private SecurityChecker _securityChecker;
        private bool _alertSent;
        private string _blockedMiscreant;

        [SetUp]
        public void SetUp()
        {
            _securityChecker = new SecurityChecker(this, this);

            _alertSent = false;
            _blockedMiscreant = null;
        }

         [Test]
         public void Finds_miscreant_when_Don_is_there()
         {
             _securityChecker.CheckSecurity(new[] { "Dan", "Don", "Den" });

             Assert.That(_blockedMiscreant, Is.EqualTo("Don"));
         }

        [Test]
         public void Sends_alert_when_Don_is_there()
         {
             _securityChecker.CheckSecurity(new[] { "Dan", "Don", "Den" });

             Assert.That(_alertSent, Is.True);
         }

         [Test]
         public void Finds_miscreant_when_John_is_there()
         {
             _securityChecker.CheckSecurity(new[] { "Jan", "John", "Jen" });

             Assert.That(_blockedMiscreant, Is.EqualTo("John"));
         }

        [Test]
         public void Sends_alert_when_John_is_there()
         {
             _securityChecker.CheckSecurity(new[] { "Jan", "John", "Jen" });

             Assert.That(_alertSent, Is.True);
         }

        [Test]
        public void Finds_no_miscreant_amongst_innocent_people()
        {
            _securityChecker.CheckSecurity(new[] { "Dan", "Den", "Jan", "Jen" });

            Assert.That(_blockedMiscreant, Is.EqualTo(""));
        }

        [Test]
        public void Sends_no_alert_for_innocent_people()
        {
            _securityChecker.CheckSecurity(new[] { "Dan", "Den", "Jan", "Jen" });

            Assert.That(_alertSent, Is.False);
        }

        public void SendAlert()
        {
            _alertSent = true;
        }

        public void BlockMiscreant(string miscreant)
        {
            _blockedMiscreant = miscreant;
        }
    }
}