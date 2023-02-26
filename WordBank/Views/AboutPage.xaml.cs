using CommunityToolkit.Maui.Views;
using WordBank.ViewModels;

namespace WordBank.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage(AboutViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}

