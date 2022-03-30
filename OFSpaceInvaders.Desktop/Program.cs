using osu.Framework.Platform;
using osu.Framework;
using OFSpaceInvaders.Game;

namespace OFSpaceInvaders.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"OFSpaceInvaders"))
            using (osu.Framework.Game game = new OFSpaceInvadersGame())
                host.Run(game);
        }
    }
}
