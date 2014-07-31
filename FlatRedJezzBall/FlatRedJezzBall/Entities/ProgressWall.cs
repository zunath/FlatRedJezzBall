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
	public partial class ProgressWall
	{
        public bool IsActive { get; set; }
        public DirectionEnum Direction { get; set; }

		private void CustomInitialize()
		{
            IsActive = false;
            Direction = DirectionEnum.Vertical;
		}

		private void CustomActivity()
		{
            if (IsActive)
            {
                this.CollisionBox.Visible = true;
                if (Direction == DirectionEnum.Horizontal)
                {
                    this.CollisionBox.Width += 10;
                }
                else if (Direction == DirectionEnum.Vertical)
                {
                    this.CollisionBox.Height += 10;
                }
            }
            else
            {
                this.CollisionBox.Width = 16;
                this.CollisionBox.Height = 16;
                this.CollisionBox.Visible = false;
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
