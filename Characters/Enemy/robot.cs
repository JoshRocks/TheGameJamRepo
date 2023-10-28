using Godot;
using System;
using System.Diagnostics;

public partial class robot : CharacterBody2D
{
    [ExportGroup("MainStuff")]
    [Export] public float sightRange = 100; // Adjust this to set the sight range
    [Export] public float speed = 300.0f;
    [Export] public float raycastStuff = 1000;
    [Export] public Vector2 visionDirection;

    private Vector2 targetPosition;
    private bool isAggro = false;
    private Vector2 direction;

    PlayerCharacter playerWeLookingFor;



    public override void _Ready()
    {
        base._Ready();
        direction = new Vector2(-1, 0);
        visionDirection = new Vector2(-1, 0);
    }

    public override void _PhysicsProcess(double delta)
    {

        if (!isAggro)
        {
            // Check for the player within aggro range
            playerWeLookingFor = GetPlayerInSight();
            if (playerWeLookingFor != null)
            {
                isAggro = true;
                targetPosition = playerWeLookingFor.GlobalPosition;
                MoveTowardTarget();
            }
        }
        else
        {
            // Move towards the player
            targetPosition = playerWeLookingFor.GlobalPosition;
            MoveTowardTarget();
            
        }
    }

    private PlayerCharacter GetPlayerInSight()
    {
        foreach (Node2D node in GetTree().GetNodesInGroup("player"))
        {
            PlayerCharacter player = node as PlayerCharacter;

            RayCast2D raycast = new RayCast2D();
            AddChild(raycast);

            raycast.TargetPosition = visionDirection * raycastStuff;
            raycast.ForceRaycastUpdate();


            if (raycast.IsColliding())
            {
                Vector2 toPlayer = player.GlobalPosition - GlobalPosition;
                float distanceToPlayer = toPlayer.Length();

                var collider = raycast.GetCollider();
                if (collider == player)
                {
                    Debug.WriteLine("Player In Line of Sight");
                    Debug.WriteLine(distanceToPlayer);
                    return player;
                }
            }
        }

        return null;
    }

    /* private void SightCheck()
     {
         PhysicsDirectSpaceState2D space_state = GetWorld2D().DirectSpaceState;
         var sight_check = space_state.IntersectRay(Position, Playe)
     }*/


    private void MoveTowardTarget()
    {
        direction = (targetPosition - GlobalPosition).Normalized();

        Velocity = direction * speed; // Set your speed value here

        MoveAndSlide();
    }

}
