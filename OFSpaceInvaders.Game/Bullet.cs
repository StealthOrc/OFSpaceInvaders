using OFSpaceInvaders.Game.Objects;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Logging;

namespace OFSpaceInvaders.Game
{
    public class Bullet : SIActor
    {
        private Container box;
        public Bullet()
        {
            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            InternalChild = box = new Container()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };
            box.Children = new Drawable[]
            {
                new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Texture = textures.Get("bullet"),
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            
            box.MoveToY(box.Y - 400, 2000);
        }
    }
}
