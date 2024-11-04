using Godot;
using System;

namespace MainMenu {
	public class HoverButton : TextureButton {
        private Vector2 originalScale = new Vector2(1, 1); // Default scale
        private Vector2 hoverScale = new Vector2(1.1f, 1.1f); // Scale to 110% on hover
        private Tween tween; // Tween node for smooth animations

        public override void _Ready() {
            // Add a Tween node programmatically
            tween = new Tween();
            AddChild(tween);

            // Center the button to ensure scaling happens from the center
            RectPivotOffset = new Vector2(RectSize.x / 2, RectSize.y / 2);
        }

        private void _on_Button_mouse_entered() {
            // Animate scale up when mouse enters
            tween.InterpolateProperty(
                this, 
                "rect_scale", 
                RectScale, 
                hoverScale, 
                0.2f, 
                Tween.TransitionType.Sine, 
                Tween.EaseType.Out
            );
            tween.Start();
        }

        private void _on_Button_mouse_exited() {
            // Animate scale back down when mouse exits
            tween.InterpolateProperty(
                this, 
                "rect_scale", 
                RectScale, 
                originalScale, 
                0.2f, 
                Tween.TransitionType.Sine, 
                Tween.EaseType.Out
            );
            tween.Start();
        }
	}
}
