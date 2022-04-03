using System;
using System.Collections.Generic;
using System.Text;
using OFSpaceInvaders.Game.Objects;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace OFSpaceInvaders.Game
{
    public class Player : SIActor
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
                }
            };
        }

        public override void Hit(int dmg)
        {
            throw new NotImplementedException();
        }

        public override void Shoot()
        {
            ((Container)Parent).Add(new Bullet() {
                                                    Anchor = Anchor.Centre,
                                                    Origin = Anchor.Centre,
                                                    X = X,
                                                    Y = Y-4,
                                                    Scale = Scale,
                                                 });
            /*((Container)Parent).Add(new SpinningBox()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                X = X,
                Y = Y - 4,
                Scale = new Vector2(0.5f,0.5f),
            });
            */
        }

        protected override void Die()
        {
            throw new NotImplementedException();
        }

        public override void MoveLeft()
        {
            X -= 4;
        }

        public override void MoveRight()
        {
            X += 4;
        }
    }
}
