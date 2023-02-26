using WordBank.Views;
namespace WordBank;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(WordsPage), typeof(WordsPage));
		Routing.RegisterRoute(nameof(WordsAddPage), typeof(WordsAddPage));
				}
}
