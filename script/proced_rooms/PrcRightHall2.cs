using Godot;
using System;

public partial class PrcRightHall2 : Node2D
{
    private RandomNumberGenerator random;
    private Marker2D Exit0;
    private Marker2D Exit1;
    private Godot.Collections.Array exit0_common;
    private Godot.Collections.Array exit1_common;
    private int rooms_to_create;
    private bool all_rooms_created;
    public override async void _Ready()
    {
        base._Ready();
        await ToSignal(GetTree().CreateTimer(0.5f), SceneTreeTimer.SignalName.Timeout);
        random = new RandomNumberGenerator();
        random.Seed = (ulong)GlobalVariables.seed;

        Exit0 = GetNode<Marker2D>("room_exit");
        Exit1 = GetNode<Marker2D>("exit_0");

        exit0_common = new Godot.Collections.Array{"prc_right_hall_0", "prc_right_hall_1", "prc_right_hall_2", "prc_right_end"}; //RIGHT
        exit1_common = new Godot.Collections.Array{"prc_up_end"}; // UP
        
        rooms_to_create = 2;
        all_rooms_created = false;

        room_generate();
    }

    public void room_generate()
    {
        if (rooms_to_create > 0 && GlobalVariables.rooms_to_create > 0 && GlobalVariables.rooms_to_create > rooms_to_create)
        {
            GlobalVariables.forbid_room_creation = true;
            //CODE AHEAD
            var exit_0_out = exit0_common.PickRandom();
            var exit_1_out = exit1_common.PickRandom();

            PackedScene packedScene = (PackedScene)GD.Load("res://proced_rooms/" + exit_0_out + ".tscn");
            Node2D s = (Node2D)packedScene.Instantiate();
            s.Position = Exit0.Position;
            AddChild(s);

            packedScene = (PackedScene)GD.Load("res://proced_rooms/" + exit_1_out + ".tscn");
            s = (Node2D)packedScene.Instantiate();
            s.Position = Exit1.Position;
            AddChild(s);

            rooms_to_create = 0;
            all_rooms_created = true;
            GlobalVariables.rooms_to_create -= 1;
            GlobalVariables.rooms_created += 1;
            GlobalVariables.forbid_room_creation = false;
        } else
        {
            PackedScene packedScene = (PackedScene)GD.Load("res://proced_rooms/prc_right_end.tscn");
            Node2D s = (Node2D)packedScene.Instantiate();
            s.Position = Exit0.Position;
            AddChild(s);

            packedScene = (PackedScene)GD.Load("res://proced_rooms/prc_up_end.tscn");
            s = (Node2D)packedScene.Instantiate();
            s.Position = Exit1.Position;
            AddChild(s);
        }

        return;
    }
}
