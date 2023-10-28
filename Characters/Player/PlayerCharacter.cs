using Godot;
using System;

public partial class PlayerCharacter : CharacterBody2D
{
    public Vector2 direction = Vector2.Zero;

    [ExportGroup("Movement")]
    [Export] public float moveSpeed = 175.0f;

    [Export] public Vector2 starting_direction = new Vector2(0, 1);


    //parameters/Idle/blend_position
    //parameters/playback

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        ////Input Handler////
        direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");

        Velocity = direction * moveSpeed;

        MoveAndSlide();

    }

}