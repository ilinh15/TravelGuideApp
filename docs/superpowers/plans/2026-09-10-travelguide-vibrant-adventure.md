# TravelGuide Vibrant Adventure Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Redesign all four TravelGuide MAUI screens into the approved mobile-first Vibrant Adventure showcase with centralized styling, photographic layouts, custom navigation, and polished cancellable motion.

**Architecture:** Keep the existing .NET 10 MAUI Shell and static MVVM state, but hide the native Shell tab bar and render a reusable floating navigation control on the three root pages. Centralize visual tokens in XAML resources, keep content/state in ViewModels, and route all short interaction animations through one helper. Validate pure state with a lightweight linked-source xUnit project and validate XAML/platform integration with MacCatalyst builds and live interaction checks.

**Tech Stack:** .NET 10, .NET MAUI XAML, CommunityToolkit.Mvvm 8.4.2, xUnit, MacCatalyst

**Spec:** `docs/superpowers/specs/2026-09-10-travelguide-vibrant-adventure-design.md`

## Global Constraints

- Product name remains **TravelGuide**.
- Visual direction is **Vibrant Adventure**.
- Use mobile-first adaptive layouts and support the larger MacCatalyst window.
- Implement light mode only.
- Preserve Home, Destinations, Destination Detail, and Tips.
- Keep static MVVM state; do not add backend, authentication, maps, booking, persistence, or network search.
- Use only the approved teal/coral/seafoam/mint/warm-white palette.
- Use bundled Open Sans fonts; do not use Georgia or another serif.
- Replace every app-owned `Frame` with `Border`.
- Keep touch targets at least 44 by 44 points.
- Do not communicate selection through color alone.
- Motion lasts roughly 160–520 ms, is cancellable, and never loops indefinitely.
- Keep at least 28–36 points of visual separation between the complete Home hero-copy block and the search panel.

---

## File Structure

### Create

- `Controls/FloatingTabBar.xaml` — reusable three-item floating navigation capsule.
- `Controls/FloatingTabBar.xaml.cs` — active-route styling, tap guards, and Shell navigation.
- `ViewModels/DestinationDetailViewModel.cs` — detail-page content and route-driven state.
- `TravelGuideApp.Tests/TravelGuideApp.Tests.csproj` — pure linked-source ViewModel test project.
- `TravelGuideApp.Tests/HomeViewModelTests.cs` — category/content behavior tests.
- `TravelGuideApp.Tests/DestinationsViewModelTests.cs` — favourite-state tests.
- `TravelGuideApp.Tests/DestinationDetailViewModelTests.cs` — detail content/fallback tests.
- `TravelGuideApp.Tests/TipsViewModelTests.cs` — redesigned tips-content tests.

### Modify

- `TravelGuideApp.slnx` — include the test project.
- `App.xaml` — merge the shared component style dictionary if it is split.
- `AppShell.xaml` — retain routes while hiding the native tab bar chrome.
- `MauiProgram.cs` — register pages/ViewModels only if constructor injection is adopted.
- `Resources/Styles/Colors.xaml` — approved palette and semantic brushes.
- `Resources/Styles/Styles.xaml` — typography, Border, chip, card, button, and icon styles.
- `Resources/AppIcon/appicon.svg` — teal/coral TravelGuide mark treatment.
- `Resources/AppIcon/appiconfg.svg` — foreground mark color treatment.
- `Resources/Splash/splash.svg` — matching minimal launch mark.
- `TravelGuideApp.csproj` — update icon/splash colors and XAML registrations if required.
- `Models/Destination.cs` — showcase metadata used by Home cards.
- `Models/TravelTip.cs` — semantic icon key and featured-card state.
- `ViewModels/HomeViewModel.cs` — revised categories and destination content.
- `ViewModels/DestinationsViewModel.cs` — revised catalogue metadata and bindable color values.
- `ViewModels/TipsViewModel.cs` — revised tip content.
- `Helper/ViewInteraction.cs` — cancellable entrance, press, favourite, and page motion.
- `Views/HomePage.xaml` and `Views/HomePage.xaml.cs` — approved Home v4.
- `Views/DestinationsPage.xaml` and `Views/DestinationsPage.xaml.cs` — editorial catalogue.
- `Views/DestinationDetailPage.xaml` and `Views/DestinationDetailPage.xaml.cs` — cinematic hero and rising sheet.
- `Views/TipsPage.xaml` and `Views/TipsPage.xaml.cs` — compact advice layout.

