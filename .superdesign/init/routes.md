# Routes

The application uses .NET MAUI Shell rather than URL routing.

| Shell route | Entry view | Shared layout |
|---|---|---|
| `HomePage` | `Views/HomePage.xaml` | `AppShell.xaml` bottom TabBar |
| `DestinationsPage` | `Views/DestinationsPage.xaml` | `AppShell.xaml` bottom TabBar |
| `TipsPage` | `Views/TipsPage.xaml` | `AppShell.xaml` bottom TabBar |
| Detail navigation | `Views/DestinationDetailPage.xaml` | pushed page; shell navbar hidden |

Home is the discovery entry point. Destinations is an image-card catalogue. Destination Detail is an image-led reading view. Tips is practical travel advice.

## Full router configuration: `AppShell.xaml`

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<Shell
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:views="clr-namespace:TravelGuide.Views"
    x:Class="TravelGuide.AppShell"

   
    Shell.TabBarBackgroundColor="{AppThemeBinding Light={StaticResource BackgroundColor}, Dark={StaticResource BackgroundColorDark}}"
    Shell.TabBarForegroundColor="{StaticResource PrimaryColor}"
    Shell.TabBarTitleColor="{StaticResource PrimaryColor}"
    Shell.TabBarUnselectedColor="{AppThemeBinding Light={StaticResource Gray400}, Dark={StaticResource Gray600}}">

    <TabBar>

        <!-- Home tab -->
        <ShellContent
            Title="Home"
            ContentTemplate="{DataTemplate views:HomePage}"
            Route="HomePage">
            <ShellContent.Icon>
                <FontImageSource
                    FontFamily="OpenSansRegular"
                    Glyph="🏠"
                    Color="{StaticResource PrimaryColor}"
                    Size="22" />
            </ShellContent.Icon>
        </ShellContent>

        <!-- Destinations tab -->
        <ShellContent
            Title="Destinations"
            ContentTemplate="{DataTemplate views:DestinationsPage}"
            Route="DestinationsPage">
            <ShellContent.Icon>
                <FontImageSource
                    FontFamily="OpenSansRegular"
                    Glyph="📍"
                    Color="{StaticResource PrimaryColor}"
                    Size="22" />
            </ShellContent.Icon>
        </ShellContent>

        <!-- Tips tab -->
        <ShellContent
            Title="Tips"
            ContentTemplate="{DataTemplate views:TipsPage}"
            Route="TipsPage">
            <ShellContent.Icon>
                <FontImageSource
                    FontFamily="OpenSansRegular"
                    Glyph="💡"
                    Color="{StaticResource PrimaryColor}"
                    Size="22" />
            </ShellContent.Icon>
        </ShellContent>

    </TabBar>
</Shell>
```

