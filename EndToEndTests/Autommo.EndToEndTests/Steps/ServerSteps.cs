namespace Autommo.EndToEndTests.Steps
{
    #region Using Directives

    using Autommo.EndToEndTestEntities;

    using TechTalk.SpecFlow;

    #endregion

    [Binding]
    public class ServerSteps
    {
        protected static AutommoServer Server
        {
            get { return ScenarioContext.Current.Get<AutommoServer>("Server"); }
        }
    }
}