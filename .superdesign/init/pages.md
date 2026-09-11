# Key Pages and Dependencies

## Home
Entry: `Views/HomePage.xaml`

Dependencies:
- `Views/HomePage.xaml.cs`
  - `Helper/ViewInteraction.cs`
  - `Views/DestinationDetailPage.xaml`
- `ViewModels/HomeViewModel.cs`
  - `Models/Destination.cs`
- `Resources/Styles/Colors.xaml`
- `Resources/Styles/Styles.xaml`
- `AppShell.xaml`
- Images: `homepage_background.jpg`, `bali.jpg`, `kyoto.jpg`, `marrakesh.jpg`

## Destinations
Entry: `Views/DestinationsPage.xaml`

Dependencies:
- `Views/DestinationsPage.xaml.cs`
  - `Helper/ViewInteraction.cs`
  - `Views/DestinationDetailPage.xaml`
- `ViewModels/DestinationsViewModel.cs`
  - `Models/Destination.cs`
- `Resources/Styles/Colors.xaml`
- `Resources/Styles/Styles.xaml`
- `AppShell.xaml`
- Images: `kyoto_temples.jpg`, `rice_terrace.jpg`, `machu_picchu.jpg`, `marrakech_souk.jpg`, `patagonia.jpg`

## Destination Detail
Entry: `Views/DestinationDetailPage.xaml`

Dependencies:
- `Views/DestinationDetailPage.xaml.cs`
  - `Models/Destination.cs`
- `Resources/Styles/Colors.xaml`
- `Resources/Styles/Styles.xaml`

## Tips
Entry: `Views/TipsPage.xaml`

Dependencies:
- `Views/TipsPage.xaml.cs`
  - `Helper/ViewInteraction.cs`
- `ViewModels/TipsViewModel.cs`
  - `Models/TravelTip.cs`
- `Resources/Styles/Colors.xaml`
- `Resources/Styles/Styles.xaml`
- `AppShell.xaml`

