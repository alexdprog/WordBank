using CommunityToolkit.Maui.Views;
using WordBank.ViewModels;

namespace WordBank.Views
{
    public partial class WordsPage : ContentPage
    {
    	public new WordsViewModel ViewModel => (WordsViewModel)BindingContext;

        public WordsPage(WordsViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            ViewModel.OnNavigatedTo();
        }
    }
}
