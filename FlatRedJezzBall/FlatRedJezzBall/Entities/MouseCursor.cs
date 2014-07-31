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

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using FlatRedJezzBall.Enumerations;

#endif
#endregion

namespace FlatRedJezzBall.Entities
{
	public partial class MouseCursor
	{
        private Texture2D _horizontalTexture;
        private Texture2D _verticalTexture;
        public DirectionEnum Direction { get; set; }

		private void CustomInitialize()
		{
            this.Direction = DirectionEnum.Vertical;

            _horizontalTexture = FlatRedBallServices.Load<Texture2D>("Content/Entities/MouseCursor/cursor_horizontal");
            _verticalTexture = FlatRedBallServices.Load<Texture2D>("Content/Entities/MouseCursor/cursor_vertical");
		}

		private void CustomActivity()
		{
            if (InputManager.Mouse.IsInGameWindow())
            {
                if (InputManager.Mouse.ButtonPushed(Mouse.MouseButtons.RightButton))
                {
                    ChangeDirection();
                }
            }
		}

        private void ChangeDirection()
        {
            if (Direction == DirectionEnum.Horizontal)
            {
                Direction = DirectionEnum.Vertical;
                SpriteInstance.Texture = _verticalTexture;
                CollisionBox.Width = 16;
                CollisionBox.Height = 33;
            }
            else if (Direction == DirectionEnum.Vertical)
            {
                Direction = DirectionEnum.Horizontal;
                SpriteInstance.Texture = _horizontalTexture;
                CollisionBox.Width = 33;
                CollisionBox.Height = 16;
            }
        }

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {
            

        }
	}
}
