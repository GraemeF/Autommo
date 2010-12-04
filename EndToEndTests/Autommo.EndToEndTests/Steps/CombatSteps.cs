using TechTalk.SpecFlow;

namespace Autommo.EndToEndTests.Steps
{
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