# Extractable Components

## BottomTabNavigation
- Source: `AppShell.xaml`
- Category: layout
- Description: Shared bottom navigation for Home, Destinations, and Tips.
- Extractable props: activeItem (string, default: "home")
- Hardcoded: labels, route meanings, icons and visual treatment

## SearchPanel
- Source: `Views/HomePage.xaml`
- Category: basic
- Description: Elevated destination search field floating below the immersive hero.
- Extractable props: placeholder (string, default: "Where do you want to go?")
- Hardcoded: search icon, surface, rounded shape and shadow

## CategoryChipRow
- Source: `Views/HomePage.xaml`
- Category: basic
- Description: Horizontally scrollable destination-type filters.
- Extractable props: activeItem (string, default: "Beach")
- Hardcoded: chip labels and selected/unselected treatments

## DestinationCard
- Source: `Views/HomePage.xaml` and `Views/DestinationsPage.xaml`
- Category: basic
- Description: Image-led destination card with overlay, metadata, and optional favourite action.
- Extractable props: isFavourite (boolean, default: false), showFavourite (boolean, default: true)
- Hardcoded: image crop, icons, overlay gradient and radius

## TipCard
- Source: `Views/TipsPage.xaml`
- Category: basic
- Description: Compact advice row with icon badge, title, and copy.
- Extractable props: none
- Hardcoded: icon position, typography and spacing

Only `BottomTabNavigation` is a true shared layout component today; the remaining patterns are page-local compositions suitable for consolidation during implementation.

