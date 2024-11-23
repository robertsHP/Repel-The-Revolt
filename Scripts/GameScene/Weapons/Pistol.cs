using Godot;
using System;

namespace Game {
	public class Pistol : Weapon {
		public override void FireProjectile (Node2D user, Vector2 direction) {
			GameScene.projectiles.FireProjectile("PistolBullet", this, direction, user);
		}
		public override Projectile GetProjectileType () {
			Projectile projectile = (Projectile) GameScene.LoadSceneNode(
				"Projectiles/PistolBullet");
			projectile.Hide();
			return projectile;
		}
	}
}
