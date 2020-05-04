using GameTimer;
using InputHelper;
using MenuBuddy;
using Microsoft.Xna.Framework;
using ResolutionBuddy;
using System.Threading.Tasks;

namespace DesktopGLBug
{
	public class MainMenuScreen : WidgetScreen, IMainMenu
	{
		CountdownTimer timer = new CountdownTimer();

		public MainMenuScreen() : base("Main Screen")
		{
		}

		public override async Task LoadContent()
		{
			await base.LoadContent();

			var label = new Label("Main screen", Content)
			{
				Horizontal = HorizontalAlignment.Center,
				Vertical = VerticalAlignment.Center,
				Position = Resolution.ScreenArea.Center
			};
			AddItem(label);

			timer.Start(1f);
		}

		public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
		{
			base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

			timer.Update(gameTime);
			if (!timer.HasTimeRemaining && IsActive)
			{
				ScreenManager.ClearScreens();
				LoadingScreen.Load(ScreenManager, new ColorScreen());
			}
		}
	}
}