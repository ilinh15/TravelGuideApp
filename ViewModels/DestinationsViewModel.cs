using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TravelGuide.Models;

namespace TravelGuide.ViewModels
{
    public partial class DestinationsViewModel : ObservableObject
    {
        public ObservableCollection<DestinationCardItem> Destinations { get; } = new()
        {
            new DestinationCardItem
            {
                Name             = "Kyoto Temples",
                Location         = "Kyoto, Japan",
                Description      = "Ancient temples surrounded by cherry blossoms, zen gardens, and centuries of spiritual tradition.",
                Rating           = 5,
                PlaceholderColor = "#7B6F5E",
                HeroImage        = "kyoto_temples.jpg"
            },
            new DestinationCardItem
            {
                Name             = "Rice Terraces",
                Location         = "Ubud, Bali",
                Description      = "Emerald rice paddies cascading down misty hillsides, a living masterpiece of agriculture and nature.",
                Rating           = 5,
                PlaceholderColor = "#4A7C59",
                HeroImage        = "rice_terrace.jpg"
            },
            new DestinationCardItem
            {
                Name             = "Machu Picchu",
                Location         = "Cusco, Peru",
                Description      = "The lost city of the Incas, perched high in the Andes among swirling clouds and ancient mystery.",
                Rating           = 5,
                PlaceholderColor = "#6B8E6E",
                HeroImage        = "machu_picchu.jpg"
            },
            new DestinationCardItem
            {
                Name             = "Marrakech Souks",
                Location         = "Marrakech, Morocco",
                Description      = "Vibrant markets bursting with spices, lanterns, and the intoxicating energy of Moroccan culture.",
                Rating           = 4,
                PlaceholderColor = "#C4854E",
                HeroImage        = "marrakech_souk.jpg"
            },
            new DestinationCardItem
            {
                Name             = "Patagonia Wilderness",
                Location         = "Patagonia, Argentina",
                Description      = "Turquoise glacial lakes beneath jagged peaks — nature at its most dramatic and untamed.",
                Rating           = 5,
                PlaceholderColor = "#4A6FA5",
                HeroImage        = "patagonia.jpg"
            },
        };

    
        [RelayCommand]
        private void ToggleFavourite(DestinationCardItem item)
        {
            item.IsFavourite = !item.IsFavourite;
        }
    }

    public partial class DestinationCardItem : ObservableObject
    {
        public string Name             { get; set; } = string.Empty;
        public string Location         { get; set; } = string.Empty;
        public string Description      { get; set; } = string.Empty;
        public int    Rating           { get; set; }
        public string PlaceholderColor { get; set; } = "#8C7E73";
        
        public string HeroImage        { get; set; } = string.Empty;

        [ObservableProperty]
        private bool isFavourite;

      
        public string HeartIcon => IsFavourite ? "♥" : "♡";

        public Color HeartColor => IsFavourite
            ? Color.FromArgb("#D4764E")
            : Color.FromArgb("#CCFFFFFF");

     
        public List<string> Stars => Enumerable
            .Range(1, 5)
            .Select(i => i <= Rating ? "★" : "☆")
            .ToList();

        partial void OnIsFavouriteChanged(bool value)
        {
            OnPropertyChanged(nameof(HeartIcon));
            OnPropertyChanged(nameof(HeartColor));
        }
    }
}
