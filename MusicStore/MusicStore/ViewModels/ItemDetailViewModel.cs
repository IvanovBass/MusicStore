using MusicStore.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicStore.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string nom;
        private string artiste;
        private int annee;
        public Command UpdateCommand { get; }
        public Command DeleteCommand { get; }
        public ItemDetailViewModel()
        {
            UpdateCommand = new Command(UpdateItem);
            DeleteCommand = new Command(DeleteItem);    
        }

        public string Id { get; set; }

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

        public int Annee
        {
            get => annee;
            set => SetProperty(ref annee, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Nom = item.Nom;
                Artiste = item.Artiste;
                Annee = item.Annee;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public async void UpdateItem()
        {
            try
            {
                Item albumModif = new Item
                {
                    Id = ItemId,
                    Nom = Nom,
                    Artiste = Artiste,
                    Annee = Annee
                };
                await DataStore.UpdateItemAsync(albumModif);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Update Item");
            }
        }
        public async void DeleteItem()
        {
            try
            {
                await DataStore.DeleteItemAsync(ItemId);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Update Item");
            }
        }
    }
}
