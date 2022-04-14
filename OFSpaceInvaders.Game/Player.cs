using System;
using OFSpaceInvaders.Game.Objects;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

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
                }
            };
        }

        public override void Shoot()
        {
            ((Container)Parent).Add(new Bullet(this) {                                                    
                                                    Y = Y-4,
                                                    Scale = Scale,
                                                    Rotation = 180,                                                    
                                                 });
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
