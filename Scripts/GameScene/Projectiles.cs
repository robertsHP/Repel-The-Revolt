using Godot;
using System;

namespace Game {
	public class Projectiles : Node2D {
		public Projectile FireProjectile (string projectileName, Weapon weapon, Vector2 direction, Node2D user) {
			Projectile projectile = (Projectile) GameScene.LoadSceneNode("Projectiles/"+projectileName);
			
			projectile.Position = weapon.GlobalPosition;
			projectile.nodeFiredFrom = user;
			projectile.gunFiredFrom = weapon;

			AddChild(projectile);

			projectile.launchComponent.SetLaunchDirection(direction, weapon.accuracy);
			projectile.damage += weapon.projectileDamageBoost;
			projectile.affectEnemies = weapon.affectEnemies;
			projectile.affectStructures = weapon.affectStructures;

			return projectile;
		}
	}
}