---

### Task 1: Add Pure State Tests and Finalize Showcase Data Contracts

**Files:**
- Create: `TravelGuideApp.Tests/TravelGuideApp.Tests.csproj`
- Create: `TravelGuideApp.Tests/HomeViewModelTests.cs`
- Create: `TravelGuideApp.Tests/DestinationsViewModelTests.cs`
- Create: `TravelGuideApp.Tests/DestinationDetailViewModelTests.cs`
- Create: `TravelGuideApp.Tests/TipsViewModelTests.cs`
- Create: `ViewModels/DestinationDetailViewModel.cs`
- Modify: `TravelGuideApp.slnx`
- Modify: `Models/Destination.cs`
- Modify: `Models/TravelTip.cs`
- Modify: `ViewModels/HomeViewModel.cs`
- Modify: `ViewModels/DestinationsViewModel.cs`
- Modify: `ViewModels/TipsViewModel.cs`

**Interfaces:**
- Produces: `Destination.Tagline`, `Destination.Season`, `Destination.RatingText`
- Produces: `TravelTip.IconKey`, `TravelTip.IsFeatured`
- Produces: `DestinationCardItem.Season`, `DestinationCardItem.Eyebrow`, `DestinationCardItem.HeartColorHex`
- Produces: `DestinationDetailViewModel.Load(string name)` and observable `Title`, `Location`, `HeroImage`, `Description`, `SecondaryDescription`, `Season`, `Mood`

- [ ] **Step 1: Create the linked-source test project**

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="CommunityToolkit.Mvvm" Version="8.4.2" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.14.1" />
    <PackageReference Include="xunit" Version="2.9.3" />
    <PackageReference Include="xunit.runner.visualstudio" Version="3.1.5">
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>
  <ItemGroup>
    <Compile Include="../Models/Destination.cs" Link="Models/Destination.cs" />
    <Compile Include="../Models/TravelTip.cs" Link="Models/TravelTip.cs" />
    <Compile Include="../ViewModels/HomeViewModel.cs" Link="ViewModels/HomeViewModel.cs" />
    <Compile Include="../ViewModels/DestinationsViewModel.cs" Link="ViewModels/DestinationsViewModel.cs" />
    <Compile Include="../ViewModels/DestinationDetailViewModel.cs" Link="ViewModels/DestinationDetailViewModel.cs" />
    <Compile Include="../ViewModels/TipsViewModel.cs" Link="ViewModels/TipsViewModel.cs" />
  </ItemGroup>
</Project>
```

Add `<Project Path="TravelGuideApp.Tests/TravelGuideApp.Tests.csproj" />` to `TravelGuideApp.slnx`.

- [ ] **Step 2: Write failing ViewModel contract tests**

```csharp
using TravelGuide.ViewModels;

namespace TravelGuideApp.Tests;

public class HomeViewModelTests
{
    [Fact]
    public void StartsWithIslandLifeAndBali()
    {
        var vm = new HomeViewModel();
        Assert.Equal("Island life", Assert.Single(vm.Categories, x => x.IsSelected).Label);
        var card = Assert.Single(vm.PopularDestinations);
        Assert.Equal("Bali", card.Name);
        Assert.Equal("Best season · May–Oct", card.Season);
    }

    [Fact]
    public void SelectingWildEscapesShowsPatagonia()
    {
        var vm = new HomeViewModel();
        var category = vm.Categories.Single(x => x.Label == "Wild escapes");
        vm.SelectCategoryCommand.Execute(category);
        Assert.True(category.IsSelected);
        Assert.Equal("Patagonia", Assert.Single(vm.PopularDestinations).Name);
    }
}
```

```csharp
using TravelGuide.ViewModels;

namespace TravelGuideApp.Tests;

public class DestinationsViewModelTests
{
    [Fact]
    public void ToggleFavouriteChangesIconAndHexColor()
    {
        var vm = new DestinationsViewModel();
        var item = vm.Destinations[0];
        vm.ToggleFavouriteCommand.Execute(item);
        Assert.True(item.IsFavourite);
        Assert.Equal("♥", item.HeartIcon);
        Assert.Equal("#FF6B57", item.HeartColorHex);
    }
}
```

```csharp
using TravelGuide.ViewModels;

