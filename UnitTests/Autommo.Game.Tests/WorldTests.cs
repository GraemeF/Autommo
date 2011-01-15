namespace Autommo.Game.Tests
{
    #region Using Directives

    using Should.Fluent;

    using Xunit;

    #endregion

    public class WorldTests
    {
        private readonly World _test = new World();

        [Fact]
        public void GettingCharacters_Initially_IsEmpty()
        {
            _test.Characters.Should().Be.Empty();
        }

        [Fact]
        public void GettingUnits_Initially_IsEmpty()
        {
            _test.Units.Should().Be.Empty();
        }
    }
}