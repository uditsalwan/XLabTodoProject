using Xamarin.Forms;

namespace ToDoList
{
	public partial class App : Application
	{
		static DbHandler dbHandler;

		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new ToDoListPage());
		}

		public static DbHandler DatabaseHandler
		{
			get
			{
				if (dbHandler == null)
				{
					dbHandler = new DbHandler(DependencyService.Get<IFilePathHelper>().GetLocalFilePath(Constants.DB_NAME));
				}
				return dbHandler;
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
