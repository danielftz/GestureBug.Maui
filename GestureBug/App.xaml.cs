namespace GestureBug;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new BugPage();
	}
}
