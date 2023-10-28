using Godot;

public partial class SceneTransition : Area2D
{
    GameManager manager;
    CharacterBody2D Player;

    [ExportGroup("SceneStuff")]
    [Export] public string SceneToLoad; // The name of the scene to transition to.
    [Export] public float NextStartPosition;
    Timer timer;
    [Export] string MusicPath;

    public override void _Ready()
    {
        base._Ready();
        manager = (GameManager)GetTree().GetFirstNodeInGroup("GameManager");
        Player = manager.Player;
        timer = GetNode<Timer>("GameTimer");
    }

    public void _on_game_timer_timeout()
    {
        timer.Stop();
        manager.GameOver();
    }

    // Called when the player enters the area.
    private void _on_Area2D_body_entered(Node body)
    {
        if (body == Player) // Replace "Player" with the name of your player character's script or class.
        {
            // Load the new scene when the player enters the area.
            GD.Print("Player entered the transition area.");
            GetTree().ChangeSceneToFile(SceneToLoad);
        }
    }
}