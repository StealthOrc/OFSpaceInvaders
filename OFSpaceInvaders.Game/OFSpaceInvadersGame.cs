using System;
using OFSpaceInvaders.Game.Objects;
using osu.Framework.Allocation;
using osu.Framework.Extensions.PolygonExtensions;
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
        private Player player = new Player();
        private StopwatchClock shootClock = new StopwatchClock();
        private StopwatchClock movementClock = new StopwatchClock();
        private GameState gameState = GameState.Ready;
        private Key currMoveKeyDown;
        private bool isShootKeyDown = false;
        private Enemy[] enemyList;

        [BackgroundDependencyLoader]
        private void load()
        {
            gameScreen.Children = new Drawable[]
            {
                player
            };
            //create enemies
            //Somehow this also calls the dispose exception for the player??
            /*
            Array.Resize(ref enemyList, 1);
            enemyList[0] = new Enemy();
            foreach (var enemy in enemyList)
            {
                gameScreen.Add(enemy);
            }         
            */
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
            switch (gameState)
            {
                case GameState.Ready:
                    gameState = GameState.Playing;
                    break;
                case GameState.Playing:
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
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }          
        }

        private bool checkCollision()
        {
            foreach (var child in gameScreen.Children)
            {
                var actor = (SIActor)child;
                if ((actor is Bullet) || (actor is Enemy))
                {                    
                    //check player collision
                    if (player.CollisionQuad.Intersects(actor.CollisionQuad))
                      player.Hit(1);
                }
            }
            // TODO: Check collision of bullets with enemies
            return false;
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
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
                /* 9.05.2022: Actually the players shoot() should be called, though somehow there's an issue with dispose():
                                "Disposed Drawables may never be in the scene graph."
                 *            So for now we need to do this manually here :(
                 */
                player.Shoot();
                shootClock.Start();
                isShootKeyDown = true;
            }
        }

        protected override void OnKeyUp(KeyUpEvent e)
        {
            if (e.Key == currMoveKeyDown)
                currMoveKeyDown = default;
            if (e.Key == Key.Space)
                isShootKeyDown = false;
        }
    }
}
