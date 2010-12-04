using TechTalk.SpecFlow;

namespace Autommo.EndToEndTests.Steps
{
    [Binding]
    public class MovementSteps
    {
        [When(@"I move my character next to the mob")]
        public void WhenIMoveMyCharacterNextToTheMob()
        {
            ScenarioContext.Current.Pending();
        }
    }
}