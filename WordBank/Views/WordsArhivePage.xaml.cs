using CommunityToolkit.Maui.Views;
using WordBank.ViewModels;

namespace WordBank.Views
{
    public partial class WordsArhivePage : ContentPage
    {
    	public new WordsArhiveViewModel ViewModel => (WordsArhiveViewModel)BindingContext;

        public WordsArhivePage(WordsArhiveViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            ViewModel.OnNavigatedTo();
        }
        
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (ViewModel.ToggledCommand.CanExecute(sender))
            {
                ViewModel.ToggledCommand.Execute(this);
            }
        }
    }
}
