using Godot;
using System;

public partial class loading_screen : CanvasLayer
{
    private ColorRect bcg;
    private Label loading_text;
    private Label seed_text;
    public override async void _Ready()
    {
        base._Ready();
        bcg = GetNode<ColorRect>("blck_bcg");
        loading_text = GetNode<Label>("txt_loading");
        seed_text = GetNode<Label>("txt_seed");
        await ToSignal(GetTree().CreateTimer(0.2f), SceneTreeTimer.SignalName.Timeout);
        seed_text.Text = "Seed: " + GlobalVariables.seed;

        do
        {
            await ToSignal(GetTree().CreateTimer(0.3f), SceneTreeTimer.SignalName.Timeout);
            //GD.Print(GlobalVariables.rooms_to_create);
        }while(GlobalVariables.rooms_to_create > 2);

        if(GlobalVariables.rooms_to_create <= 2)
        {
            bcg.QueueFree();
            loading_text.QueueFree();
            seed_text.Position = new Vector2(seed_text.Position.X, -176);
            GlobalVariables.player_movement_allowed = true;
        }
    }
}
