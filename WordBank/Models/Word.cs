
namespace WordBank.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.ComponentModel;

    [INotifyPropertyChanged]
    public partial class Word
    {
        private string _wordname;
        private string _description;
        private string _translation;
        private string _sample;
        private bool _done;
            public int WordId { get; set; }        public string WordName         {
            get => _wordname; 
            set => SetProperty(ref _wordname, value); 
        }         public string Description         {
            get => _description; 
            set => SetProperty(ref _description, value); 
        }         public string Translation         {
            get => _translation; 
            set => SetProperty(ref _translation, value); 
        }         public string Sample         {
            get => _sample; 
            set => SetProperty(ref _sample, value); 
        }         public DateTime Time { get; set; }        public bool Done         {
            get => _done; 
            set => SetProperty(ref _done, value); 
        }             private bool _expanded = false;
    [NotMapped]
    public bool Expanded { get => _expanded; set => SetProperty(ref _expanded, value); }
    [NotMapped]
    public ICommand OnExpand { get; set; }
    public Word()
    {
        OnExpand = new Command(onExpand);
    }

    void onExpand()
    {
        Expanded= !Expanded;
            
    }
        }

}
