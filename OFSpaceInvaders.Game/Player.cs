using System;
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
    public class Player : SICharacter
    {
        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            InternalChild = Container = new Container
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    Sprite = new Sprite
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Texture = textures.Get("player")
                    },
                    ShootingAnchor = new Box()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Y = Y-4,
                    }
                }
            };
            ShootingAnchor.Hide();
        }

        public override void Shoot()
        {
            ((Container)Parent).Add(new Bullet(this) {
                                                    // this seems whacky but works for now. I'd rather want to use something like WorldSpaceCoords
                                                    // or get ShootingAnchor Coords for this.Parent space and set Bullet Coords to that.
                                                    Y = Y+ShootingAnchor.Y,
                                                    X = X+ShootingAnchor.X,
                                                    Scale = Scale,
                                                    Rotation = 180,                                                    
                                                 });
        }


        protected override void Update()
        {
            base.Update();
            Logger.Log(ToParentSpace(ShootingAnchor.Position).ToString());
        }

        public override void MoveLeft()
        {
            X -= 4;
        }

        public override void MoveRight()
        {
            X += 4;
        }

        public override void MoveDown()
        {
            //do nothing
        }

        public override void MoveUp()
        {
            //do nothing
        }
    }
}
