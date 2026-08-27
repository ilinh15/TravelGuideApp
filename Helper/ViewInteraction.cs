namespace TravelGuide.Helpers
{
    public static class ViewInteraction
    {
        public static VisualElement? GestureView(object? sender)
        {
            return sender switch
            {
                VisualElement ve => ve,
                TapGestureRecognizer t => t.Parent as VisualElement,
                PointerGestureRecognizer p => p.Parent as VisualElement,
                _ => null
            };
        }

        public static async Task AnimateTapAsync(VisualElement? view, double scale = 0.96, uint pressMs = 90, uint releaseMs = 140)
        {
            if (view == null) return;
            await view.ScaleToAsync(scale, pressMs, Easing.CubicOut);
            await view.ScaleToAsync(1.0, releaseMs, Easing.SpringOut);
        }

        public static async Task AnimateImageAcknowledgeAsync(VisualElement? view)
        {
            if (view == null) return;
            await view.FadeToAsync(0.88, 70);
            await view.FadeToAsync(1.0, 160, Easing.CubicInOut);
        }
    }
}
