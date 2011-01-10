using TechTalk.SpecFlow;
using Autommo.Dto;

namespace Autommo.EndToEndTests.Steps
{
    [Binding]
    public class MovementSteps:ServerSteps
    {
        [When(@"I move my character next to the mob")]
        public void WhenIMoveMyCharacterNextToTheMob()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am positioned at (\d+),(\d+),(\d+)")]
        public void GivenIAmPositionedAt(decimal x, decimal y, decimal z)
        {
            Server.Move(new WorldPoint{
                X=x,Y= y,Z= z});
        }

        [Then(@"I should be positioned at 10,0,0")]
        public void ThenIShouldBePositionedAt1000()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I move to 10,0,0")]
        public void WhenIMoveTo1000()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I wait for 2 seconds")]
        public void WhenIWaitFor2Seconds()
        {
            ScenarioContext.Current.Pending();
        }
    }
}