namespace TravelGuideApp.Tests;

public class DestinationDetailViewModelTests
{
    [Theory]
    [InlineData("Bali", "bali2.jpg", "Indonesia")]
    [InlineData("Kyoto Temples", "kyoto2.jpg", "Japan")]
    public void LoadKnownDestinationUsesCuratedContent(string name, string image, string location)
    {
        var vm = new DestinationDetailViewModel();
        vm.Load(name);
        Assert.Equal(image, vm.HeroImage);
        Assert.Contains(location, vm.Location);
        Assert.False(string.IsNullOrWhiteSpace(vm.Description));
    }

    [Fact]
    public void LoadUnknownDestinationUsesSafeFallback()
    {
        var vm = new DestinationDetailViewModel();
        vm.Load("Unknown");
        Assert.Equal("Unknown", vm.Title);
        Assert.Equal("homepage_background.jpg", vm.HeroImage);
        Assert.Contains("next story", vm.Description, StringComparison.OrdinalIgnoreCase);
    }
}
```

```csharp
using TravelGuide.ViewModels;

namespace TravelGuideApp.Tests;

public class TipsViewModelTests
{
    [Fact]
    public void TipsHaveSemanticIconsAndOneFeaturedItem()
    {
        var vm = new TipsViewModel();
        Assert.All(vm.Tips, tip => Assert.False(string.IsNullOrWhiteSpace(tip.IconKey)));
        Assert.Single(vm.Tips, tip => tip.IsFeatured);
    }
}
```

- [ ] **Step 3: Run tests and verify contract failures**

Run:

```bash
dotnet test TravelGuideApp.Tests/TravelGuideApp.Tests.csproj
```

Expected: compilation/test failures for the new properties, labels, detail ViewModel, and pure hex heart color.

- [ ] **Step 4: Implement the minimal pure data contracts**

```csharp
public class Destination
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Tagline { get; set; } = string.Empty;
    public string Season { get; set; } = string.Empty;
    public string RatingText { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string PlaceholderColor { get; set; } = "#073B3A";
    public string HeroImage { get; set; } = string.Empty;
}
```

Use these exact Home category mappings:

```csharp
"Island life"  => "Bali",
"Wild escapes" => "Patagonia",
"Culture"      => "Kyoto",
"Slow travel"  => "Marrakech"
```

Make `HeartColorHex` return `#FF6B57` when selected and `#FFFFFF` otherwise so the linked-source tests remain independent of MAUI `Color`.

Implement `DestinationDetailViewModel.Load` with curated Bali and Kyoto records and the specified fallback. Keep all user-facing paragraphs in the ViewModel rather than the page code-behind.

- [ ] **Step 5: Run the state tests**

```bash
dotnet test TravelGuideApp.Tests/TravelGuideApp.Tests.csproj
```

Expected: all tests pass.

- [ ] **Step 6: Commit the state foundation**

```bash
git add TravelGuideApp.slnx TravelGuideApp.Tests Models ViewModels
git commit -m "test: define vibrant travel content contracts"
```

---

### Task 2: Build the Theme, Shared Motion, and Floating Navigation

**Files:**
- Modify: `Resources/Styles/Colors.xaml`
- Modify: `Resources/Styles/Styles.xaml`
- Modify: `Helper/ViewInteraction.cs`
- Create: `Controls/FloatingTabBar.xaml`
- Create: `Controls/FloatingTabBar.xaml.cs`
- Modify: `AppShell.xaml`
- Modify: `TravelGuideApp.csproj`
- Modify: `Resources/AppIcon/appicon.svg`
- Modify: `Resources/AppIcon/appiconfg.svg`
- Modify: `Resources/Splash/splash.svg`

**Interfaces:**
- Consumes: root routes `//HomePage`, `//DestinationsPage`, `//TipsPage`
- Produces: semantic resources `DeepTeal`, `PrimaryTeal`, `Lagoon`, `Coral`, `Seafoam`, `MintMist`, `WarmWhite`, `Ink`, `SlateTeal`, `Hairline`
- Produces: `FloatingTabBar.ActiveRoute` bindable property
- Produces: `ViewInteraction.AnimateEntranceAsync`, `AnimateTapAsync`, `AnimateFavouriteAsync`, `AnimatePageAsync`

