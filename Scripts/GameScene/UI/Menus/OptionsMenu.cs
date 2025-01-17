using Godot;
using System;

namespace Game {
	public class OptionsMenu : Menu {
		private void _on_ResumeButton_pressed() {
			QueueFreeAndSetStateToDefault();
		}
		private void _on_QuitButton_pressed() {
			QueueFreeAndSetStateToDefault();
			GetTree().ChangeScene("res://Scenes/MainMenuScene.tscn");
		}
	}
}
