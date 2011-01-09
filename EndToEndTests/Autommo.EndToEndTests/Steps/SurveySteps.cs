namespace Autommo.EndToEndTests.Steps
{
    using Autommo.Dto;

    using Should.Fluent;

    using TechTalk.SpecFlow;

    [Binding]
    public class SurveySteps : ServerSteps
    {
        [Then(@"there should be a mob in the neighbourhood")]
        public void ThereShouldBeAMobInTheNeighbourhood()
        {
            ScenarioContext.Current.Get<Neighbourhood>("Neighbourhood").
                Mobs.Should().Count.AtLeast(1);
        }

        [When(@"I ask what is near my character")]
        public void WhenIAskWhatIsNearMyCharacter()
        {
            ScenarioContext.Current.Add("Neighbourhood", Server.GetNeighbourhood());
        }
    }
}