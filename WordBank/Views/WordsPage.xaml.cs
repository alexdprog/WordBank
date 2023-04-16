using CommunityToolkit.Maui.Views;
using WordBank.ViewModels;

namespace WordBank.Views
{
    public partial class WordsPage : ContentPage
    {
        public WordsViewModel ViewModel => (WordsViewModel)BindingContext;

        public WordsPage(WordsViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            Task.Run(async () => await ViewModel.OnNavigatedTo());
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
