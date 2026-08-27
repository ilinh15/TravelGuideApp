using TravelGuide.Helpers;
using TravelGuide.ViewModels;
using TravelGuide.Views;

namespace TravelGuide.Views
{
    public partial class DestinationsPage : ContentPage
    {
        public DestinationsPage()
        {
            InitializeComponent();
        }

        private async void OnHeartTapped(object sender, TappedEventArgs e)
        {
            var gestureView = ViewInteraction.GestureView(sender);
            if (gestureView is Label lbl && lbl.Parent is Frame heartFrame)
                await ViewInteraction.AnimateTapAsync(heartFrame, 0.88, 70, 120);

            var item =
                (sender as BindableObject)?.BindingContext as DestinationCardItem
                ?? gestureView?.BindingContext as DestinationCardItem;

            if (item is null)
                return;

            if (BindingContext is DestinationsViewModel vm && vm.ToggleFavouriteCommand.CanExecute(item))
                vm.ToggleFavouriteCommand.Execute(item);
        }

        private async void OnCardTapped(object sender, TappedEventArgs e)
        {
            var view = ViewInteraction.GestureView(sender);
            await ViewInteraction.AnimateTapAsync(view, 0.98, 85, 140);

            string name = e.Parameter?.ToString() ?? "this destination";

            //Kyoto Temples should open the Kyoto detail content with no alert messages
            if (name.Equals("Kyoto Temples", StringComparison.OrdinalIgnoreCase))
            {
                await Shell.Current.GoToAsync($"{nameof(DestinationDetailPage)}?name={Uri.EscapeDataString(name)}");
                return;
            }

            await DisplayAlertAsync("🌍 Destination Info",
                $"{name} — full travel guide coming soon!", "Exciting!");
        }
    }
}
