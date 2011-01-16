namespace Autommo.EndToEndTests.Steps
{
    #region Using Directives

    using Autommo.Dto;

    using Should.Fluent;

    using TechTalk.SpecFlow;

    #endregion

    public class CharacterSteps : ServerSteps
    {
        [Then(@"combat should begin")]
        public void ThenCombatShouldBegin()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can get the character ""(.*)""")]
        public void ThenICanGetTheCharacter(string id)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"there should be a mob in the neighbourhood")]
        public void ThereShouldBeAMobInTheNeighbourhood()
        {
            ScenarioContext.Current.Get<Neighbourhood>("Neighbourhood").
                Mobs.Should().Count.AtLeast(1);
        }

        [When(@"I add character ""(.*)"" to the world")]
        public void WhenIAddCharacterToTheWorld(string id)
        {
            Server.AddCharacter(id);
        }

        [When(@"I ask what is near my character")]
        public void WhenIAskWhatIsNearMyCharacter()
        {
            ScenarioContext.Current.Add("Neighbourhood", Server.GetNeighbourhood());
        }
    }
}