using osu.Framework.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.Sprites;

namespace OFSpaceInvaders.Game
{
    public class Bullet: CompositeDrawable
    {
        private Container box;
        public Bullet()
        {
            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;
            //box.Loop(b => b.MoveTo(new osuTK.Vector2(b.X, b.Y + 10)));
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            InternalChild = box = new Container()
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };
            box.Children = new Drawable[]
            {
                new Box
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,                    
                },
                new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Texture = textures.Get("bullet"),
                    Scale   = new osuTK.Vector2(10f,10f),
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            // TODO: this only moves once weirdly
            box.MoveTo(new osuTK.Vector2(box.X, box.Y - 10)).Loop(1);
        }
    }
}
