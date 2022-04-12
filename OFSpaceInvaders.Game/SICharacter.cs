using System;
using System.Collections.Generic;
using System.Text;
using OFSpaceInvaders.Game.Objects;

namespace OFSpaceInvaders.Game.Objects
{
    /// <summary>
    /// base class for all kinds of (non-/playable) characters with the ability to move and shoot.
    /// </summary>
    public abstract class SICharacter: SIActor
    {
        /// <summary>
        /// shoots a projectile
        /// </summary>
        public abstract void Shoot();

        /// <summary>
        /// this is getting called when HP drop to Zero
        /// </summary>
        protected abstract void Die();

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
