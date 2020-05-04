using GameTimer;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading.Tasks;

namespace DesktopGLBug
{
	public class ColorScreen : WidgetScreen
	{
		CountdownTimer timer = new CountdownTimer();

		public ColorScreen() : base("Color Screen", null)
		{
		}

		public override async Task LoadContent()
		{
			await base.LoadContent();

			await Task.Delay(new TimeSpan(0,0,1));

			//load a bunch of graphic assets
			var position = 0;
			AddImage("red", position);
			AddImage("orange", position += 64);
			AddImage("yellow", position += 64);
			AddImage("green", position += 64);
			AddImage("blue", position += 64);
			AddImage("purple", position += 64);

			timer.Start(1f);
		}

		private void AddImage(string imageName, int x)
		{
			AddItem(new Image(Content.Load<Texture2D>(imageName))
			{
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top,
				FillRect = true,
				Position = new Point(x, 0),
				Size = new Vector2(64, 64),
			});
		}

		public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
		{
			base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

			timer.Update(gameTime);
			if (!timer.HasTimeRemaining && IsActive)
			{
				ScreenManager.ClearScreens();
				LoadingScreen.Load(ScreenManager, new MainMenuScreen());
			}
		}
	}
}
