using OFSpaceInvaders.Game.Objects;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.Logging;
using osuTK;

namespace OFSpaceInvaders.Game
{
    public class Enemy: SICharacter
    {
        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            LoadCharacter(textures, "invader1", new Vector2(0, 4));
            MovementSpeed = 20;
            Position = new Vector2(20, 20);
        } 

        public override void Shoot()
        {
            /* 10.05.2022: Somehow I can't use (Container)Parent.Add to add this to the parent.
             *             neither can I try to ((DrawSizePreservingFillContainer)((Container)Parent).Add to call the gameScreen.Add..
             *             it all results in a "Disposed Drawables may never be in the scene graph." Exception??
             */
            Container.Add(new Bullet()
            {
                // this seems whacky but works for now. I'd rather want to use something like WorldSpaceCoords
                // or get ShootingAnchor Coords for this.Parent space and set Bullet Coords to that.
                Y = Y + ShootingAnchor.Y,
                X = X + ShootingAnchor.X,
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
            X -= 20;
        }

        public override void MoveRight()
        {
            X += 20;
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
