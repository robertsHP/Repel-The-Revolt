using Godot;
using System;

namespace MainMenu {
	public class Title : Sprite {
        private float _tiltSpeed = 2.0f; // Controls how fast the tilt oscillates
        private float _tiltAmount = 0.1f; // Maximum tilt angle in radians

        public override void _Process(float delta) {
            // Calculate the tilt angle based on time
            float tiltAngle = _tiltAmount * Mathf.Sin(_tiltSpeed * OS.GetTicksMsec() / 1000.0f);
            Rotation = tiltAngle; // Apply the tilt angle to the sprite
        }
	}
}
