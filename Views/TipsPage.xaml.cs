using TravelGuide.Helpers;

namespace TravelGuide.Views
{
    public partial class TipsPage : ContentPage
    {
        public TipsPage()
        {
            InitializeComponent();
        }

        private async void OnTipTapped(object sender, TappedEventArgs e)
        {
            var view = ViewInteraction.GestureView(sender);
            await ViewInteraction.AnimateTapAsync(view, 0.98, 80, 130);

            string title = e.Parameter?.ToString() ?? "this tip";
            await DisplayAlertAsync("💡 Great Tip!",
                $"\"{title}\" — bookmark this for your next adventure.", "Got it!");
        }
    }
}
