using System.Collections.Generic;

namespace RefactoringExamples.SeparateQueryFromModifier
{
    public class MiscreantFinder
    {
        private readonly ISendAlerts _alertSender;

        public MiscreantFinder(ISendAlerts alertSender)
        {
            _alertSender = alertSender;
        }

        public string FoundMiscreant(IEnumerable<string> people)
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
}