# TravelGuide — Vibrant Adventure Design System

## Product

TravelGuide is a mobile-first .NET MAUI showcase app for discovering destinations and enjoying practical travel inspiration. It has four visual experiences: Home, Destinations, Destination Detail, and Tips. The redesign prioritizes delight, photography, atmosphere, and coherent motion over backend functionality.

Primary job: make a viewer immediately want to explore. Secondary jobs: browse curated destinations, save favourites, and scan useful travel tips.

## Creative Direction

The single visual direction is **Vibrant Adventure**: tropical, editorial, optimistic, and polished. It borrows the organic layering and premium motion rhythm of the selected Nature Inspired Style prompt, adapted into a distinctly travel-oriented identity.

- Make photography the emotional anchor.
- Use asymmetric layering, rounded organic surfaces, and intentional color blocking.
- Keep the experience energetic without looking childish or cluttered.
- Avoid generic travel-template styling, purple gradients, glass-heavy sci-fi effects, excessive emoji, or dense utility UI.
- Light mode only.

## Color Tokens

- Deep Tropical Teal / brand dark: `#073B3A`
- Expedition Teal / primary: `#0B6E69`
- Lagoon / primary bright: `#12A89D`
- Vivid Coral / action accent: `#FF6B57`
- Coral pressed: `#E85643`
- Seafoam / soft selected surface: `#CDEFE8`
- Mint Mist / pale section surface: `#EAF8F3`
- Warm White / app background: `#FFF9F2`
- Pure White / cards: `#FFFFFF`
- Sun Yellow / rare highlight only: `#FFC857`
- Ink / primary copy: `#123230`
- Slate Teal / secondary copy: `#57706E`
- Hairline / borders: `#DCEAE6`
- Scrim: `rgba(3, 33, 31, 0.52)`

Use teal for identity and structure, coral for the primary call to action and favourite state, seafoam for selected chips, and yellow only as a tiny surprise accent. Never introduce colors outside this system.

## Typography

- Display/headings: **Open Sans Semibold**, visually bold and compact. If the implementation adds a new bundled display font later, it must be sans-serif, expressive, and legible; do not use serif headings.
- Body/utility: **Open Sans Regular**.
- Hero: 38–44 mobile, 48–56 on wide windows; weight 700; line-height about 0.98.
- Page title: 30–34, weight 700.
- Section title: 22–26, weight 700.
- Card title: 18–22, weight 700.
- Body: 14–16, line-height 1.4–1.55.
- Eyebrow/metadata: 11–12, semibold, modest tracking.

Sentence case is preferred. Uppercase is reserved for tiny eyebrow labels, never paragraphs or primary buttons.

## Spacing and Shape

- Base spacing unit: 4.
- Page horizontal padding: 20 on phones, 28–40 on large windows.
- Hero-to-search breathing room: the hero headline must sit clearly above the floating search surface. Preserve at least 28 px of uncluttered visual separation from the headline block to the search card; do not crowd the search bar against the header or title.
- Common gaps: 8, 12, 16, 20, 24, 32.
- Small controls radius: 14–18.
- Cards radius: 22–28.
- Hero/media containers: 28–36.
- Bottom navigation capsule: 28–32.
- Touch targets: minimum 44 x 44.

## Elevation and Texture

- Floating search/card shadow: teal-tinted, soft and deep, approximately `0 14px 36px rgba(7,59,58,0.16)`.
- Secondary card shadow: `0 8px 24px rgba(7,59,58,0.10)`.
- Use subtle tonal separation before adding borders.
- A barely visible organic grain may be used in large hero areas only; never reduce text readability.

## Shared Components

### Floating Bottom Navigation

A custom three-item capsule for Home, Explore, and Tips. It floats above the safe area on warm white, uses simple travel-relevant line icons, and has a clear non-color selected indicator (filled seafoam/coral pill plus label weight). Avoid emoji glyphs.

### Floating Search Panel

A white, generously rounded search surface below the hero content with destination icon, inviting placeholder copy, and a coral circular action. It is decorative/showcase-first but must look operable. Keep substantial space between it and the header/headline.

### Category Chips

Horizontal, comfortably spaced pills. Selected state uses seafoam or teal with a strong shape change/check indicator; unselected state uses warm white and a faint border.

### Destination Cards

Large photo-led cards with 4:5 or wide editorial crops, bold rounded corners, subtle bottom scrim, location metadata, rating or short descriptor, and a favourite control. Mix one feature card with smaller supporting cards for rhythm; do not render a monotonous uniform grid.

### Tip Cards

Compact white or mint cards with a simple illustrated badge, useful title, and short copy. Vary emphasis through size/color sparingly while maintaining easy scanning.

## Page Composition

### Home

Immersive hero using a full-bleed destination photograph and deep teal overlay. Brand/header is compact. The headline and supporting copy sit in the upper/middle region with clear breathing room. A floating search panel appears beneath the hero copy rather than touching the header. Below: category chips, a layered “Popular now” destination composition, and a small inspirational editorial block. Content may be rewritten freely to improve visual storytelling.

### Destinations

Editorial browse page with a bold title, short atmospheric introduction, filter chips, one featured destination, and varied image cards. Favourite controls are visible. Preserve generous gutters and clear scan order.

### Destination Detail

Large cinematic hero image, compact top controls, then a warm-white information sheet that rises over the image edge. Include location, short editorial description, small highlight chips, and a visually strong coral action. The page remains a showcase; no booking backend is implied.

### Tips

Friendly, colorful guide page with a concise intro, compact tip cards, one featured advice panel, and an inspirational close. Use icons as designed badges rather than relying on emoji alone.

## Motion

Use the premium easing signature `cubic-bezier(0.16, 1, 0.3, 1)` conceptually, translated to MAUI easing where practical.

- Hero photo: scale 1.04 to 1.0 on entrance.
- Headline: fade and rise by roughly 18–24 px.
- Search, chips, and cards: short staggered entrance.
- Card press: scale to about 0.97 and spring back.
- Category change: brief crossfade plus small horizontal shift.
- Favourite: coral pop/bounce.
- Detail sheet: rises into place from the bottom.
- Tab change: content fades and moves subtly.
- Durations: roughly 160–520 ms; cancel animations before starting replacements.
- No infinite looping motion. Respect reduced motion where available.

## Accessibility and Responsive Rules

- Maintain WCAG-friendly contrast, including text over photos.
- Do not communicate selection through color alone.
- Provide semantic labels for icon-only actions.
- Maintain 44-point minimum touch targets.
- Mobile-first composition must adapt gracefully to larger MacCatalyst windows without simply stretching card widths; use max-width containers or additional columns where appropriate.
- Provide a graceful solid-color/image fallback if media fails.

## Implementation Constraints

- Platform: .NET 10 MAUI with XAML and MVVM.
- Keep existing static ViewModels as state sources; views invoke commands.
- Replace obsolete `Frame` usage with `Border` during implementation.
- Centralize colors, typography, radii, shadows, and shared styles in resource dictionaries.
- A focused animation helper may coordinate entrance and interaction motion.
- No backend, login, live map, network search, or booking functionality is required.
- Use only fonts, colors, spacing, and component styles defined here.
