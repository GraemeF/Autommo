using TechTalk.SpecFlow;

namespace Autommo.EndToEndTests.Steps
{
    [Binding]
    public class MobSteps : ServerSteps
    {
        [Given(@"there is a hostile mob")]
        public void GivenThereIsAHostileMob()
        {
            Server.AddMob();
        }
    }
}