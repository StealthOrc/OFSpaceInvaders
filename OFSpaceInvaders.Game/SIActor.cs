using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;

namespace OFSpaceInvaders.Game.Objects
{
    /// <summary>
    /// A template class for all kind of Objects (Actors) represented in the game
    /// </summary>
    public abstract class SIActor: CompositeDrawable
    {
        protected int Health;
        protected Container Container;
        protected Sprite Sprite;

        public SIActor() { }

        /// <summary>
        /// shoots a projectile
        /// </summary>
        public abstract void Shoot();

        /// <summary>
        /// get hit for dmg
        /// </summary>
        public abstract void Hit(int dmg);

        /// <summary>
        /// this is getting called when HP drop to Zero
        /// </summary>
        protected abstract void Die();

        /// <summary>
        /// moves the Actor to the Left
        /// </summary>
        public abstract void MoveLeft();
        /// <summary>
        /// moves the Actor to the Right
        /// </summary>
        public abstract void MoveRight();
    }
}
