using Godot;
using System;

namespace MainMenu {
	public class QuitButton : HoverButton {
        public void _on_QuitButton_pressed() {
            GetTree().Quit();
        }
	}
}