- [ ] **Step 1: Add a failing resource/build contract check**

Run:

```bash
rg -n "Georgia|<Frame|#ED720C|Glyph=\"🏠\"|Glyph=\"📍\"|Glyph=\"💡\"" Resources Views AppShell.xaml
```

Expected: matches prove the legacy typography, Frame components, orange palette, and emoji navigation still exist.

- [ ] **Step 2: Replace the palette with semantic light-mode resources**

```xml
<Color x:Key="DeepTeal">#073B3A</Color>
<Color x:Key="PrimaryTeal">#0B6E69</Color>
<Color x:Key="Lagoon">#12A89D</Color>
<Color x:Key="Coral">#FF6B57</Color>
<Color x:Key="CoralPressed">#E85643</Color>
<Color x:Key="Seafoam">#CDEFE8</Color>
<Color x:Key="MintMist">#EAF8F3</Color>
<Color x:Key="WarmWhite">#FFF9F2</Color>
<Color x:Key="Ink">#123230</Color>
<Color x:Key="SlateTeal">#57706E</Color>
<Color x:Key="Hairline">#DCEAE6</Color>
<Color x:Key="SunYellow">#FFC857</Color>
```

Retain legacy aliases only when a not-yet-migrated platform template requires them; point aliases at the new semantic values.

- [ ] **Step 3: Define shared Border and typography styles**

```xml
<Style x:Key="PageTitleLabel" TargetType="Label">
  <Setter Property="FontFamily" Value="OpenSansSemiBold" />
  <Setter Property="FontSize" Value="32" />
  <Setter Property="TextColor" Value="{StaticResource Ink}" />
</Style>

<Style x:Key="CardBorder" TargetType="Border">
  <Setter Property="BackgroundColor" Value="White" />
  <Setter Property="Stroke" Value="Transparent" />
  <Setter Property="StrokeShape">
    <RoundRectangle CornerRadius="26" />
  </Setter>
  <Setter Property="Shadow">
    <Shadow Brush="#29073B3A" Offset="0,10" Radius="24" Opacity="0.16" />
  </Setter>
</Style>
```

Add exact styles for hero eyebrow, hero title, body, muted copy, category chip, coral circle button, destination card, favourite circle, and tip card. Each interactive style sets `MinimumHeightRequest="44"` and `MinimumWidthRequest="44"`.

- [ ] **Step 4: Implement cancellable motion helpers**

```csharp
public static async Task AnimateEntranceAsync(
    VisualElement element,
    double startY = 20,
    uint duration = 360,
    uint delay = 0)
{
    element.CancelAnimations();
    element.Opacity = 0;
    element.TranslationY = startY;
    if (delay > 0)
        await Task.Delay((int)delay);
    await Task.WhenAll(
        element.FadeToAsync(1, duration, Easing.CubicOut),
        element.TranslateToAsync(0, 0, duration, Easing.CubicOut));
}

public static async Task AnimateFavouriteAsync(VisualElement element)
{
    element.CancelAnimations();
    await element.ScaleToAsync(1.18, 120, Easing.CubicOut);
    await element.ScaleToAsync(1, 220, Easing.SpringOut);
}
```

Preserve `GestureView`. Update `AnimateTapAsync` to call `CancelAnimations()` before scaling.

- [ ] **Step 5: Create the reusable floating tab bar**

```xml
<Border BackgroundColor="White"
        Stroke="{StaticResource Hairline}"
        StrokeShape="RoundRectangle 30"
        Padding="8"
        Margin="20,8,20,22">
  <Border.Shadow>
    <Shadow Brush="#29073B3A" Offset="0,12" Radius="24" Opacity="0.16" />
  </Border.Shadow>
  <Grid ColumnDefinitions="*,*,*" ColumnSpacing="4">
    <!-- Each 48-point item contains a Path line icon and label.
         Home uses house geometry, Explore uses compass geometry,
         and Tips uses lightbulb geometry. -->
  </Grid>
</Border>
```

In code-behind, declare:

```csharp
public static readonly BindableProperty ActiveRouteProperty =
    BindableProperty.Create(
        nameof(ActiveRoute),
        typeof(string),
        typeof(FloatingTabBar),
        "HomePage",
        propertyChanged: OnActiveRouteChanged);

public string ActiveRoute
{
    get => (string)GetValue(ActiveRouteProperty);
    set => SetValue(ActiveRouteProperty, value);
}
```

