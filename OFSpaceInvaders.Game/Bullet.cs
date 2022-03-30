using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Containers;
using osu.Framework.Allocation;

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
        private void load()
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
                    Width  = 20,
                    Height = 40,
                    Colour = Colour4.White,
                },
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            // TODO: this only moves once weirdly
            this.Loop(b => b.Delay(100).MoveTo(new osuTK.Vector2(b.X, b.Y + 100)));
        }
    }
}
