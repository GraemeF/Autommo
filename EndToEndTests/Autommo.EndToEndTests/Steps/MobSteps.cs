namespace Autommo.EndToEndTests.Steps
{
    #region Using Directives

    using TechTalk.SpecFlow;

    #endregion

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