Each item navigates with `Shell.Current.GoToAsync("//HomePage")`, `//DestinationsPage`, or `//TipsPage`; use one `_isNavigating` guard and reset it in `finally`. Active state must apply seafoam background, coral icon disc, bold label, and `SemanticProperties.Description`.

- [ ] **Step 6: Hide native Shell chrome and update app branding**

Keep all three `ShellContent` routes, set `Shell.TabBarIsVisible="False"` on root pages, remove emoji `FontImageSource` blocks, and set the app icon/splash base color to `#073B3A`. Use teal/coral only in the SVG foregrounds.

- [ ] **Step 7: Build and re-run the legacy scan**

```bash
dotnet build TravelGuideApp.csproj -f net10.0-maccatalyst
rg -n "Georgia|<Frame|#ED720C|Glyph=\"🏠\"|Glyph=\"📍\"|Glyph=\"💡\"" Resources Views AppShell.xaml
```

Expected: build succeeds; the scan returns no app-owned legacy matches.

- [ ] **Step 8: Commit the shared design foundation**

```bash
git add AppShell.xaml Controls Helper Resources TravelGuideApp.csproj
git commit -m "feat: add vibrant travel design foundation"
```

---

### Task 3: Implement the Approved Home v4

**Files:**
- Modify: `Views/HomePage.xaml`
- Modify: `Views/HomePage.xaml.cs`

**Interfaces:**
- Consumes: `HomeViewModel.Categories`, `PopularDestinations`, `SelectCategoryCommand`
- Consumes: `FloatingTabBar ActiveRoute="HomePage"`
- Consumes: shared motion helpers from Task 2

- [ ] **Step 1: Capture the failing visual contract**

Launch the current page:

```bash
dotnet build TravelGuideApp.csproj -t:Run -f net10.0-maccatalyst
```

Expected mismatch: orange/Georgia baseline, crowded overlapping search, narrow destination card, and native/emoji navigation differ from approved Superdesign draft v4.

- [ ] **Step 2: Replace Home with the approved hierarchy**

```xml
<Grid RowDefinitions="*,Auto">
  <ScrollView Grid.Row="0">
    <VerticalStackLayout Spacing="0">
      <Grid x:Name="Hero" HeightRequest="404" IsClippedToBounds="True">
        <Image x:Name="HeroImage" Source="homepage_background.jpg" Aspect="AspectFill" />
        <BoxView Color="#BF073B3A" />
        <Grid Padding="20,54,20,0" RowDefinitions="Auto,*">
          <!-- TravelGuide header and compass action -->
          <!-- eyebrow, 40-point headline, and body at Y≈133 -->
        </Grid>
      </Grid>
      <Border x:Name="SearchPanel"
              Style="{StaticResource CardBorder}"
              Margin="20,-32,20,0"
              HeightRequest="68">
        <!-- map-pin badge, WHERE TO copy, coral search circle -->
      </Border>
      <!-- category chips, Popular now card, in-image season/rating badges,
           and deep-teal travel-note panel -->
    </VerticalStackLayout>
  </ScrollView>
  <controls:FloatingTabBar Grid.Row="1" ActiveRoute="HomePage" />
</Grid>
```

Use `AbsoluteLayout` or overlay `Grid` placement inside the Bali card so “Best season · May–Oct” is at top-left and the 4.9 rating is at top-right. Do not recreate the removed overlapping “Island rhythm” panel.

- [ ] **Step 3: Wire Home interactions and staggered entrance motion**

```csharp
protected override async void OnAppearing()
{
    base.OnAppearing();
    HeroImage.CancelAnimations();
    HeroImage.Scale = 1.04;
    await Task.WhenAll(
        HeroImage.ScaleToAsync(1, 520, Easing.CubicOut),
        ViewInteraction.AnimateEntranceAsync(HeroCopy, 20, 420, 80),
        ViewInteraction.AnimateEntranceAsync(SearchPanel, 18, 360, 170),
        ViewInteraction.AnimateEntranceAsync(CategoryStrip, 18, 360, 230),
        ViewInteraction.AnimateEntranceAsync(PopularSection, 20, 420, 300));
}
```

Retain destination navigation and category selection. On category change, animate the card container out by 8 points, execute the command, then fade/translate it in. Search and compass actions provide tap feedback only.

