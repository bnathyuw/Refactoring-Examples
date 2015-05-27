namespace RefactoringSpikeTwo.ExtractMethod
{
    public class Order
    {
        public Order(double amount)
        {
            Amount = amount;
        }

        public double Amount { get; private set; }
    }
}