using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WordBank.ViewModels
{
    [INotifyPropertyChanged]
    public abstract partial class BaseViewModel
    {
        /// <summary>
        /// Calls when Navigatet to page
        /// </summary>
        public virtual async void  OnNavigatedTo()
        {

        }
    }
}
