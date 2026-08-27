// provides the static list of travel tips for the tips tab
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TravelGuide.Models;

namespace TravelGuide.ViewModels
{
    public class TipsViewModel : ObservableObject
    {
        public ObservableCollection<TravelTip> Tips { get; } = new()
        {
            new TravelTip
            {
                Icon        = "🎒",
                Title       = "Pack Light, Travel Far",
                Description = "Bring versatile clothing that layers well. A capsule wardrobe of 7-10 pieces covers most trips."
            },
            new TravelTip
            {
                Icon        = "💰",
                Title       = "Budget Like a Local",
                Description = "Use local markets for meals and transit apps for getting around. Your wallet will thank you."
            },
            new TravelTip
            {
                Icon        = "🛡️",
                Title       = "Stay Safe Abroad",
                Description = "Keep digital copies of documents, share your itinerary with someone back home, and trust your instincts."
            },
            new TravelTip
            {
                Icon        = "🍽️",
                Title       = "Eat Where Locals Eat",
                Description = "Skip tourist-trap restaurants. Street food stalls and family-run spots serve the most authentic flavours."
            },
            new TravelTip
            {
                Icon        = "🗣️",
                Title       = "Learn Key Phrases",
                Description = "Even a simple 'hello' and 'thank you' in the local language opens doors and hearts everywhere."
            },
            new TravelTip
            {
                Icon        = "📶",
                Title       = "Stay Connected",
                Description = "Get a local SIM or eSIM on arrival. Offline maps are a lifesaver in areas with weak signal."
            },
            new TravelTip
            {
                Icon        = "📷",
                Title       = "Capture Memories",
                Description = "Golden hour is your best friend. Shoot at sunrise or sunset for photos that truly glow."
            },
            new TravelTip
            {
                Icon        = "⏰",
                Title       = "Slow Down",
                Description = "Don't over-schedule. Leave room for spontaneous discoveries — the best moments are often unplanned."
            },
        };
    }
}
