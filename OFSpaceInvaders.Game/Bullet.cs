using OFSpaceInvaders.Game.Objects;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Logging;
using osuTK;

namespace OFSpaceInvaders.Game
{
    public class Bullet : SIActor
    {
        private Container box;
        /// <summary>
        /// Whether the bullet is presently animating or not.
        /// </summary>
        public bool Running { get; private set; }
        /// <summary>
        /// X direction which the bullet flies towards
        /// </summary>
        public int DirectionX { get; private set; }
        /// <summary>
        /// Y direction which the bullet flies towards
        /// </summary>
        public int DirectionY { get; private set; }
        /// <summary>
        /// reference that points to the SIActor that shot this bullet
        /// </summary>
        public SIActor Owner { get; private set; }
        public Bullet(SIActor aOwner, float aVelocity = 1)
        {
            AutoSizeAxes = Axes.Both;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Running = true;
            Velocity = aVelocity;
            Owner = aOwner;
        }
        /// <summary>
        /// velocity of the bullet
        /// </summary>
        public float Velocity { get; private set; }

        private void determineDirections(float aRotation)
        {
            var dir = (int)(aRotation/45);
            //a definetly way too complicated rotation system for this game.
            switch (dir)
            {
                case 0:
                    //Rotation   =   0;
                    DirectionX =   0;
                    DirectionY =   1;
                    break;       
                case 1:          
                    //Rotation   =  45;
                    DirectionX =  -1;
                    DirectionY =   1;
                    break;       
                case 2:          
                    //Rotation   =  90;
                    DirectionX =  -1;
                    DirectionY =   0;
                    break;       
                case 3:          
                    //Rotation   = 135;
                    DirectionX =  -1;
                    DirectionY =  -1;
                    break;       
                case 4:          
                    //Rotation   = 180;
                    DirectionX =   0;
                    DirectionY =  -1;
                    break;       
                case 5:          
                    //Rotation   = 225;
                    DirectionX =   1;
                    DirectionY =  -1;
                    break;       
                case 6:          
                    //Rotation   = 270;
                    DirectionX =   1;
                    DirectionY =   0;
                    break;       
                case 7:          
                    //Rotation   = 315;
                    DirectionX =   1;
                    DirectionY =   1;
                    break;       
                case 8:          
                    //Rotation   = 360;
                    DirectionX =   0;
                    DirectionY =  -1;
                    break;
                default:
                    break;
            }
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            InternalChild = box = new Container()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };
            box.Children = new Drawable[]
            {
                new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Texture = textures.Get("bullet"),
                }
            };
        }

        protected override void Update()
        {
            if (!Running)
                return;

            X += Velocity * DirectionX;
            Y += Velocity * DirectionY;
        }

        protected override void Die()
        {
            base.Die();
            Running = false;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            determineDirections(Rotation);
        }
    }
}
