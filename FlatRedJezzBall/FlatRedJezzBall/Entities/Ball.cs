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

#endif
#endregion

namespace FlatRedJezzBall.Entities
{
	public partial class Ball
	{
        const double DefaultVelocity = 200.0f;

		private void CustomInitialize()
		{
            Random random = FlatRedBallServices.Random;
            int direction = random.Next(1, 4);

            // Up-Right
            if (direction == 1)
            {
                XVelocity = (float)(DefaultVelocity + Convert.ToDouble(random.Next(-20, 20)));
                YVelocity = (float)(DefaultVelocity + Convert.ToDouble(random.Next(-20, 20)));
                
            }
            // Up-Left
            else if (direction == 2)
            {
                XVelocity = (float)(DefaultVelocity + Convert.ToDouble(random.Next(-20, 20))) * -1;
                YVelocity = (float)(DefaultVelocity + Convert.ToDouble(random.Next(-20, 20)));
            }
            // Down-Right
            else if (direction == 3)
            {
                XVelocity = (float)(DefaultVelocity + Convert.ToDouble(random.Next(-20, 20)));
                YVelocity = (float)(DefaultVelocity + Convert.ToDouble(random.Next(-20, 20))) * -1;
            }
            // Down-Left
            else if (direction == 4)
            {
                XVelocity = (float)(DefaultVelocity + Convert.ToDouble(random.Next(-20, 20))) * -1;
                YVelocity = (float)(DefaultVelocity + Convert.ToDouble(random.Next(-20, 20))) * -1;
            }

            int maxWidth = SpriteManager.Camera.GetViewport().Width / 2 - 50;
            int maxHeight = SpriteManager.Camera.GetViewport().Height / 2 - 50;
            int minWidth = -(maxWidth);
            int minHeight = -(maxHeight);

            X = random.Next(minWidth, maxWidth);
            Y = random.Next(minHeight, maxHeight);
		}

		private void CustomActivity()
		{


		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
