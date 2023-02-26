using System.Collections.ObjectModel;

namespace WordBank.Models
{

    public class WordsGroup : ObservableCollection<Word>
    {
        public DateTime Time;
        public string Name { get => Time.ToString("m"); }
        public WordsGroup(DateTime time, List<Word> words) : base(words)
        {
            Time = time;
        }
    }
}

