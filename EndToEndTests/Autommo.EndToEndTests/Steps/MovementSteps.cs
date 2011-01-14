namespace Autommo.EndToEndTests.Steps
{
    using System;
    using System.Threading;

    using Autommo.Dto;

    using Should.Fluent;

    using TechTalk.SpecFlow;

    [Binding]
    public class MovementSteps : ServerSteps
    {
        [Given(@"I am positioned at (\d+),(\d+),(\d+)")]
        public void GivenIAmPositionedAt(decimal x, decimal y, decimal z)
        {
        }

        [Then(@"I should be positioned at (\d+),(\d+),(\d+)")]
        public void ThenIShouldBePositionedAt(decimal x, decimal y, decimal z)
        {
            Server.GetCharacter().Position.Location.BaseCentre.Should().Equal(new Point
                                                                       {
                                                                           X = x,
                                                                           Y = y,
                                                                           Z = z
                                                                       });
        }

        [When(@"I move my character next to the mob")]
        public void WhenIMoveMyCharacterNextToTheMob()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I move to (\d+),(\d+),(\d+)")]
        public void WhenIMoveTo(decimal x, decimal y, decimal z)
        {
            Server.Move(new Point
                            {
                                X = x,
                                Y = y,
                                Z = z
                            });
        }

        [When(@"I wait for (\d+) seconds")]
        public void WhenIWaitForSeconds(double seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}