using MusicStore.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using System;

namespace MusicStore.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

        }
    }
}