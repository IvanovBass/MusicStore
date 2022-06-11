using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicStore.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string nom;
        private string artiste;
        private string annee;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nom)
                && !String.IsNullOrWhiteSpace(artiste)
                && !String.IsNullOrWhiteSpace(annee);
        }

        public string Nom
        {
            get => nom;
            set => SetProperty(ref nom, value);
        }

        public string Artiste
        {
            get => artiste;
            set => SetProperty(ref artiste, value);
        }
        public string Annee
        {
            get => annee;
            set => SetProperty(ref annee, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            int AnneeInt = int.Parse(Annee);
            
            Item newItem = new Item()
            {
                Id = null,
                Nom = Nom,
                Artiste = Artiste,
                Annee = AnneeInt
            };
   
            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

    }
}
