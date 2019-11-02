using UselessProject;

namespace Useless.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var constantStringObserver = new ConstantStringObserver(() => StringConstants.WILL_NEVER_CHANGE);
            constantStringObserver.ConstantChanged +=
                (sender, eventArgs) =>
                    System.Console.WriteLine(
                        $"OMG the constant changed from {eventArgs.PreviousValue} to {eventArgs.CurrentValue}!!!!");
            constantStringObserver.StartObserving();
        }
    }
}