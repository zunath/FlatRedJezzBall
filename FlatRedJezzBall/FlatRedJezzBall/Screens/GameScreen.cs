#region Usings

using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Graphics.Model;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using FlatRedBall.Localization;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using FlatRedJezzBall.Entities;
using FlatRedBall.Screens;
using FlatRedJezzBall.Enumerations;
#endif
#endregion

namespace FlatRedJezzBall.Screens
{
	public partial class GameScreen
	{
        private const bool DebugModeEnabled = true;

		void CustomInitialize()
		{
            TopWall.Y = SpriteManager.Camera.Y + SpriteManager.Camera.RelativeYEdgeAt(0.0f);
            TopWall.SpriteInstance.Width = SpriteManager.Camera.GetViewport().Width;
            TopWall.CollisionBox.Width = SpriteManager.Camera.GetViewport().Width;

            BottomWall.Y = SpriteManager.Camera.Y + SpriteManager.Camera.RelativeYEdgeAt(0.0f) * -1;
            BottomWall.SpriteInstance.Width = SpriteManager.Camera.GetViewport().Width;
            BottomWall.CollisionBox.Width = SpriteManager.Camera.GetViewport().Width;

            RightWall.X = SpriteManager.Camera.X + SpriteManager.Camera.RelativeXEdgeAt(0.0f);
            RightWall.SpriteInstance.Height = SpriteManager.Camera.GetViewport().Height;
            RightWall.CollisionBox.Height = SpriteManager.Camera.GetViewport().Height;

            LeftWall.X = SpriteManager.Camera.X + SpriteManager.Camera.RelativeXEdgeAt(0.0f) * -1;
            LeftWall.SpriteInstance.Height = SpriteManager.Camera.GetViewport().Height;
            LeftWall.CollisionBox.Height = SpriteManager.Camera.GetViewport().Height;


            BallList.Add(new Ball());
            BallList.Add(new Ball());
            BallList.Add(new Ball());
            BallList.Add(new Ball());
            BallList.Add(new Ball());
            BallList.Add(new Ball());

		}

		void CustomActivity(bool firstTimeCalled)
		{
            MouseCursorInstance.X = InputManager.Mouse.WorldXAt(0.0f);
            MouseCursorInstance.Y = InputManager.Mouse.WorldYAt(0.0f);

            CheckBallCollisions();
            CheckProgressWallCollisions();
            CheckDebugControls();
            CheckControls();
		}

        private void CheckProgressWallCollisions()
        {
            if (ProgressWallInstance.Direction == DirectionEnum.Vertical)
            {
                if (ProgressWallInstance.CollisionBox.CollideAgainst(TopWall.CollisionBox) ||
                    ProgressWallInstance.CollisionBox.CollideAgainst(BottomWall.CollisionBox))
                {
                    ProgressWallInstance.IsActive = false;
                }
            }
            else if (ProgressWallInstance.Direction == DirectionEnum.Horizontal)
            {
                if (ProgressWallInstance.CollisionBox.CollideAgainst(LeftWall.CollisionBox) ||
                    ProgressWallInstance.CollisionBox.CollideAgainst(RightWall.CollisionBox))
                {
                    ProgressWallInstance.IsActive = false;
                }
            }
        }

        private void CheckBallCollisions()
        {
            foreach (Ball ball in BallList)
            {
                Circle ballCircle = ball.CollisionBox;

                if (TopWall.CollisionBox.CollideAgainst(ballCircle))
                {
                    ball.YVelocity = ball.YVelocity * -1;
                }

                if (BottomWall.CollisionBox.CollideAgainst(ballCircle))
                {
                    ball.YVelocity = ball.YVelocity * -1;
                }

                if (LeftWall.CollisionBox.CollideAgainst(ballCircle))
                {
                    ball.XVelocity = ball.XVelocity * -1;
                }

                if (RightWall.CollisionBox.CollideAgainst(ballCircle))
                {
                    ball.XVelocity = ball.XVelocity * -1;
                }
            }
        }

        private void CheckControls()
        {
            if (InputManager.Mouse.IsInGameWindow())
            {
                if (InputManager.Mouse.ButtonPushed(Mouse.MouseButtons.LeftButton))
                {
                    if (!ProgressWallInstance.IsActive && !IsMouseOverWall())
                    {
                        ProgressWallInstance.X = MouseCursorInstance.X;
                        ProgressWallInstance.Y = MouseCursorInstance.Y;
                        ProgressWallInstance.Direction = MouseCursorInstance.Direction;
                        ProgressWallInstance.IsActive = true;
                    }
                }
            }
        }

        private bool IsMouseOverWall()
        {
            bool result = false;

            if (MouseCursorInstance.CollisionBox.CollideAgainst(TopWall.CollisionBox) ||
                MouseCursorInstance.CollisionBox.CollideAgainst(LeftWall.CollisionBox) ||
                MouseCursorInstance.CollisionBox.CollideAgainst(RightWall.CollisionBox) ||
                MouseCursorInstance.CollisionBox.CollideAgainst(BottomWall.CollisionBox))
            {
                result = true;
            }

            return result;
        }

        private void CheckDebugControls()
        {
            if (DebugModeEnabled)
            {
                if (InputManager.Keyboard.KeyPushed(Keys.F5))
                {
                    this.MoveToScreen(typeof(GameScreen));
                }
            }
        }

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

	}
}
