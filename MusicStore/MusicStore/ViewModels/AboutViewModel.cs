using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MusicStore.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "La discothèque de tonton Lulu";
        }

        public ICommand OpenWebCommand { get; }
    }
}