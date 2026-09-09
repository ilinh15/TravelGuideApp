# TravelGuide Vibrant Adventure Redesign

Date: 2026-09-10  
Status: Approved design direction; pending implementation plan  
Visual reference: [Superdesign canvas](https://superdesign.dev/teams/0fcd1c17-6a60-4cf0-88ff-f7b60b8eb415/projects/568a3c74-213c-4bc4-ab1c-7aa297ce403f?node=draft-variant-b6022f80-d9b4-48d9-80a3-aa412f045f56)

## Objective

Redesign the existing .NET MAUI TravelGuide application as an attractive travel-design showcase. The experience should feel adventurous, photographic, polished, and memorable. Visual quality and motion are the priority; backend search, booking, accounts, maps, and other production services are intentionally out of scope.

## Approved Product Decisions

- Keep the product name **TravelGuide**.
- Use the **Vibrant Adventure** direction.
- Design mobile-first, adapting gracefully to larger MacCatalyst windows.
- Support light mode only for this showcase.
- Keep the existing four-screen structure: Home, Destinations, Destination Detail, and Tips.
- Preserve the current static MVVM approach and existing interactions where useful.
- Content may be rewritten freely to improve the visual story.
- Motion should be lively but polished, short, and non-looping.

## Architecture

The redesign remains a .NET 10 MAUI XAML application.

- ViewModels remain the source of page state and sample content.
- Views bind to state and invoke commands.
- Global color, typography, spacing, radius, and component styles move into centralized resource dictionaries.
- Obsolete `Frame` compositions are replaced with `Border`.
- Repeated patterns such as destination cards, category chips, and navigation treatments should share resources or reusable controls where this reduces duplication.
- A focused animation helper coordinates entrance, press, category-change, favourite, and navigation motion. Animations must be cancellable and guarded against rapid repeated taps.
- No backend, persistence, authentication, network search, booking, or live-map architecture is introduced.

## Visual System

### Color

| Role | Value |
|---|---|
| Deep tropical teal | `#073B3A` |
| Primary expedition teal | `#0B6E69` |
| Bright lagoon teal | `#12A89D` |
| Primary coral accent | `#FF6B57` |
| Coral pressed | `#E85643` |
| Seafoam selected surface | `#CDEFE8` |
| Mint section surface | `#EAF8F3` |
| Warm-white background | `#FFF9F2` |
| White card surface | `#FFFFFF` |
| Rare sun-yellow highlight | `#FFC857` |
| Primary ink text | `#123230` |
| Secondary slate-teal text | `#57706E` |
| Hairline border | `#DCEAE6` |

Teal provides identity and structure. Coral identifies actions and favourite states. Seafoam communicates selection. Yellow is restricted to tiny highlights such as ratings.

### Typography

- Use the bundled Open Sans family for both display and body text.
- Headings are bold, compact, modern sans-serif—not Georgia or another serif.
- Hero headings: 38–44 on phones and 48–56 on wide windows.
- Page titles: 30–34.
- Section titles: 22–26.
- Body copy: 14–16 with generous line height.
- Tiny eyebrows and metadata: 11–12 with modest tracking.
- Prefer sentence case; reserve uppercase for small eyebrow labels.

### Shape, Spacing, and Elevation

- Phone page gutters: 20.
- Large-window gutters: 28–40 with sensible maximum content widths.
- Touch targets: at least 44 by 44.
- Small controls: 14–18 radius.
- Cards: 22–28 radius.
- Hero/media surfaces: 28–36 radius where not full bleed.
- Bottom navigation capsule: 28–32 radius.
- Use soft teal-tinted shadows rather than heavy neutral drop shadows.
- Maintain at least 28–36 points of visually empty separation between the complete Home hero copy block and the floating search panel. The search must not crowd the header or headline.

## Shared Components

### Floating Search Panel

A white rounded surface beneath the hero with a map-pin/search icon, an inviting destination prompt, and a coral circular action. It looks operable but does not require a functional search backend.

### Category Chips

A horizontal chip row with generous touch targets. The selected chip uses both a filled shape and a check indicator or equivalent non-color cue.

### Destination Card

Photography-first with an editorial crop, lower scrim, location metadata, short atmospheric copy, rating, and optional favourite action. The composition should vary card scale and emphasis rather than repeat a uniform grid.

### Floating Bottom Navigation

A custom white capsule above the safe area with Home, Explore, and Tips. Use simple line icons instead of emoji. The active item uses a filled shape and stronger label weight as well as color.

### Tip Card

A compact white or mint advice card with an intentionally styled icon badge, concise title, and short description.

## Screen Designs

### Home

- Full-bleed hero photography with a deep-teal overlay.
- Compact TravelGuide brand and a small compass action in the safe-area header.
- High-positioned eyebrow, bold “Go where wonder leads.” style headline, and concise supporting copy.
- Clear breathing room before the floating search panel.
- Animated category chips.
- “Popular now” editorial section led by a large Bali card, rating badge, favourite action, and an overlapping mint travel-season note.
- Compact deep-teal travel-note panel for visual rhythm.
- Floating custom bottom navigation.

The approved Home reference is Superdesign draft `b6022f80-d9b4-48d9-80a3-aa412f045f56`, version 3.

### Destinations

- Bold page title and short atmospheric introduction.
- Filter chips matching the Home selected states.
- One featured destination followed by a varied photographic card composition.
- Favourite controls remain visible and animated.
- Use existing destination photography and rewrite descriptions if needed.

### Destination Detail

- Cinematic hero image with compact top controls.
- A warm-white information sheet rises over the image edge.
- Include location, short editorial description, highlight chips, and a visually strong coral showcase action.
- The action must not imply that a real booking backend exists.

### Tips

- Friendly introduction with colorful but controlled visual energy.
- Compact tip cards using designed icon badges rather than plain emoji.
- One larger featured advice panel.
- End with an inspirational travel statement.

## Motion

- Hero image settles from scale 1.04 to 1.0.
- Hero eyebrow, headline, and support copy fade upward.
- Search, chips, and cards enter with a short stagger.
- Cards press to approximately 0.97 and spring back.
- Category changes crossfade and shift horizontally by a small amount.
- Favourite controls pop/bounce and transition to coral.
- The detail information sheet rises from the bottom.
- Tab changes combine a subtle fade and vertical or horizontal shift.
- Use roughly 160–520 ms durations.
- Cancel an in-flight animation before starting its replacement.
- Do not add infinite looping animation.
- Respect reduced-motion preferences where available.

## Content and State

- Existing static ViewModels remain the content source.
- Rewrite sample titles, labels, and descriptions to fit the new editorial tone.
- Category selection continues to update the Home destination content.
- Destination navigation continues to open the detail page.
- Favourite state continues to toggle in memory.
- Decorative search and showcase actions may provide press feedback without implementing services.
- Provide a solid-color or alternate bundled-image fallback if a photo cannot render.

## Accessibility

- Maintain readable contrast over every photograph.
- Do not communicate selected state through color alone.
- Provide semantic labels for icon-only actions.
- Maintain 44-point minimum touch targets.
- Keep text scalable and avoid clipped fixed-height copy.
- Ensure reading and focus order match the visible hierarchy.

## Verification

Implementation verification must include:

- Successful MacCatalyst build with zero new errors.
- Launch and visual review of Home, Destinations, Detail, and Tips.
- Category selection, destination navigation, back navigation, tab switching, and favourite toggle checks.
- Rapid-tap checks to confirm animation cancellation and guard behavior.
- Narrow phone-width and larger MacCatalyst-window layout checks.
- Screenshot comparison against the approved visual direction for all four screens.
- Accessibility review for contrast, semantic labels, touch target sizing, focus order, and non-color selection cues.

## Out of Scope

- Backend or database work
- Authentication or accounts
- Real destination search
- Booking and payment flows
- Live maps, location tracking, or network APIs
- Dark mode
- Production analytics or push notifications
