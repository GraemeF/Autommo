namespace Tests
{
    #region Using Directives

    using System.Linq;

    using JsonFx.Json;

    using Should.Fluent;

    using Xunit;

    #endregion

    public class JsonFxTests
    {
        [Fact]
        public void Read__ReadsAList()
        {
            string json = "{\"Bars\":[{\"Baz\":\"Test\"}]}";

            var result = new JsonReader().Read<Foo>(json);

            result.Bars.Single().Baz.Should().Equal("Test");
        }
    }

    public class Foo
    {
        public Bar[] Bars { get; set; }
    }

    public class Bar
    {
        public string Baz { get; set; }
    }
}