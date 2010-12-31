using Should.Fluent;
using Xunit;

namespace Autommo.Game.Tests
{
    public class WorldTests
    {
        private readonly World _test = new World();

        [Fact]
        public void GettingUnits_Initially_IsEmpty()
        {
            _test.Units.Should().Be.Empty();
        }
    }
}