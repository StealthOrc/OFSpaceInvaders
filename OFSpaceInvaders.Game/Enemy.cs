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
        }

        public override void Shoot()
        {
            ((Container)Parent).Add(new Bullet(this)
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
