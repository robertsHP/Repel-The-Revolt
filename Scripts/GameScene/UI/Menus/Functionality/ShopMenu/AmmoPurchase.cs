using Godot;
using System;
using System.Threading;

namespace Game {
	public class AmmoPurchase : ShopPurchaseNode {
		protected override void Ready1 () {}
		
		protected override void Process1 () {
			GunPurchase gunPurchase = gunPayment.gunPurchaseNode;

			// If no gun is purchased, disable the purchase button and exit early
			if (gunPurchase.purchasedGun == null) {
				purchaseButton.Disabled = true;
				return;
			}

			string name = gunPurchase.purchasedGun.Name;

			// Check if the gun exists in the main building's weapons
			if (GameScene.mainBuilding.weapons.TryGetValue(name, out Weapon weapon)) {
				// Determine if the purchase button should be disabled based on the weapon properties
				bool shouldDisableButton = !gunPurchase.purchaseButton.Disabled || weapon.infiniteAmmo;
				purchaseButton.Disabled = shouldDisableButton;
			} else {
				// If the weapon doesn't exist, disable the purchase button
				purchaseButton.Disabled = true;
			}
		}
		private void _on_PurchaseButton_pressed() {
			if(GameScene.mainBuilding.money >= cost) {
				GameScene.mainBuilding.money -= cost;

				Weapon gun = gunPayment.gunPurchaseNode.purchasedGun;

				gun.inventoryAmmo++;
			} else {
				GameScene.ui.LoadTemporaryMessageBox("You dont have enough money.");
			}
		}
	}
}
