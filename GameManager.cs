using Godot;
using System;

public partial class GameManager : Node
{

    Timer GameTimer;
    bool IsRunning = false;
    bool GameStart = false;
    bool ChoosingItem = false;


    public override void _Ready()
    {
        base._Ready();
        GameTimer = GetNode<Timer>("GameManager/Timer");
        GameTimer.OneShot = true;
        
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (IsRunning == false)
        {
            if(GameStart)
            {
                GameTimer.Start(60);
            }
        }
        else
        {



            if (GameTimer.TimeLeft <= 0.00)
            {
                GameTimeout();
            }

        }

        
    }


    public void GameTimeout()
    {

    }

}
