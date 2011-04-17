namespace Autommo.EndToEndTests
{
    #region Using Directives

    using System;
    using System.Threading;

    using Autommo.Dto;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Should.Fluent;

    using StoryQ;

    #endregion

    [TestClass]
    public class Movement : ServerTestBase
    {
        private readonly Feature _feature = new Story("Movement")
            .InOrderTo("interact with the world")
            .AsA("bot")
            .IWant("to move around it");

        [TestMethod]
        public void MoveToALocation()
        {
            _feature
                .WithScenario("Move to a location")
                .Given(IAmPositionedAt___, 0m, 0m, 0m)
                .When(WhenIMoveTo___, 10m, 0m, 0m)
                .And(IWaitFor_Seconds, 2.0)
                .Then(IShouldBePositionedAt___, 10m, 0m, 0m)
                .Execute();
        }

        [TestMethod]
        public void TrackMovementProgress()
        {
            _feature
                .WithScenario("Track movement progress")
                .Given(IAmPositionedAt___, 0m, 0m, 0m)
                .When(WhenIMoveTo___, 100m, 0m, 0m)
                .Then(IShouldBeMoving)
                .Execute();
        }

        private void IAmPositionedAt___(decimal x, decimal y, decimal z)
        {
            throw new NotImplementedException();
        }

        private void IShouldBeMoving()
        {
            throw new NotImplementedException();
        }

        private void IShouldBePositionedAt___(decimal x, decimal y, decimal z)
        {
            Server.GetCharacter().Position.Location.BaseCentre.
                Should().Equal(new Point
                                   {
                                       X = x,
                                       Y = y,
                                       Z = z
                                   });
        }

        private void IWaitFor_Seconds(double seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        private void WhenIMoveTo___(decimal x, decimal y, decimal z)
        {
            Server.Move(new Point
                            {
                                X = x,
                                Y = y,
                                Z = z
                            });
        }
    }
}