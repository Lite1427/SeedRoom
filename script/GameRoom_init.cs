using Godot;
using System;

public partial class GameRoom_init : Node2D
{
    public override void _Ready()
    {
        base._Ready();
        //GlobalVariables.seed = 704;
        //GD.Seed(704);
        GlobalVariables.rooms_to_create = GD.RandRange(GlobalVariables.room_min, GlobalVariables.room_max);
        
    }
}
