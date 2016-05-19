using System.Collections.Generic;

namespace RefactoringExamples.ExtractMethod
{
    public class CustomerAccount
    {
        private readonly IOutput _output;
        private readonly IEnumerable<Order> _orders;
        private readonly string _name;

        public CustomerAccount(IOutput output, IEnumerable<Order> orders, string name)
        {
            _output = output;
            _orders = orders;
            _name = name;
        }

        public void PrintOwing()
        {
            var outstanding = 0.0;

            // print banner
            _output.WriteLine("*************************");
            _output.WriteLine("***** Customer Owes *****");
            _output.WriteLine("*************************");

            // calculate outstanding
            foreach (var order in _orders)
            {
                outstanding += order.Amount;
            }

            // print details
            _output.WriteLine("name:"  + _name);
            _output.WriteLine("amount:" + outstanding);
        }
    }
}