- [ ] **Step 4: Build and manually verify Home**

```bash
dotnet build TravelGuideApp.csproj -f net10.0-maccatalyst
```

Verify at narrow and wide sizes:

- hero copy remains readable;
- at least 28–36 points separate the complete copy from the search;
- Bali badges do not collide;
- category chips scroll and selection has a check cue;
- Home tab is visibly active without relying on color;
- entrance motion runs once per appearance without stacking.

- [ ] **Step 5: Commit Home**

```bash
git add Views/HomePage.xaml Views/HomePage.xaml.cs
git commit -m "feat: redesign vibrant adventure home"
```

---

### Task 4: Implement the Editorial Destinations Page

**Files:**
- Modify: `Views/DestinationsPage.xaml`
- Modify: `Views/DestinationsPage.xaml.cs`

**Interfaces:**
- Consumes: `DestinationsViewModel.Destinations`, `ToggleFavouriteCommand`
- Consumes: `DestinationCardItem.Eyebrow`, `Season`, `HeartColorHex`
- Consumes: `FloatingTabBar ActiveRoute="DestinationsPage"`

- [ ] **Step 1: Confirm the current page fails the visual contract**

```bash
rg -n "<Frame|Georgia|Destination Info|Exciting!" Views/DestinationsPage.xaml Views/DestinationsPage.xaml.cs
```

Expected: legacy cards/typography and placeholder alert copy are present.

- [ ] **Step 2: Build the editorial catalogue layout**

```xml
<Grid RowDefinitions="*,Auto">
  <ScrollView Grid.Row="0">
    <VerticalStackLayout Padding="20,54,20,28" Spacing="0">
      <Label Text="EXPLORE THE EXTRAORDINARY" Style="{StaticResource EyebrowLabel}" />
      <Label Text="Find your next&#10;great story." Style="{StaticResource PageTitleLabel}" />
      <Label Text="From quiet temples to untamed horizons, follow the places that stay with you."
             Style="{StaticResource BodyMutedLabel}" Margin="0,12,0,24" />
      <!-- filter chips -->
      <!-- one large featured card, then a two-column adaptive card grid -->
    </VerticalStackLayout>
  </ScrollView>
  <controls:FloatingTabBar Grid.Row="1" ActiveRoute="DestinationsPage" />
</Grid>
```

Use a featured first card at approximately 300 points high. Use a two-column `CollectionView` for supporting destinations when width permits and a single column at narrow widths via `OnIdiom`/adaptive sizing. Each card includes image, scrim, eyebrow, title, location, season, and a 44-point favourite button.

- [ ] **Step 3: Replace placeholder alerts with deterministic navigation**

On any card tap, route to:

```csharp
await Shell.Current.GoToAsync(
    $"{nameof(DestinationDetailPage)}?name={Uri.EscapeDataString(name)}");
```

On favourite tap, call `AnimateFavouriteAsync` before executing `ToggleFavouriteCommand`. Use an `_isOpeningDetail` guard reset in `finally`.

- [ ] **Step 4: Build and live-check catalogue interactions**

```bash
dotnet build TravelGuideApp.csproj -f net10.0-maccatalyst
dotnet test TravelGuideApp.Tests/TravelGuideApp.Tests.csproj
```

Verify every card opens Detail, favourite toggles once under rapid tapping, supporting cards remain readable at narrow width, and Explore is the active navigation item.

- [ ] **Step 5: Commit Destinations**

```bash
git add Views/DestinationsPage.xaml Views/DestinationsPage.xaml.cs
git commit -m "feat: redesign editorial destinations"
```

---

### Task 5: Implement the Cinematic Destination Detail Page

**Files:**
- Modify: `Views/DestinationDetailPage.xaml`
- Modify: `Views/DestinationDetailPage.xaml.cs`
- Consume: `ViewModels/DestinationDetailViewModel.cs`

**Interfaces:**
- Consumes: `DestinationDetailViewModel.Load(string)`
- Produces: query-driven detail rendering without user-facing placeholder alerts

- [ ] **Step 1: Confirm the current detail implementation is view-owned**

```bash
rg -n "TitleLabel\.Text|Para1Label\.Text|HeroImage\.Source|<Frame" Views/DestinationDetailPage.*
```

Expected: hardcoded content assignment and a Frame back button are reported.

