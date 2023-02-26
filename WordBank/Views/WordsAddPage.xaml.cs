using WordBank.ViewModels;

namespace WordBank.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordsAddPage
    {
        public WordsAddPage(WordsAddViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
