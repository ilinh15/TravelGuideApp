using TravelGuide.Helpers;
using TravelGuide.ViewModels;
using TravelGuide.Views;

namespace TravelGuide.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnHeroImageTapped(object sender, TappedEventArgs e)
        {
            var image = ViewInteraction.GestureView(sender);
            await ViewInteraction.AnimateImageAcknowledgeAsync(image);
        }

        private void OnSearchPointerEntered(object sender, PointerEventArgs e)
        {
            _ = SearchCard.ScaleToAsync(1.02, 100, Easing.CubicOut);
        }

        private void OnSearchPointerExited(object sender, PointerEventArgs e)
        {
            _ = SearchCard.ScaleToAsync(1.0, 120, Easing.CubicOut);
        }

        private async void OnSearchCardTapped(object sender, TappedEventArgs e)
        {
            await ViewInteraction.AnimateTapAsync(SearchCard, 0.98, 80, 120);
        }

        private async void OnCategoryPillTapped(object sender, TappedEventArgs e)
        {
            var view = ViewInteraction.GestureView(sender);
            await ViewInteraction.AnimateTapAsync(view, 0.94, 70, 110);
            if (view is Frame frame
                && frame.BindingContext is CategoryItem item
                && BindingContext is HomeViewModel vm)
                vm.SelectCategoryCommand.Execute(item);
        }

        private async void OnStartExploringClicked(object sender, EventArgs e)
        {
            if (sender is Button btn)
                await ViewInteraction.AnimateTapAsync(btn, 0.95, 80, 100);
            await Shell.Current.GoToAsync("//DestinationsPage");
        }

        private async void OnSeeAllTapped(object sender, TappedEventArgs e)
        {
            var view = ViewInteraction.GestureView(sender);
            await ViewInteraction.AnimateTapAsync(view, 0.92, 60, 100);
            await Shell.Current.GoToAsync("//DestinationsPage");
        }

        private async void OnDestinationCardTapped(object sender, TappedEventArgs e)
        {
            var view = ViewInteraction.GestureView(sender);
            await ViewInteraction.AnimateTapAsync(view, 0.96, 85, 130);

            string name = e.Parameter?.ToString() ?? "this destination";

            //Bali and Kyoto should open a detail page (no alert)
            if (name.Equals("Bali", StringComparison.OrdinalIgnoreCase)
                || name.Equals("Kyoto", StringComparison.OrdinalIgnoreCase))
            {
                await Shell.Current.GoToAsync($"{nameof(DestinationDetailPage)}?name={Uri.EscapeDataString(name)}");
                return;
            }

            await DisplayAlertAsync("✈️ Let's Go!",
                $"You'd love {name}! Full details coming soon.", "Can't wait!");
        }
    }
}
