// Plain data model for a single travel tip card

namespace TravelGuide.Models
{
    public class TravelTip
    {
        //Emoji icon displayed in the left badge square
        public string Icon { get; set; } = "💡";

        //Bold tip title
        public string Title { get; set; } = string.Empty;

        //Explanatory sentence shown in muted text
        public string Description { get; set; } = string.Empty;
    }
}
