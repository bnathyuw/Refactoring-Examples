using NUnit.Framework;

namespace RefactoringExamples.SeparateQueryFromModifier
{
    [TestFixture]
    public class SeparateQueryFromModifierTests:ISendAlerts
    {
        private MiscreantFinder _miscreantFinder;
        private bool _alertSent;

        [SetUp]
        public void SetUp()
        {
            _miscreantFinder = new MiscreantFinder(this);

            _alertSent = false;
        }

         [Test]
         public void Finds_miscreant_when_Don_is_there()
         {
             var actual = _miscreantFinder.FoundMiscreant(new[] { "Dan", "Don", "Den" });

             Assert.That(actual, Is.EqualTo("Don"));             
         }

         [Test]
         public void Sends_alert_when_Don_is_there()
         {
             _miscreantFinder.FoundMiscreant(new[] { "Dan", "Don", "Den" });

             Assert.That(_alertSent, Is.True);
         }

         [Test]
         public void Finds_miscreant_when_John_is_there()
         {
             var actual = _miscreantFinder.FoundMiscreant(new[] { "Jan", "John", "Jen" });

             Assert.That(actual, Is.EqualTo("John"));
         }

         [Test]
         public void Sends_alert_when_John_is_there()
         {
             _miscreantFinder.FoundMiscreant(new[] { "Jan", "John", "Jen" });

             Assert.That(_alertSent, Is.True);
         }

        [Test]
        public void Finds_no_miscreant_amongst_innocent_people()
        {
            var actual = _miscreantFinder.FoundMiscreant(new[] {"Dan", "Den", "Jan", "Jen"});

            Assert.That(actual, Is.EqualTo(""));
        }

        [Test]
        public void Sends_no_alert_for_innocent_people()
        {
            _miscreantFinder.FoundMiscreant(new[] { "Dan", "Den", "Jan", "Jen" });

            Assert.That(_alertSent, Is.False);
        }

        public void SendAlert()
        {
            _alertSent = true;
        }
    }
}