- [ ] **Step 2: Bind the page to the detail ViewModel**

```csharp
private readonly DestinationDetailViewModel _viewModel = new();

public DestinationDetailPage()
{
    InitializeComponent();
    BindingContext = _viewModel;
}

public string Name
{
    get => _name;
    set
    {
        _name = value ?? string.Empty;
        _viewModel.Load(_name);
    }
}
```

- [ ] **Step 3: Build the cinematic hero and rising information sheet**

```xml
<Grid RowDefinitions="*">
  <ScrollView>
    <VerticalStackLayout Spacing="0">
      <Grid HeightRequest="420">
        <Image Source="{Binding HeroImage}" Aspect="AspectFill" />
        <BoxView VerticalOptions="End" HeightRequest="220">
          <BoxView.Background>
            <LinearGradientBrush StartPoint="0,0" EndPoint="0,1">
              <GradientStop Color="Transparent" Offset="0" />
              <GradientStop Color="#D9073B3A" Offset="1" />
            </LinearGradientBrush>
          </BoxView.Background>
        </BoxView>
        <!-- 44-point back and favourite controls; location/title at bottom -->
      </Grid>
      <Border x:Name="DetailSheet"
              Margin="0,-30,0,0"
              Padding="20,28,20,36"
              BackgroundColor="{StaticResource WarmWhite}"
              Stroke="Transparent"
              StrokeShape="RoundRectangle 30,30,0,0">
        <!-- Season/Mood chips, descriptions, and coral “Save this journey” showcase action -->
      </Border>
    </VerticalStackLayout>
  </ScrollView>
</Grid>
```

The coral action provides tap motion and changes temporary label text to “Journey saved” without implying booking or persistence.

- [ ] **Step 4: Animate the detail sheet and guard back navigation**

```csharp
protected override async void OnAppearing()
{
    base.OnAppearing();
    await ViewInteraction.AnimateEntranceAsync(DetailSheet, 44, 440, 80);
}
```

Use one `_isNavigatingBack` guard and animate the back control before `Shell.Current.GoToAsync("..")`.

- [ ] **Step 5: Build and verify known and fallback destinations**

```bash
dotnet test TravelGuideApp.Tests/TravelGuideApp.Tests.csproj
dotnet build TravelGuideApp.csproj -f net10.0-maccatalyst
```

Open Bali, Kyoto Temples, and one other catalogue destination. Verify the fallback uses `homepage_background.jpg`, no image disappears, the sheet animation does not stack, and back returns to the originating root page.

- [ ] **Step 6: Commit Detail**

```bash
git add Views/DestinationDetailPage.xaml Views/DestinationDetailPage.xaml.cs
git commit -m "feat: redesign cinematic destination detail"
```

---

### Task 6: Implement the Vibrant Tips Page

**Files:**
- Modify: `Views/TipsPage.xaml`
- Modify: `Views/TipsPage.xaml.cs`

**Interfaces:**
- Consumes: `TipsViewModel.Tips`, `TravelTip.IconKey`, `TravelTip.IsFeatured`
- Consumes: `FloatingTabBar ActiveRoute="TipsPage"`

- [ ] **Step 1: Confirm the current page uses legacy visual primitives**

```bash
rg -n "<Frame|Georgia|🎒|💰|🛡️|🍽️|🗣️|📶|📷|⏰" Views/TipsPage.xaml ViewModels/TipsViewModel.cs
```

Expected: legacy Frames, serif typography, and emoji content are reported.

- [ ] **Step 2: Build the redesigned advice hierarchy**

```xml
<Grid RowDefinitions="*,Auto">
  <ScrollView Grid.Row="0">
    <VerticalStackLayout Padding="20,54,20,30" Spacing="0">
      <Label Text="TRAVEL LIGHTER" Style="{StaticResource EyebrowLabel}" />
      <Label Text="Little ideas.&#10;Better journeys." Style="{StaticResource PageTitleLabel}" />
      <Label Text="Smart, human advice for moving through the world with more ease."
             Style="{StaticResource BodyMutedLabel}" Margin="0,12,0,24" />
      <!-- featured deep-teal advice panel -->
      <!-- compact white/mint advice cards -->
      <!-- coral/seafoam inspirational close -->
    </VerticalStackLayout>
  </ScrollView>
  <controls:FloatingTabBar Grid.Row="1" ActiveRoute="TipsPage" />
</Grid>
```

