using TravelGuide.Views;

namespace TravelGuide
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DestinationDetailPage), typeof(DestinationDetailPage));
        }
    }
}
