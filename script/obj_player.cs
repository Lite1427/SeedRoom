using Godot;
using System;

public partial class obj_player : CharacterBody2D
{
    private Vector2 currentVelocity;

    private bool player_can_move = true;

    [Export]
    private int player_spd = 50;

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        player_can_move = GlobalVariables.player_movement_allowed;
        handleInput();
        Velocity = currentVelocity;
        MoveAndSlide();
    }

    private void handleInput()
    {
        if(player_can_move == true)
        {
            currentVelocity = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
            currentVelocity *= player_spd;
        }

        if(Input.IsActionPressed("ui_run"))
        {
            currentVelocity *= 2;
        }
    }
}
