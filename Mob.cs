using Godot;
using System;

public class Mob : KinematicBody
{
    [Export] 
    public int MinSpeed = 10;

    [Export] 
    public int MaxSpeed = 18;
    
    private Vector3 _velocity = Vector3.Zero;

    public override void _PhysicsProcess(float delta)
    {
        //Using KinematicBody MoveAndSlide
        MoveAndSlide(_velocity);
    }

    public void Initialize(Vector3 startPosition, Vector3 playerPosition)
    {   
        //Position the mob, turn it to look at the player
        LookAtFromPosition(startPosition, playerPosition, Vector3.Up);
        //Rotate it a bit randomly so its not a straight line to the player
        RotateY((float)GD.RandRange(-Mathf.Pi / 4.0, Mathf.Pi / 4.0));
        //Calculate the speed with some RNG
        float randomSpeed = (float)GD.RandRange(MinSpeed, MaxSpeed);
        _velocity = Vector3.Forward * randomSpeed;
        _velocity = _velocity.Rotated(Vector3.Up, Rotation.y);
    }
    
    public override void _Ready()
    {

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
