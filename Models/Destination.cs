namespace TravelGuide.Models
{
    public class Destination
    {
        //Display name shown on the card heading
        public string Name { get; set; } = string.Empty;

        //City / country line shown beneath the name
        public string Location { get; set; } = string.Empty;

        //2 line description shown below the image
        public string Description { get; set; } = string.Empty;

        //Star rating out of 5
        public int Rating { get; set; }

        // Hex color kept for non-UI use or future fallbacks
        
        public string PlaceholderColor { get; set; } = "#8C7E73";

     
        // Filename of a bundled MAUI image under Resources/Images
        public string HeroImage { get; set; } = string.Empty;
    }
}
