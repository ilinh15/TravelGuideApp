using TravelGuide.Helpers;

namespace TravelGuide.Views
{
    [QueryProperty(nameof(Name), "name")]
    public partial class DestinationDetailPage : ContentPage
    {
        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set
            {
                _name = value ?? string.Empty;
                ApplyContent(_name);
            }
        }

        public DestinationDetailPage()
        {
            InitializeComponent();
        }

        private void ApplyContent(string name)
        {
            var key = (name ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(key))
                key = "Destination";

            // Kyoto and Kyoto Temples share the same detail content 
            bool isKyoto = key.Equals("Kyoto", StringComparison.OrdinalIgnoreCase)
                || key.Equals("Kyoto Temples", StringComparison.OrdinalIgnoreCase);

            if (key.Equals("Bali", StringComparison.OrdinalIgnoreCase))
            {
                TitleLabel.Text = "Bali";
                HeroImage.Source = "bali2.jpg";
                Para1Label.Text =
                    "Bali is a tropical escape where emerald rice terraces, volcanic peaks, and sunlit coastlines meet a rich island culture. " +
                    "From calm mornings in Ubud to golden-hour walks along the beach, the island feels both relaxing and endlessly alive.";
                Para2Label.Text =
                    "Spend your days exploring waterfalls and temples, tasting local food in night markets, and unwinding in seaside cafés. " +
                    "Whether you’re chasing surf, nature, or quiet wellness moments, Bali offers a warm, welcoming rhythm that’s easy to fall into.";
                return;
            }

            if (isKyoto)
            {
                TitleLabel.Text = "Kyoto";
                HeroImage.Source = "kyoto2.jpg";
                Para1Label.Text =
                    "Kyoto is Japan’s timeless heart — a city of wooden lanes, serene gardens, and temples that glow softly through changing seasons. " +
                    "It’s a place where tradition is everywhere, from the scent of incense at shrines to lantern-lit evenings in historic districts.";
                Para2Label.Text =
                    "Wander through quiet temple grounds, pause beside koi ponds, and sip matcha in small teahouses tucked away from the crowds. " +
                    "Kyoto rewards slow travel: the more gently you explore, the more beauty you’ll notice in every detail.";
                return;
            }

            // Fallback for other destinations 
            TitleLabel.Text = key;
            HeroImage.Source = string.Empty;
            Para1Label.Text = $"{key} — details coming soon.";
            Para2Label.Text = "Explore more destinations from the Home and Destinations tabs.";
        }

        private async void OnBackTapped(object sender, TappedEventArgs e)
        {
            await ViewInteraction.AnimateTapAsync(BackFrame, 0.96, 80, 140);
            await Shell.Current.GoToAsync("..");
        }
    }
}

