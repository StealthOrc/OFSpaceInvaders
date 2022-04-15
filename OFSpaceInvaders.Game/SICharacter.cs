using System;
using System.Collections.Generic;
using System.Text;
using OFSpaceInvaders.Game.Objects;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace OFSpaceInvaders.Game.Objects
{
    /// <summary>
    /// base class for all kinds of (non-/playable) characters with the ability to move and shoot.
    /// </summary>
    public abstract class SICharacter: SIActor
    {
        /// <summary>
        /// Anchor/Position to shoot a Bullet from.
        /// </summary>
        protected Drawable ShootingAnchor;
        /// <summary>
        /// movement speed into any direction
        /// </summary>
        protected float MovementSpeed;

        protected void LoadCharacter(TextureStore textures, String textureName,Vector2 distanceShootingAnchor)
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
                        Texture = textures.Get(textureName)
                    },
                    ShootingAnchor = new Box()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Y = Y+distanceShootingAnchor.Y,
                        X = X+distanceShootingAnchor.X,
                    }
                }
            };
            ShootingAnchor.Hide();
        }
        /// <summary>
        /// shoots a projectile
        /// </summary>
        public abstract void Shoot();

        /// <summary>
        /// moves the Character to the Left
        /// </summary>
        public abstract void MoveLeft();
        /// <summary>
        /// moves the Character to the Right
        /// </summary>
        public abstract void MoveRight();

        /// <summary>
        /// moves the Character up
        /// </summary>
        public abstract void MoveUp();

        /// <summary>
        /// moves the Character down
        /// </summary>
        public abstract void MoveDown();

    }
}
