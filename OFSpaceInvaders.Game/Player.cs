using System;
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
    public class Player : SICharacter
    {
        //needed to keep the textures active??
        [Resolved]
        private TextureStore textures { get; set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            LoadCharacter(textures, "player", new Vector2(0, -4));
            MovementSpeed = 4;
        }

        public override void Shoot()
        {
            /* 10.05.2022: Somehow I can't use (Container)Parent.Add to add this to the parent.
             *             neither can I try to ((DrawSizePreservingFillContainer)((Container)Parent).Add to call the gameScreen.Add..
             *             it all results in a "Disposed Drawables may never be in the scene graph." Exception??
             */
            Container.Add(new Bullet()
            {
                Y = ShootingAnchor.Y,
                X = ShootingAnchor.X,
                Scale = Scale,
                Rotation = 180,                                                    
            });            
        }


        protected override void Update()
        {
            base.Update();
        }

        public override void MoveLeft()
        {
            X -= MovementSpeed;
        }

        public override void MoveRight()
        {
            X += MovementSpeed;
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
