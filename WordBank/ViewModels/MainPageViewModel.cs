using System.Windows.Input;

namespace WordBank.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { get; set; }

        public string ProjectName { get; set; }

        public MainPageViewModel()
            : base()
        {
            ProjectName = "WordBank";
            NavigateCommand = new Command<string>(Navigate);
        }

        async void Navigate(string pageName)
        {
           await Shell.Current.GoToAsync("//" + pageName);
        }
    }
}
