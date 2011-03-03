namespace Autommo.EndToEndTests
{
    #region Using Directives

    using Autommo.EndToEndTestEntities;

    using TechTalk.SpecFlow;

    #endregion

    [Binding]
    public class EventDefinitions
    {
        [AfterScenario]
        public void AfterScenario()
        {
            ScenarioContext.Current.Get<AutommoServer>("Server").Dispose();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ScenarioContext.Current.Add("Server", new AutommoServer());
        }
    }
}