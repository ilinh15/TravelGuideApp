using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TravelGuide.Models;

namespace TravelGuide.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly IReadOnlyList<Destination> _allPopular = new List<Destination>
        {
            new Destination
            {
                Name             = "Kyoto",
                Location         = "Japan",
                PlaceholderColor = "#7B6F5E",
                HeroImage        = "kyoto.jpg"
            },
            new Destination
            {
                Name             = "Bali",
                Location         = "Indonesia",
                PlaceholderColor = "#4A7C59",
                HeroImage        = "bali.jpg"
            },
            new Destination
            {
                Name             = "Marrakech",
                Location         = "Morocco",
                PlaceholderColor = "#C4854E",
                HeroImage        = "marrakesh.jpg"
            },
        };

        public HomeViewModel()
        {
            // Ensure the initial selected pill (Beach) maps to the requested single destination.
            ApplyCategoryToPopular("Beach");
        }

        //Category pills 
        public ObservableCollection<CategoryItem> Categories { get; } = new()
        {
            new CategoryItem { Label = "Beach",     IsSelected = true  },
            new CategoryItem { Label = "Mountains", IsSelected = false },
            new CategoryItem { Label = "Culture",   IsSelected = false },
            new CategoryItem { Label = "Adventure", IsSelected = false },
        };

       
        /* Called when the user taps a category pill
        Deselects all others and selects the tapped one so the terracotta
        highlight moves correctly.*/
       
        [RelayCommand]
        private void SelectCatey(CategoryItem selected)
        {
            foreach (var cat in Categories)
                cat.IsSelected = cat == selected;

            ApplyCategoryToPopular(selected.Label);
        }

        //Popular destinations

        public ObservableCollection<Destination> PopularDestinations { get; } = new()
        { };

        private void ApplyCategoryToPopular(string categoryLabel)
        {
            string targetName = categoryLabel switch
            {
                "Beach" => "Bali",
                "Mountains" => "Kyoto",
                "Culture" => "Marrakech",
                "Adventure" => "Bali",
                _ => "Bali",
            };

            var match = _allPopular.FirstOrDefault(d => d.Name == targetName);
            if (match is null)
                return;

            PopularDestinations.Clear();
            PopularDestinations.Add(match);
        }
    }

    // Nested helper class 

   
    // Represents a single category pill. Inherits ObservableObject so the UI reacts instantly when IsSelected is toggled.
    
    public partial class CategoryItem : ObservableObject
    {
        public string Label { get; set; } = string.Empty;

        [ObservableProperty]
        private bool isSelected;
    }
}