Map semantic `IconKey` values (`backpack`, `wallet`, `shield`, `utensils`, `message`, `signal`, `camera`, `clock`) to simple XAML Path geometries or small text-free vector badges. Do not render the old emoji strings.

- [ ] **Step 3: Replace alerts with inline acknowledgement**

On tap, animate the card to 0.98 and briefly reveal an inline “Saved for your next trip” label inside the page. Do not open modal alerts. Prevent repeated taps from stacking animations.

- [ ] **Step 4: Build and verify Tips**

```bash
dotnet test TravelGuideApp.Tests/TravelGuideApp.Tests.csproj
dotnet build TravelGuideApp.csproj -f net10.0-maccatalyst
```

Verify one featured tip exists, all icon badges render without emoji, cards remain scannable at narrow width, the inline acknowledgement clears cleanly, and Tips is the active navigation item.

- [ ] **Step 5: Commit Tips**

```bash
git add Views/TipsPage.xaml Views/TipsPage.xaml.cs
git commit -m "feat: redesign vibrant travel tips"
```

---

### Task 7: Integration, Responsive Polish, and Accessibility Verification

**Files:**
- Modify if verification finds an issue: `Resources/Styles/Styles.xaml`
- Modify if verification finds an issue: `Controls/FloatingTabBar.xaml`
- Modify if verification finds an issue: `Views/HomePage.xaml`
- Modify if verification finds an issue: `Views/DestinationsPage.xaml`
- Modify if verification finds an issue: `Views/DestinationDetailPage.xaml`
- Modify if verification finds an issue: `Views/TipsPage.xaml`

**Interfaces:**
- Validates all interfaces produced in Tasks 1–6.

- [ ] **Step 1: Run automated checks**

```bash
dotnet test TravelGuideApp.Tests/TravelGuideApp.Tests.csproj
dotnet build TravelGuideApp.csproj -f net10.0-maccatalyst
rg -n "Georgia|<Frame|#ED720C|DisplayAlertAsync|Glyph=\"🏠\"|Glyph=\"📍\"|Glyph=\"💡\"" Resources Views AppShell.xaml
```

Expected: tests pass; build completes with zero errors; legacy scan returns no matches.

- [ ] **Step 2: Run the MacCatalyst app**

```bash
dotnet build TravelGuideApp.csproj -t:Run -f net10.0-maccatalyst
```

Keep the app open for the remaining checks.

- [ ] **Step 3: Verify the complete journey**

Perform these interactions in order:

1. Home entrance animation completes once.
2. Select Island life, Wild escapes, Culture, and Slow travel; each updates the card once.
3. Open the Home card and return.
4. Switch to Explore using the floating navigation.
5. Toggle favourite twice on the first and final catalogue cards.
6. Open Bali, Kyoto Temples, and a fallback destination; return each time.
7. Switch to Tips and tap a standard and featured tip.
8. Rapidly tap category, favourite, back, and tab controls to confirm guards prevent duplicate navigation or stacked animation.

- [ ] **Step 4: Verify responsive layout**

Check one narrow phone-like window and one large MacCatalyst window. Confirm:

- Home keeps 28–36 points between hero copy and search;
- hero text does not clip;
- destination card badges never overlap;
- catalogue changes from one to two columns cleanly;
- paragraph text remains readable and is not fixed-height;
- the floating tab bar respects safe areas and does not cover scroll content.

- [ ] **Step 5: Verify accessibility**

Confirm:

- icon-only controls have semantic descriptions;
- selected chip/tab state has shape, icon, or weight cues;
- all interactive targets are at least 44 points;
- white text is always protected by a sufficiently dark image scrim;
- focus order follows visual order;
- decorative images are excluded from accessibility while meaningful images have descriptions.

- [ ] **Step 6: Capture final screenshots**

Capture Home, Destinations, Bali Detail, Kyoto Detail, and Tips at phone width plus Home and Destinations at the large MacCatalyst size. Compare Home against Superdesign draft `b6022f80-d9b4-48d9-80a3-aa412f045f56` version 4.

- [ ] **Step 7: Commit verification polish**

```bash
git add Resources Controls Views
git commit -m "fix: polish responsive travel showcase"
```

If verification required no file changes, skip the commit and retain the passing command output as evidence.
