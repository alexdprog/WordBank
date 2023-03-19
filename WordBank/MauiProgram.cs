using CommunityToolkit.Maui;

using WordBank.DataAccess;
using WordBank.ViewModels;
using WordBank.Views;

namespace WordBank;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder()
#if DEBUG
								.UseMauiCommunityToolkit()
#else
								.UseMauiCommunityToolkit(options =>
								{
									options.SetShouldSuppressExceptionsInConverters(false);
									options.SetShouldSuppressExceptionsInBehaviors(false);
									options.SetShouldSuppressExceptionsInAnimations(false);
								})
#endif
		
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<WordBankBaseContext>();

        RegisterViewsAndViewModels(builder.Services);

		return builder.Build();
	}

	static void RegisterViewsAndViewModels(in IServiceCollection services)
	{
		services.AddSingleton<MainPageViewModel>();
		services.AddSingleton<MainPage>();
		services.AddSingleton<AboutPage>();
		services.AddSingleton<AboutViewModel>();
        services.AddSingleton<WordsViewModel>();
		services.AddSingleton<WordsPage>();
				services.AddSingleton<WordsArhiveViewModel>();
		services.AddSingleton<WordsArhivePage>();
		        services.AddSingleton<WordsAddViewModel>();
		services.AddSingleton<WordsAddPage>();
			}
}