using TechTalk.SpecFlow;

namespace Autommo.EndToEndTests.Steps
{
    [Binding]
    public class MobSteps
    {
        [Given(@"there is a hostile mob")]
        public void GivenThereIsAHostileMob()
        {
            ScenarioContext.Current.Pending();
        }
    }
}