
using System.Windows.Input;

using WordBank.DataAccess;
using WordBank.Models;

namespace WordBank.ViewModels
{
    public class WordsAddViewModel : BaseViewModel, IQueryAttributable
    {
        private WordBankBaseContext _wordbankBaseContext;
        private Word _wordValue;
        private string _applyName;
        private bool AddMode;

        public Word WordValue  {get => _wordValue; set => SetProperty(ref _wordValue, value); }

        public string ApplyName { get => _applyName; set => SetProperty (ref _applyName, value); }

        public ICommand OnAcceptCommand { private set; get; }
        public ICommand OnCancelCommand { private set; get; }
         
        public WordsAddViewModel(WordBankBaseContext wordbankBaseContext)
        {
            _wordbankBaseContext = wordbankBaseContext;
            OnAcceptCommand = new Command(OnAccept);
            OnCancelCommand = new Command(OnCancel);
        }

        void OnAccept()
        {
            if (AddMode)
            {   
                WordValue.Time = DateTime.Now;
                _wordbankBaseContext.Words.Add(WordValue);
            }
            _wordbankBaseContext.SaveChanges();
            Shell.Current.Navigation.PopAsync();
        }

        void OnCancel()
        {
            Shell.Current.Navigation.PopAsync();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Word", out var queryValue))
            {
                WordValue = queryValue as Word;
                ApplyName = "Apply";
                AddMode = false;
            }
            else
            {
                WordValue = new Word();
                AddMode = true;
                ApplyName = "Add";
            }
        }
    }
}
