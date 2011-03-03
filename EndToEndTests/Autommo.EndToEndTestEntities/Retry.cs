namespace Autommo.EndToEndTestEntities
{
    using System;
    using System.Threading;

    public static class Retry
    {
        public static void Until(Func<bool> test, string failMessage)
        {
            for (int remainingTries = 50; remainingTries >= 0; remainingTries--)
            {
                if (remainingTries == 0)
                    throw new TimeoutException(failMessage);

                Thread.Sleep(500);

                if (test())
                    return;
            }
        }
    }
}