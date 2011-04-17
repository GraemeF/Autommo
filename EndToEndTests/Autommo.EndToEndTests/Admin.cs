namespace Autommo.EndToEndTests
{
    #region Using Directives

    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StoryQ;

    #endregion

    [TestClass]
    public class Admin : ServerTestBase
    {
        private readonly Feature _feature = new Story("Admin")
            .InOrderTo("edit the world")
            .AsA("administrator")
            .IWant("to change what is in it");

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

        private void IAddCharacterNamed_ToTheWorld(string id)
        {
            Server.AddCharacter(id);
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