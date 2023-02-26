using WordBank.ViewModels;

namespace WordBank.Views
{
    public partial class MainPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
