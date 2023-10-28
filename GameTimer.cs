using Godot;
using System;

public partial class GameTimer : Timer
{
    [Export]
    public Label CountdownLabel;

    private int timeRemaining = 60;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        base._Ready();
        CountdownLabel = new Label();
        AddChild(CountdownLabel);

        // Start the timer.
        Start();

        // Update the initial text on the label.
        UpdateCountdownLabel();
    }

    // Called when the timer expires.
    private void _on_Timer_timeout()
    {
        GD.Print("One minute has passed!");
        // You can perform any other actions you need here.
    }

    // Update the countdown label with the remaining time.
    private void UpdateCountdownLabel()
    {
        CountdownLabel.Text = "Time remaining: " + timeRemaining + " seconds";
    }

    // Called every frame.
    public void _Process(float delta)
    {
        // Update the countdown label every frame.
        UpdateCountdownLabel();
    }
}

