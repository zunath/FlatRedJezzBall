using BitmapFont = FlatRedBall.Graphics.BitmapFont;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if XNA4 || WINDOWS_8
using Color = Microsoft.Xna.Framework.Color;
#elif FRB_MDX
using Color = System.Drawing.Color;
#else
using Color = Microsoft.Xna.Framework.Graphics.Color;
#endif

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Microsoft.Xna.Framework.Media;
#endif

// Generated Usings
using FlatRedJezzBall.Entities;
using FlatRedBall;
using FlatRedBall.Screens;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math;

namespace FlatRedJezzBall.Screens
{
	public partial class GameScreen : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		
		private FlatRedJezzBall.Entities.Wall TopWall;
		private FlatRedJezzBall.Entities.Wall RightWall;
		private FlatRedJezzBall.Entities.Wall BottomWall;
		private FlatRedJezzBall.Entities.Wall LeftWall;
		private FlatRedJezzBall.Entities.MouseCursor MouseCursorInstance;
		private PositionedObjectList<FlatRedJezzBall.Entities.Ball> BallList;

		public GameScreen()
			: base("GameScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			TopWall = new FlatRedJezzBall.Entities.Wall(ContentManagerName, false);
			TopWall.Name = "TopWall";
			RightWall = new FlatRedJezzBall.Entities.Wall(ContentManagerName, false);
			RightWall.Name = "RightWall";
			BottomWall = new FlatRedJezzBall.Entities.Wall(ContentManagerName, false);
			BottomWall.Name = "BottomWall";
			LeftWall = new FlatRedJezzBall.Entities.Wall(ContentManagerName, false);
			LeftWall.Name = "LeftWall";
			MouseCursorInstance = new FlatRedJezzBall.Entities.MouseCursor(ContentManagerName, false);
			MouseCursorInstance.Name = "MouseCursorInstance";
			BallList = new PositionedObjectList<FlatRedJezzBall.Entities.Ball>();
			BallList.Name = "BallList";
			
			
			PostInitialize();
			base.Initialize(addToManagers);
			if (addToManagers)
			{
				AddToManagers();
			}

        }
        
// Generated AddToManagers
		public override void AddToManagers ()
		{
			TopWall.AddToManagers(mLayer);
			RightWall.AddToManagers(mLayer);
			BottomWall.AddToManagers(mLayer);
			LeftWall.AddToManagers(mLayer);
			MouseCursorInstance.AddToManagers(mLayer);
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				TopWall.Activity();
				RightWall.Activity();
				BottomWall.Activity();
				LeftWall.Activity();
				MouseCursorInstance.Activity();
				for (int i = BallList.Count - 1; i > -1; i--)
				{
					if (i < BallList.Count)
					{
						// We do the extra if-check because activity could destroy any number of entities
						BallList[i].Activity();
					}
				}
			}
			else
			{
			}
			base.Activity(firstTimeCalled);
			if (!IsActivityFinished)
			{
				CustomActivity(firstTimeCalled);
			}


				// After Custom Activity
				
            
		}

		public override void Destroy()
		{
			// Generated Destroy
			
			BallList.MakeOneWay();
			if (TopWall != null)
			{
				TopWall.Destroy();
				TopWall.Detach();
			}
			if (RightWall != null)
			{
				RightWall.Destroy();
				RightWall.Detach();
			}
			if (BottomWall != null)
			{
				BottomWall.Destroy();
				BottomWall.Detach();
			}
			if (LeftWall != null)
			{
				LeftWall.Destroy();
				LeftWall.Detach();
			}
			if (MouseCursorInstance != null)
			{
				MouseCursorInstance.Destroy();
				MouseCursorInstance.Detach();
			}
			for (int i = BallList.Count - 1; i > -1; i--)
			{
				BallList[i].Destroy();
			}
			BallList.MakeTwoWay();

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			if (MouseCursorInstance.Parent == null)
			{
				MouseCursorInstance.Z = 3f;
			}
			else
			{
				MouseCursorInstance.RelativeZ = 3f;
			}
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			CameraSetup.ResetCamera(SpriteManager.Camera);
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			TopWall.RemoveFromManagers();
			RightWall.RemoveFromManagers();
			BottomWall.RemoveFromManagers();
			LeftWall.RemoveFromManagers();
			MouseCursorInstance.RemoveFromManagers();
			for (int i = BallList.Count - 1; i > -1; i--)
			{
				BallList[i].Destroy();
			}
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				TopWall.AssignCustomVariables(true);
				RightWall.AssignCustomVariables(true);
				BottomWall.AssignCustomVariables(true);
				LeftWall.AssignCustomVariables(true);
				MouseCursorInstance.AssignCustomVariables(true);
			}
			if (MouseCursorInstance.Parent == null)
			{
				MouseCursorInstance.Z = 3f;
			}
			else
			{
				MouseCursorInstance.RelativeZ = 3f;
			}
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			TopWall.ConvertToManuallyUpdated();
			RightWall.ConvertToManuallyUpdated();
			BottomWall.ConvertToManuallyUpdated();
			LeftWall.ConvertToManuallyUpdated();
			MouseCursorInstance.ConvertToManuallyUpdated();
			for (int i = 0; i < BallList.Count; i++)
			{
				BallList[i].ConvertToManuallyUpdated();
			}
		}
		public static void LoadStaticContent (string contentManagerName)
		{
			if (string.IsNullOrEmpty(contentManagerName))
			{
				throw new ArgumentException("contentManagerName cannot be empty or null");
			}
			#if DEBUG
			if (contentManagerName == FlatRedBallServices.GlobalContentManager)
			{
				HasBeenLoadedWithGlobalContentManager = true;
			}
			else if (HasBeenLoadedWithGlobalContentManager)
			{
				throw new Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
			}
			#endif
			FlatRedJezzBall.Entities.Wall.LoadStaticContent(contentManagerName);
			FlatRedJezzBall.Entities.MouseCursor.LoadStaticContent(contentManagerName);
			CustomLoadStaticContent(contentManagerName);
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			return null;
		}
		public static object GetFile (string memberName)
		{
			return null;
		}
		object GetMember (string memberName)
		{
			return null;
		}


	}
}
