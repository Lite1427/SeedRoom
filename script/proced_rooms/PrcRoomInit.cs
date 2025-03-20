using Godot;
using System;

public partial class PrcRoomInit : Node2D
{
    private RandomNumberGenerator random;
    private Marker2D Exit0;
    private Marker2D Exit1;
    private Marker2D Exit2;
    private Marker2D Exit3; 
    private Godot.Collections.Array exit0_common;
    private Godot.Collections.Array exit1_common;
    private Godot.Collections.Array exit2_common;
    private Godot.Collections.Array exit3_common;
    private int rooms_to_create;
    private bool all_rooms_created;
    public override async void _Ready()
    {
        base._Ready();
        await ToSignal(GetTree().CreateTimer(0.5f), SceneTreeTimer.SignalName.Timeout);
        random = new RandomNumberGenerator();
        random.Seed = (ulong)GlobalVariables.seed;

        Exit0 = GetNode<Marker2D>("exit_0");
        Exit1 = GetNode<Marker2D>("exit_1");
        Exit2 = GetNode<Marker2D>("exit_2");
        Exit3 = GetNode<Marker2D>("exit_3");

        exit0_common = new Godot.Collections.Array{"prc_right_hall_0", "prc_right_hall_1", "prc_right_hall_2", "prc_right_end"}; //RIGHT
        exit1_common = new Godot.Collections.Array{"prc_left_hall_0", "prc_left_hall_1", "prc_left_end"}; // LEFT
        exit2_common = new Godot.Collections.Array{"prc_upper_hall_0", "prc_upper_hall_1", "prc_upper_hall_2", "prc_upper_hall_3", "prc_up_end"}; // UP
        exit3_common = new Godot.Collections.Array{"prc_down_hall_0", "prc_down_hall_1", "prc_down_end"}; // DOWN
        
        rooms_to_create = 4;
        all_rooms_created = false;

        room_generate();
    }

    public void room_generate()
    {
        while (rooms_to_create > 0 && GlobalVariables.rooms_to_create > 0)
        {
            GlobalVariables.forbid_room_creation = true;
            //CODE AHEAD
            var exit_0_out = exit0_common.PickRandom();
            var exit_1_out = exit1_common.PickRandom();
            var exit_2_out = exit2_common.PickRandom();
            var exit_3_out = exit3_common.PickRandom();

            //PackedScene packedScene = (PackedScene)GD.Load("res://proced_rooms/prc_right_hall_2.tscn");
            PackedScene packedScene = (PackedScene)GD.Load("res://proced_rooms/" + exit_0_out + ".tscn");
            Node2D s = (Node2D)packedScene.Instantiate();
            s.Position = Exit0.Position;
            AddChild(s);

            //packedScene = (PackedScene)GD.Load("res://proced_rooms/prc_left_hall_1.tscn");
            packedScene = (PackedScene)GD.Load("res://proced_rooms/" + exit_1_out + ".tscn");
            s = (Node2D)packedScene.Instantiate();
            s.Position = Exit1.Position;
            AddChild(s);

            //packedScene = (PackedScene)GD.Load("res://proced_rooms/prc_upper_hall_3.tscn");
            packedScene = (PackedScene)GD.Load("res://proced_rooms/" + exit_2_out + ".tscn");
            s = (Node2D)packedScene.Instantiate();
            s.Position = Exit2.Position;
            AddChild(s);

            packedScene = (PackedScene)GD.Load("res://proced_rooms/" + exit_3_out + ".tscn");
            //packedScene = (PackedScene)GD.Load("res://proced_rooms/prc_down_hall_1.tscn");
            s = (Node2D)packedScene.Instantiate();
            s.Position = Exit3.Position;
            AddChild(s);

            rooms_to_create = 0;
            all_rooms_created = true;
            GlobalVariables.rooms_to_create -= 4;
            //GlobalVariables.rooms_to_create = 0;
            GlobalVariables.rooms_created += 4;
            GlobalVariables.forbid_room_creation = false;
        }

        return;
    }
}