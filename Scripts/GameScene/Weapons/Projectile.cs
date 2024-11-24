using Godot;
using System;

namespace Game {
	public class Projectile : Area2D {		
		[Export] public float damage;
		[Export] public float speed;
		[Export] public bool explosive = false;
		[Export] public bool napalmExplosive = false;
		[Export] public NodePath launchComponentPath;
		
		public Node2D nodeFiredFrom;
		public Weapon gunFiredFrom;



		public bool affectEnemies = false;
		public bool affectStructures = false;
		
		public LaunchComponent launchComponent;
		
		public override void _Ready () {
			launchComponent = GetNode<LaunchComponent>(launchComponentPath);
			launchComponent.Start();
		}
		public override void _PhysicsProcess (float delta) {
			launchComponent.Move(speed, delta);
		}
		protected void OnHit (Node2D node) {
			if(nodeFiredFrom != node) {
				if(node.IsInGroup("Enemies")) {
					Enemy enemy = (Enemy) node;
					enemy.Damage(damage, false, launchComponent.direction);
					Destroy();
				} else if (node.IsInGroup("Structures")) {
					Structure structure = (Structure) node;
					structure.Damage(damage);
					Destroy();
				}
			}
		}
		
		protected void Destroy () {
			if(explosive) {
				GameScene.ground.SpawnExplosion(GlobalPosition, new Vector2(4, 4));
			} else if (napalmExplosive) {
				GameScene.ground.SpawnNapalmExplosion(GlobalPosition, new Vector2(4, 4));
			}
			QueueFree();
		}
		private void _on_VisibilityNotifier2D_screen_exited() {
			Destroy();
		}
		private void _on_Projectile_body_entered(Node2D node) {
			OnHit(node);
		}
		private void _on_Projectile_area_entered(Node2D node) {
			OnHit(node);
		}
	}
}
