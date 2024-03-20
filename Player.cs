using Godot;
using System;

public class Player : KinematicBody
{
    // How fast the character moves
    [Export] 
    public int Speed = 14;
    
    // Fall acceleration after jumping
    [Export]
    public int FallAcceleration = 75;

    private Vector3 _velocity = Vector3.Zero;

    public override void _PhysicsProcess(float delta)
    {
        // Stores input direciton
        var direction = Vector3.Zero;
        
        // Check for directional input and update
        if (Input.IsActionPressed("move_right"))
        {
            direction.x += 1f;
        }
        if (Input.IsActionPressed("move_left"))
        {
            direction.x -= 1f;
        }

        if (Input.IsActionPressed("move_forward"))
        {
            direction.z -= 1f;
        }

        if (Input.IsActionPressed("move_back"))
        {
            direction.z += 1f;
        }

        if (direction != Vector3.Zero)
        {
            direction = direction.Normalized();
            GetNode<Spatial>("Pivot").LookAt(Translation + direction, Vector3.Up);
        }
        
        // Ground Velocity
        _velocity.x = direction.x * Speed;
        _velocity.z = direction.z * Speed;
        // Vertical Velocity
        _velocity.y -= direction.y * delta;
        // Moving the character
        _velocity = MoveAndSlide(_velocity, Vector3.Up);
    }
}
