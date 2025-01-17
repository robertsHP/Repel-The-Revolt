using Godot;
using System;

namespace Game {
	public class RPG : Weapon {
		public bool fireUpgrade = false;
		
		public override void FireProjectile (Node2D user, Vector2 direction) {
			Projectile projectile;
			if(!fireUpgrade) {
				projectile = GameScene.projectiles.FireProjectile("Rocket", this, direction, user);
			} else {
				projectile = GameScene.projectiles.FireProjectile("NapalmRocket", this, direction, user);
			}
			if(projectile != null) {
				
			}
		}
		public override Projectile GetProjectileType () {
			Projectile projectile;
			if(!fireUpgrade)
				projectile = (Projectile) GameScene.LoadSceneNode(
					"Projectiles/Rocket");
			else 
				projectile = (Projectile) GameScene.LoadSceneNode(
					"Projectiles/NapalmRocket");
			projectile.Hide();
			return projectile;
		}
	}
}
