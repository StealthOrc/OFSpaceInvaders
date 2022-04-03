using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using OFSpaceInvaders.Resources;
using osu.Framework.Platform;
using osu.Framework.Graphics.Textures;
using osuTK.Graphics.ES30;

namespace OFSpaceInvaders.Game
{
    public class OFSpaceInvadersGameBase : osu.Framework.Game
    {
        private TextureStore textures;

        private DependencyContainer dependencies;

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            // Load the assets from our Resources project
            Resources.AddStore(new DllResourceStore(OFSpaceInvadersResources.ResourceAssembly));

            // To preserve the 8-bit aesthetic, disable texture filtering
            // so they won't become blurry when upscaled
            textures = new TextureStore(Textures, filteringMode: All.Nearest);
            dependencies.Cache(textures);
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
            => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
    }
}
