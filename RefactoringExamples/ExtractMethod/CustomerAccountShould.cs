 using System.Collections.Generic;
 using NSubstitute;
 using NUnit.Framework;

namespace RefactoringExamples.ExtractMethod
{
    [TestFixture]
    public class CustomerAccountShould
    {
        private const int Amount1 = 2;
        private const int Amount2 = 3;
        private const string CustomerName = "Bloggs";
        private IOutput _output;
        private CustomerAccount _customerAccount;

        [SetUp]
        public void SetUp()
        {
            _output = Substitute.For<IOutput>();
            var orders = new[] {new Order(Amount1), new Order(Amount2)};
            _customerAccount = new CustomerAccount(_output, orders, CustomerName);
        }

        [Test]
        public void Print_current_account()
        {
            _customerAccount.PrintOwing();

            Received.InOrder(() =>
            {
                _output.WriteLine("*************************");
                _output.WriteLine("***** Customer Owes *****");
                _output.WriteLine("*************************");
                _output.WriteLine($"name:{CustomerName}");
                _output.WriteLine($"amount:{(Amount1 + Amount2)}");
            });
        }
    }
}
