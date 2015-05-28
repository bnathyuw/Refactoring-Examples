using System.Collections.Generic;

namespace RefactoringExamples.SeparateQueryFromModifier
{
    public class SecurityChecker
    {
        private readonly ISendAlerts _alertSender;
        private readonly IMiscreantBlocker _miscreantBlocker;

        public SecurityChecker(ISendAlerts alertSender, IMiscreantBlocker miscreantBlocker)
        {
            _alertSender = alertSender;
            _miscreantBlocker = miscreantBlocker;
        }

        public void CheckSecurity(IEnumerable<string> people)
        {
            var found = FoundMiscreant(people);
            _miscreantBlocker.BlockMiscreant(found);
        }

        private string FoundMiscreant(IEnumerable<string> people)
        {
            foreach (var person in people)
            {
                if (person == "Don")
                {
                    SendAlert();
                    return "Don";
                }
                if (person == "John")
                {
                    SendAlert();
                    return "John";
                }
            }
            return "";
        }

        private void SendAlert()
        {
            _alertSender.SendAlert();
        }
    }

    public interface IMiscreantBlocker
    {
        void BlockMiscreant(string miscreant);
    }
}