using System;
using System.Threading;
using Autommo.Dto;
using Should.Fluent;
using TechTalk.SpecFlow;

namespace Autommo.EndToEndTests.Steps
{
    [Binding]
    public class MovementSteps : ServerSteps
    {
        [When(@"I move my character next to the mob")]
        public void WhenIMoveMyCharacterNextToTheMob()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am positioned at (\d+),(\d+),(\d+)")]
        public void GivenIAmPositionedAt(decimal x, decimal y, decimal z)
        {
        }

        [Then(@"I should be positioned at (\d+),(\d+),(\d+)")]
        public void ThenIShouldBePositionedAt(decimal x, decimal y, decimal z)
        {
            Server.GetCharacter().Location.Position.Should().Equal(new WorldPoint() {X = x, Y = y, Z = z});
        }

        [When(@"I move to (\d+),(\d+),(\d+)")]
        public void WhenIMoveTo(decimal x, decimal y, decimal z)
        {
            Server.Move(new WorldPoint
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