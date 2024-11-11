using Godot;
using System;
using System.Collections.Generic;

namespace Game {
	public class GunButtons : Control {
		private Godot.Collections.Array indexedButtons;
		private Dictionary<string, TextureButton> buttons = new Dictionary<string, TextureButton>();
		private TextureButton pressedButton;
		
		public void Init () {
			indexedButtons = GetChildren();

			foreach (TextureButton button in indexedButtons) {
				string key = button.Name.Replace(" ", "").Replace("Button", "");
				buttons.Add(key, button);
			}

			if(GameScene.mainBuilding.weapons.Count != 0) {
				pressedButton = buttons[GameScene.mainBuilding.weapon.Name];
				pressedButton.Pressed = true;
			}
		}
		public void Process(float delta) {
			WeaponSelectionWithKeyboard();

			foreach (KeyValuePair<string, TextureButton> keyValPair in buttons) {
				keyValPair.Value.Disabled = !GameScene.mainBuilding.weapons.ContainsKey(keyValPair.Key);
			}
		}
		private void WeaponSelectionWithKeyboard () {
			for (int i = 0; i < indexedButtons.Count; i++) {
				if(Input.IsKeyPressed((int) KeyList.Key1 + i)) {
					TextureButton button = (TextureButton) indexedButtons[i];
					string weaponName = button.Name.Replace(" ", "").Replace("Button", "");

					if(GameScene.mainBuilding.weapons.ContainsKey(weaponName)) {
						SelectWeapon(button);
					}
				}
			}
		}
		private void _on_PistolButton_pressed() {
			SelectWeapon((TextureButton) GetNode("PistolButton"));
		}
		private void _on_ShotgunButton_pressed() {
			SelectWeapon((TextureButton) GetNode("ShotgunButton"));
		}
		private void _on_AssaultRifleButton_pressed() {
			SelectWeapon((TextureButton) GetNode("AssaultRifleButton"));
		}
		private void _on_RPGButton_pressed() {
			SelectWeapon((TextureButton) GetNode("RPGButton"));
		}
		private void SelectWeapon (TextureButton nextButton) {
			string weaponName = nextButton.Name.Replace(" ", "").Replace("Button", "");
			
			string prevWeaponName = GameScene.mainBuilding.weapon.Name;
			TextureButton prevButton = buttons[prevWeaponName];
			
			prevButton.Pressed = false;
			
			nextButton.Pressed = true;
			pressedButton = nextButton;

			GameScene.mainBuilding.weapon = GameScene.mainBuilding.weapons[weaponName];
		}
	}
}
