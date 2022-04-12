using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osu.Framework.Threading;
using osu.Framework.Timing;
using osuTK;
using osuTK.Input;

namespace OFSpaceInvaders.Game
{
    public class OFSpaceInvadersGame : OFSpaceInvadersGameBase
    {
        private readonly DrawSizePreservingFillContainer gameScreen = new DrawSizePreservingFillContainer();
        private Player player;
        private StopwatchClock shootClock = new StopwatchClock();
        private StopwatchClock movementClock = new StopwatchClock();
        private Key currMoveKeyDown;
        private bool isShootKeyDown = false;

        [BackgroundDependencyLoader]
        private void load()
        {
            gameScreen.Children = new Drawable[]
            {
                player = new Player()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale  = new Vector2(2,2),
                }
            };
            gameScreen.Strategy = DrawSizePreservationStrategy.Minimum;
            gameScreen.TargetDrawSize = new Vector2(448, 512);

            // TODO: Add Enemies to screen
            // TODO: Maybe add a grid/container for the enemies to add into?
            AddInternal(gameScreen);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }

        protected override void Update()
        {
            base.Update();
            if (shootClock.Elapsed.TotalSeconds >= 1)
                shootClock.Reset();
            if (movementClock.Elapsed.TotalMilliseconds >= 20)
                movementClock.Reset();

            if (isShootKeyDown)
                shootPlayer();
            if (currMoveKeyDown != default)
                movePlayer(currMoveKeyDown);

            if (checkCollision())
                Logger.LogPrint("HIT!");            
        }

        private bool checkCollision()
        {
            // TODO: Check collision of bullets with enemies
            // TODO: Check collision of enemy bullets with player
            return false;
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (e.Repeat)
            {
                Logger.Log(e.Key.ToString());
            }

            if (e.Key == Key.Space)
                shootPlayer();
                

            if (e.Key == Key.A || e.Key == Key.D)
            {
                movePlayer(e.Key);
                currMoveKeyDown = e.Key;
                // Return true to denote we captured the input here, so we don't need to continue the chain
                return true;
            }

            return base.OnKeyDown(e);
        }

        private void movePlayer(Key key)
        {
            if (!movementClock.IsRunning)
            {
                if (key == Key.A)
                    player.MoveLeft();
                else if (key == Key.D)
                    player.MoveRight();
                movementClock.Start();
            }
        }

        private void shootPlayer()
        {
            if (!shootClock.IsRunning)
            {
                player.Shoot();
                shootClock.Start();
                isShootKeyDown = true;
            }
        }

        protected override void OnKeyUp(KeyUpEvent e)
        {
            Logger.Log(e.Key.ToString());
            if (e.Key == currMoveKeyDown)
                currMoveKeyDown = default;
            if (e.Key == Key.Space)
                isShootKeyDown = false;
        }
    }
}
