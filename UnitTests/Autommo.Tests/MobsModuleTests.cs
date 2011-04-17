namespace Autommo.Tests
{
    #region Using Directives

    using Autommo.Dto;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Nancy;

    using Should.Fluent;

    #endregion

    [TestClass]
    public class MobsModuleTests
    {
        private readonly MobsModule _test = new MobsModule();

        [TestMethod]
        public void PostMob_WhenMobCanBeCreated_GivesCreatedResponse()
        {
            _test.InvokeRouteForRequest(new Request("POST", "http://localhost/mob", "http"), "/mob").StatusCode.
                Should().Equal(HttpStatusCode.Created);
        }

        [TestMethod]
        public void PostMob_WhenMobCanBeCreated_GivesResponseContainingMob()
        {
            _test.InvokeRouteForRequest(new Request("POST", "http://localhost/mob", "http"), "/mob").
                GetDeserializedContents<Mob>().Should().Be.OfType(typeof(Mob));
        }
    }
}