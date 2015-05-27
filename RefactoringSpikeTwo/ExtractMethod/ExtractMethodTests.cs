 using System.Collections.Generic;
 using System.IO;
 using System.Text;
 using NUnit.Framework;

namespace RefactoringSpikeTwo.ExtractMethod
{
    [TestFixture]
    public class ExtractMethodTests:IOutput
    {
        private StringBuilder _sb;

        [Test]
        public void Prints_correct_output()
        {
            _sb = new StringBuilder();

            var subject = new ExtractMethodSut(this, new List<Order>
            {
                new Order(2),
                new Order(3)
            }, "Bloggs");

            subject.PrintOwing();

            var actual = _sb.ToString();
            var expected = File.ReadAllText("ExtractMethod/extract_method_output.txt");
            Assert.That(actual, Is.EqualTo(expected));
        }

        public void WriteLine(string output)
        {
            _sb.AppendLine(output);
        }
    }
}
