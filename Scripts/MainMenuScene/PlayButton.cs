using Godot;
using System;

namespace MainMenu {
	public class PlayButton : HoverButton {
		public void _on_PlayButton_pressed() {
			GetTree().ChangeScene("res://Scenes/Level1Scene.tscn");
		}
	}
}

