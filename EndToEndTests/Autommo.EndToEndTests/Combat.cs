namespace Autommo.EndToEndTests
{
    #region Using Directives

    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StoryQ;

    #endregion

    [TestClass]
    public class Combat : ServerTestBase
    {
        private readonly Feature _feature = new Story("Combat")
            .InOrderTo("win epic loot")
            .AsA("bot")
            .IWant("to kill things");

        [TestMethod]
        public void EnterCombat()
        {
            _feature
                .WithScenario("Enter combat")
                .Given(ThereIsAHostileMob)
                .When(IMoveMyCharacterNextToTheMob)
                .Then(CombatShouldBegin)
                .Execute();
        }

        private void CombatShouldBegin()
        {
            throw new NotImplementedException();
        }

        private void IMoveMyCharacterNextToTheMob()
        {
            throw new NotImplementedException();
        }

        private void ThereIsAHostileMob()
        {
            Server.AddMob();
        }
    }
}