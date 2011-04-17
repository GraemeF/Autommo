namespace Autommo.EndToEndTests
{
    #region Using Directives

    using Autommo.Dto;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Should.Fluent;

    using StoryQ;

    #endregion

    [TestClass]
    public class Survey : ServerTestBase
    {
        private readonly Feature _feature = new Story("Survey")
            .InOrderTo("see what is in the game world")
            .AsA("player")
            .IWant("to see what is around my character");

        private Neighbourhood _neighbourhood;

        [TestMethod]
        public void SeeIfThereAreAnyMobsInTheNeighbourhood()
        {
            _feature
                .WithScenario("See if there are any mobs in the neighbourhood")
                .Given(Nothing)
                .When(IAskWhatIsNearMyCharacter)
                .Then(ThereShouldBeAMobInTheNeighbourhood)
                .Execute();
        }

        private void IAskWhatIsNearMyCharacter()
        {
            _neighbourhood = Server.GetNeighbourhood();
        }

        private void Nothing()
        {
        }

        private void ThereShouldBeAMobInTheNeighbourhood()
        {
            _neighbourhood.Mobs.Should().Count.AtLeast(1);
        }
    }
}