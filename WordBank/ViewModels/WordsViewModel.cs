using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;

using Microsoft.EntityFrameworkCore;

using WordBank.DataAccess;
using WordBank.Models;
using WordBank.Views;

namespace WordBank.ViewModels
{
    public class WordsViewModel : BaseViewModel
    {
        private WordBankBaseContext _wordbankBaseContext;
                private ObservableCollection<WordsGroup> _wordsList;
        public ObservableCollection<WordsGroup> WordsList
        {
            get => _wordsList;
            set => SetProperty(ref _wordsList, value);
        }
        
        public ICommand AddCommand { private set; get; }

        public ICommand EditCommand { private set; get; }

        public ICommand DeleteCommand { private set; get; }
         
        public WordsViewModel(WordBankBaseContext wordbankBaseContext)
        {
            _wordbankBaseContext = wordbankBaseContext;
                        AddCommand = new Command(AddExecute);
            EditCommand = new Command<Word>(EditExecute);
            DeleteCommand = new Command<Word>(DeleteExecute);
        }

        async void AddExecute()
        {
            await Shell.Current.GoToAsync(nameof(WordsAddPage));
        }

        async void EditExecute(Word word)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Word", word }
            };
            await Shell.Current.GoToAsync(nameof(WordsAddPage), navigationParameter);
        }

        
        public override async void OnNavigatedTo()
        {
            base.OnNavigatedTo();
            var groups = _wordbankBaseContext.Words.OrderByDescending(w => w.Time).ToList().
                GroupBy(_ => _.Time.Date).
                Select(g => new WordsGroup(g.Key, g.ToList()));
            WordsList = new ObservableCollection<WordsGroup>(groups);
                    }
        
        private void DeleteExecute(Word word)
        {
                        var group = WordsList.FirstOrDefault(w => w.Time == word.Time.Date);
            group.Remove(word);
            if (group.Count == 0) WordsList.Remove(group);
                        _wordbankBaseContext.Words.Remove(word);
            _wordbankBaseContext.SaveChanges();
        }
    }
}
