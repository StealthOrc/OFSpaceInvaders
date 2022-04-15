using System;
using System.Collections.Generic;
using System.Text;
using OFSpaceInvaders.Game.Objects;
using osu.Framework.Graphics;

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
