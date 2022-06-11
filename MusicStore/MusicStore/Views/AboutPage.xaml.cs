using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicStore.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            labelDiscotheque.Focused += LabelDiscotheque_Focused;
        }

        private void LabelDiscotheque_Focused(object sender, FocusEventArgs e)
        {
            if (labelDiscotheque.IsFocused)
            {
                labelDiscotheque.ScaleTo(1.3, 500);
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            labelDiscotheque.RotateTo(1440, 4000, Easing.SinInOut);
        }
    }
}