using Autommo.EndToEndTestEntities;
using TechTalk.SpecFlow;

namespace Autommo.EndToEndTests.Steps
{
    [Binding]
    public class ServerSteps
    {
        protected static AutommoServer Server
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("Server"))
                    Launch();

                return ScenarioContext.Current.Get<AutommoServer>("Server");
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            if (ScenarioContext.Current.ContainsKey("Server"))
                ScenarioContext.Current.Get<AutommoServer>("Server").Dispose();
        }

        protected static void Launch()
        {
            ScenarioContext.Current.Add("Server", new AutommoServer());
        }
    }
}