
namespace Tools.Earn
{
    public class LocalEarnFactory : IEarnFactory
    {
        private decimal _percentage;
        public LocalEarnFactory(decimal percentage)
        {
            _percentage = percentage;
        }

        public IEarn GetEarn()
        {
            return new LocalEarn(_percentage);
        }
    }
}
