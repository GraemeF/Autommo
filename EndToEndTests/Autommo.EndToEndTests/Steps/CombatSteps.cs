namespace Autommo.EndToEndTests.Steps
{
    #region Using Directives

    using TechTalk.SpecFlow;

    #endregion

    [Binding]
    public class CombatSteps
    {
        [Then(@"combat should begin")]
        public void ThenCombatShouldBegin()
        {
            ScenarioContext.Current.Pending();
        }
    }
}