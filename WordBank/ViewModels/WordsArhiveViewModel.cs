using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

using WordBank.DataAccess;
using WordBank.Models;
using WordBank.Views;

namespace WordBank.ViewModels
{
    public partial class WordsArhiveViewModel : BaseViewModel
    {
        private WordBankBaseContext _wordbankBaseContext;
                private ObservableCollection<WordsGroup> _wordsList;
        public ObservableCollection<WordsGroup> WordsList
        {
            get => _wordsList;
            set => SetProperty(ref _wordsList, value);
        }
        
        public ICommand DeleteCommand { private set; get; }
         
        private bool CanToggled{ get; set; }

        public WordsArhiveViewModel(WordBankBaseContext wordbankBaseContext)
        {
            _wordbankBaseContext = wordbankBaseContext;
                      
            DeleteCommand = new Command<Word>(DeleteExecute);
        }

        
        
        public override async void OnNavigatedTo()
        { 
            CanToggled= false;
            base.OnNavigatedTo();
            var groups = _wordbankBaseContext.Words.Where(t => t.Done).OrderByDescending(w => w.Time).ToList().
                GroupBy(_ => _.Time.Date).
                Select(g => new WordsGroup(g.Key, g.ToList()));
            WordsList = new ObservableCollection<WordsGroup>(groups);
             CanToggled = true;
        }
        
        private void DeleteExecute(Word word)
        {
                        var group = WordsList.FirstOrDefault(w => w.Time == word.Time.Date);
            group.Remove(word);
            if (group.Count == 0) WordsList.Remove(group);
                        _wordbankBaseContext.Words.Remove(word);
            _wordbankBaseContext.SaveChanges();
        }

        [RelayCommand(CanExecute = nameof(CanToggled))]
        private  void OnToggled(object sender)
        {
            if (sender is Word word)
            {
                _wordbankBaseContext.SaveChanges();
                if (!word.Done)
                {
                    IDispatcherTimer timer = App.Current.Dispatcher.CreateTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(50);
                    timer.IsRepeating = false;
                    timer.Tick += (s, e) =>
                    {
                        var group = WordsList.FirstOrDefault(w => w.Time == word.Time.Date);
                        if (group != null)
                        {
                            group.Remove(word);
                            if (group.Count == 0) WordsList.Remove(group);
                        }
                                            };
                    timer.Start();
                }
            }
        }
    }
}
