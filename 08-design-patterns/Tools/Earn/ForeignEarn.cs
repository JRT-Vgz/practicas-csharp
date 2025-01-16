
namespace Tools.Earn
{
    public class ForeignEarn : IEarn
    {
        private decimal _percentage;
        private decimal _extra;
        public ForeignEarn(decimal percentage, decimal extra)
        {
            _percentage = percentage;
            _extra = extra;
        }

        public decimal Earn(decimal amount)
        {
            return (amount * _percentage) + _extra;
        }
    }
}
