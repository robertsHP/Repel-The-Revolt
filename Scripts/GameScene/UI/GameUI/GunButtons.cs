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
			foreach (TextureButton button in indexedButtons)
				buttons.Add(button.Text.Replace(" ", ""), button);
			if(GameScene.mainBuilding.weapons.Count != 0) {
				pressedButton = buttons[GameScene.mainBuilding.weapon.Name];
				pressedButton.Pressed = true;
			}
		}
		public void Process(float delta) {
			WeaponSelectionWithKeyboard();
			foreach (KeyValuePair<string, TextureButton> keyValPair in buttons) {
				keyValPair.Value.Disabled = !GameScene.mainBuilding.weapons.ContainsKey(
					keyValPair.Key);
			}
		}
		private void WeaponSelectionWithKeyboard () {
			for (int i = 0; i < indexedButtons.Count; i++) {
				if(Input.IsKeyPressed((int) KeyList.Key1 + i)) {
					TextureButton button = (TextureButton) indexedButtons[i];
					string weaponName = button.Text.Replace(" ", "");
					if(GameScene.mainBuilding.weapons.ContainsKey(weaponName)) {
						SelectWeapon(button);
					}
				}
			}
		}
		private void _on_Gun1Button_pressed() {
			SelectWeapon((TextureButton) GetNode("Gun1Button"));
		}
		private void _on_Gun2Button_pressed() {
			SelectWeapon((TextureButton) GetNode("Gun2Button"));
		}
		private void _on_Gun3Button_pressed() {
			SelectWeapon((TextureButton) GetNode("Gun3Button"));
		}
		private void _on_Gun4Button_pressed() {
			SelectWeapon((TextureButton) GetNode("Gun4Button"));
		}
		private void SelectWeapon (Button nextButton) {
			string weaponName = nextButton.Text.Replace(" ", "");
			
			string prevWeaponName = GameScene.mainBuilding.weapon.Name;
			TextureButton prevButton = buttons[prevWeaponName];
			prevButton.Pressed = false;
			
			nextButton.Pressed = true;
			pressedButton = nextButton;
			GameScene.mainBuilding.weapon = GameScene.mainBuilding.weapons[weaponName];
		}
	}
}
