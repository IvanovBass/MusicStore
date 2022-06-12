using System;

namespace MusicStore.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Nom { get; set; }

        public string Artiste { get; set; }
        public int Annee { get; set; }

        public bool Count()
        {
            throw new NotImplementedException();
        }
    }
}