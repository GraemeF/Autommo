namespace Autommo.EndToEndTests
{
    #region Using Directives

    using System;

    using Autommo.EndToEndTestEntities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StoryQ;

    #endregion

    [TestClass]
    public class Admin
    {
        private readonly Feature _feature = new Story("Admin")
            .InOrderTo("edit the world")
            .AsA("administrator")
            .IWant("to change what is in it");

        private readonly AutommoServer _server = new AutommoServer();

        [TestMethod]
        public void AddANewCharacter()
        {
            const string characterName = "Bob";
            _feature
                .WithScenario("Add a new character")
                .Given(Nothing)
                .When(IAddCharacterNamed_ToTheWorld, characterName)
                .Then(ICanGetTheCharacterNamed_, characterName)
                .Execute();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _server.Dispose();
        }

        private void IAddCharacterNamed_ToTheWorld(string id)
        {
            _server.AddCharacter(id);
        }

        private void ICanGetTheCharacterNamed_(string obj)
        {
            throw new NotImplementedException();
        }

        private void Nothing()
        {
        }
    }
}