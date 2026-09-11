# Shared Layouts

## `AppShell.xaml`

Description: Root MAUI Shell with the shared three-item bottom tab bar.

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

## `App.xaml`

Description: Application root that merges global color and style dictionaries.

```xml
<?xml version="1.0" encoding="UTF-8" ?>

<Application
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="TravelGuide.App">

    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Resources/Styles/Colors.xaml" />
                <ResourceDictionary Source="Resources/Styles/Styles.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
    

</Application>
```

