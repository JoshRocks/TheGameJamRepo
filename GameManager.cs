using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public partial class GameManager : Node
{

    public CharacterBody2D Player;

    enum GameState {NotStarted, Running, GameOver, Success};
    int GameLevel = 0;
    public short currentGameState = 0;
    bool GameStart = false;
    bool ChoosingItem = false;

    List<CharacterBody2D> ActiveRobots;

    public override void _Ready()
    {
        base._Ready();
        Player = (CharacterBody2D)GetTree().GetFirstNodeInGroup("player");
        GameStart = true;
        
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);        
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (GameStart)
        {
            GameStart = false;
            currentGameState = 1;
        }

        if (currentGameState == 1)
        {
            
        }
        else
        {
            
        }


    }

    public void GameOver()
    {
        Debug.WriteLine("GAME OVER!!!");
    }

}
