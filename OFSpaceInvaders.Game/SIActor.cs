using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;

namespace OFSpaceInvaders.Game.Objects
{
    /// <summary>
    /// A template class for all kind of Objects (Actors) represented in the game
    /// </summary>
    public class SIActor: CompositeDrawable
    {
        protected int Health;
        protected Container Container;
        protected Sprite Sprite;

        public SIActor() { }

        public Quad CollisionQuad
        {
            get
            {
                RectangleF rect = ScreenSpaceDrawQuad.AABBFloat;
                return Quad.FromRectangle(rect);
            }
        }
        /// <summary>
        /// this is getting called when HP drop to Zero
        /// </summary>
        protected void Die()
        {
            //get rid of our drawable
            Dispose();
        }

        /// <summary>
        /// get hit for dmg
        /// </summary>
        public void Hit(int dmg)
        {
            if (dmg == 0)
                return;
            if (Health - Math.Abs(dmg) <= 0)
                Die();
            else
                Health -= dmg;
        }
    }
}
