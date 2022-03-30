using osu.Framework.Testing;

namespace OFSpaceInvaders.Game.Tests.Visual
{
    public class OFSpaceInvadersTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new OFSpaceInvadersTestSceneTestRunner();

        private class OFSpaceInvadersTestSceneTestRunner : OFSpaceInvadersGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
