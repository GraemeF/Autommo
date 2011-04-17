namespace Autommo.Game.Tests
{
    #region Using Directives

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Should.Fluent;

    #endregion

    [TestClass]
    public class WorldTests
    {
        private readonly World _test = new World();

        [TestMethod]
        public void GettingCharacters_Initially_IsEmpty()
        {
            _test.Characters.Should().Be.Empty();
        }

        [TestMethod]
        public void GettingUnits_Initially_IsEmpty()
        {
            _test.Units.Should().Be.Empty();
        }
    }
}